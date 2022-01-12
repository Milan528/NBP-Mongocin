using MongocinAPI.App_Start;
using MongocinAPI.Models;
using MongoDB.Driver;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

namespace MongocinAPI.Services
{
    public class OrderService
    {
        private MongoDBContext _dbContext;
        private IMongoCollection<Order> _orderCollection;

        public OrderService()
        {
            _dbContext = new MongoDBContext();
            _orderCollection = _dbContext.Database.GetCollection<Order>
                (ConfigurationManager.AppSettings["OrdersCollectionName"]);
        }

        public Order GetOrder(string orderId)
        {
            try
            {
                FilterDefinition<Order> Filer = Builders<Order>.Filter.Eq("Id", orderId);
                List<Order> Results = _orderCollection.Find(Filer).ToList();
                if (Results.Count == 0)
                    return null;

                return Results.First();
            }
            catch
            {
                return null;
            }
        }

        public bool InsertOrder(Order Order)
        {
            try
            {
                if (_orderCollection == null)
                    return false;
                CalculateFullCost(Order);
                Order.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                Order prevOrder = GetOrder(Order.Id.ToString());
                if (prevOrder == null)
                {
                    _orderCollection.InsertOne(Order);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrder(string orderId)
        {
            try
            {
                if (_orderCollection == null || GetOrder(orderId) == null)
                    return false;
                _orderCollection.DeleteOne(Builders<Order>.Filter.Eq("Id", orderId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrder(Order order)
        {
            try
            {
                if (_orderCollection == null || GetOrder(order.Id.ToString()) == null)
                    return false;
                UpdateDefinition<Order> UpdateOrder = Builders<Order>.Update
                    .Set("Cost", order.FullCost)
                    .Set("Products", order.ProductList)
                    .Set("Date", order.DateOfBill)
                    .Set("CustomerName", order.CustomerName)
                    .Set("CustomerAddress", order.CustomerAddress)
                    .Set("StorageId", order.StorageId)
                    .Set("State", order.State);
                _orderCollection.UpdateOne(Builders<Order>.Filter.Eq("Id", order.Id.ToString()), UpdateOrder);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeState(string OrderId, StateEnum NewState)
        {
            if (CheckIfExists(OrderId) == false)
                return false;
            UpdateDefinition<Order> UpdateOrder = Builders<Order>.Update
                   .Set("State", NewState);
            try
            {
                _orderCollection.UpdateOne(Builders<Order>.Filter.Eq("Id", OrderId), UpdateOrder);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckIfExists(string OrderId)
        {
            if (_orderCollection == null)
                return false;
            FilterDefinition<Order> Filter = Builders<Order>.Filter.Eq("Id", OrderId);
            try
            {
                if (_orderCollection.Find<Order>(Filter).ToList().Count == 0)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public int Count() => (int)_orderCollection.CountDocuments(order=>true);

        public List<Order> GetNOrders(int numberOfOrders)
        {
            try
            {
                List<Order> listOfOrders = new List<Order>();
                listOfOrders = _orderCollection.Find<Order>(Builders<Order>.Filter.Empty).ToList();
                if (listOfOrders.Count < numberOfOrders || numberOfOrders == 0)
                    return listOfOrders;
                else 
                    return listOfOrders.GetRange(0, numberOfOrders);
            }
            catch
            {
                return null;
            }
        }
    
        public List<Order> GetAllOrdersOfOneWarehouse(string WarehouseId)
        {
            try
            {
                List<Order> ListOfOrders;
                FilterDefinition<Order> Filter = Builders<Order>.Filter.Eq("StorageId", WarehouseId);
                ListOfOrders = _orderCollection.Find<Order>(Filter).ToList();
                return ListOfOrders;
            }
            catch
            {
                return null;
            }
        }
    
        public bool ProcessOrder(string OrderId)
        {
            WarehouseService WarehouseS = new WarehouseService();

            Order TargetedOrder = GetOrder(OrderId);
            if (TargetedOrder == null)
                return false;
            if (!WarehouseS.WarehouseExists(TargetedOrder.StorageId))
                return false;
            if (!TargetedOrder.ProductList.All(SingleProduct =>
                 WarehouseS.CheckProductQuantity(TargetedOrder.StorageId, SingleProduct.ProductId, SingleProduct.ProductQuantity)))
                return false;

            foreach (ProductListElement SingleProduct in TargetedOrder.ProductList)
                WarehouseS.DeleteProduct(TargetedOrder.StorageId, SingleProduct.ProductId, SingleProduct.ProductQuantity);
            try
            {
                TargetedOrder.State = StateEnum.Shipped;
                UpdateDefinition<Order> UpdateOrderRequest = Builders<Order>.Update
                        .Set("State", TargetedOrder.State);
                _orderCollection.UpdateOne(Builders<Order>.Filter.Eq("Id", TargetedOrder.Id), UpdateOrderRequest);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public double CalculateFullCostOfList(List<ProductListElement> ReceiptList)
        {
            ProductService Products = new ProductService();
            double Cost = 0;
            foreach (ProductListElement SingleProduct in ReceiptList)
            {
                Product FromDatabase = Products.GetProduct(SingleProduct.ProductId);
                if (FromDatabase != null)
                    Cost += FromDatabase.Price * SingleProduct.ProductQuantity;
            }
            return Cost;
        }

        public void CalculateFullCost(Order OrderToCalculate)
        {
            if (OrderToCalculate.ProductList != null)
                OrderToCalculate.FullCost = CalculateFullCostOfList(OrderToCalculate.ProductList);
            else
                OrderToCalculate.FullCost = 0;
        }
    }
}