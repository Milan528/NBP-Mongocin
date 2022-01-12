using MongocinAPI.App_Start;
using MongoDB.Driver;
using MongocinAPI.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace MongocinAPI.Services
{
    public class ReceiptService
    {
        private MongoDBContext _dbContext;
        private IMongoCollection<Receipt> _receiptCollection;

        public ReceiptService()
        {
            _dbContext = new MongoDBContext();
            _receiptCollection = _dbContext.Database.GetCollection<Receipt>(ConfigurationManager.AppSettings["ReceiptCollectionName"]);
        }

        public Receipt GetReceipt(string receiptId)
        {
            try
            {
                FilterDefinition<Receipt> Filter = Builders<Receipt>.Filter.Eq("Id", receiptId);
                List<Receipt> Results= _receiptCollection.Find(Filter).ToList();
                if (Results.Count == 0)
                    return null;
                return Results.First();
            }
            catch
            {
                return null;
            }

        }

        public bool InsertReceipt(Receipt Receipt)
        {
            try
            {
                if (_receiptCollection == null)
                    return false;

                AddFullCost(Receipt);
                Receipt.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                Receipt prevReceipt = GetReceipt(Receipt.Id.ToString());
                if (prevReceipt == null)
                {
                    _receiptCollection.InsertOne(Receipt);
                    return true;
                }
                else return false;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteReceipt(string receiptId)
        {
            try
            {
                if (_receiptCollection == null || GetReceipt(receiptId) == null)
                    return false;
                _receiptCollection.DeleteOne(Builders<Receipt>.Filter.Eq("Id", receiptId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReceipt(Receipt receipt)
        {
            try
            {
                if (_receiptCollection == null || GetReceipt(receipt.Id.ToString()) == null)
                    return false;
                UpdateDefinition<Receipt> UpdateReceipt = Builders<Receipt>.Update
                    .Set("Cost", receipt.FullCost)
                    .Set("Products", receipt.ProductList)
                    .Set("Date", receipt.DateOfBill)
                    .Set("ShopId",receipt.ShopId);
                _receiptCollection.UpdateOne(Builders<Receipt>.Filter.Eq("Id",receipt.Id.ToString()), UpdateReceipt);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Count() => (int)_receiptCollection.CountDocuments(receipt => true);

        public List<Receipt> GetNReceipts(int NumberOfReceipts)
        {
            try
            {
                List<Receipt> ListOfReceipts;
                ListOfReceipts = _receiptCollection.Find<Receipt>(Builders<Receipt>.Filter.Empty).ToList();
                if (ListOfReceipts.Count < NumberOfReceipts || NumberOfReceipts == 0)
                    return ListOfReceipts;
                else
                    return ListOfReceipts.GetRange(0, NumberOfReceipts);
            }
            catch
            {
                return null;
            }
        }

        public List<Receipt> ReturnAllReceiptsOfShop(string ShopId)
        {
            try
            {
                List<Receipt> listOfReceipts;
                FilterDefinition<Receipt> Filter = Builders<Receipt>.Filter.Eq("ShopId", new MongoDB.Bson.ObjectId(ShopId));
                listOfReceipts = _receiptCollection.Find<Receipt>(Filter).ToList();
                return listOfReceipts;
            }
            catch
            {
                return null;
            }
        }

        public double CalculateFullCost(List<ProductListElement> ReceiptList)
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
   
        public void AddFullCost(Receipt ReceiptToCalculate)
        {
            if (ReceiptToCalculate.ProductList != null)
                ReceiptToCalculate.FullCost = CalculateFullCost(ReceiptToCalculate.ProductList);
            else
                ReceiptToCalculate.FullCost = 0;
        }
    }
}