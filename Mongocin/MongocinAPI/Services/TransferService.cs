using MongocinAPI.App_Start;
using MongoDB.Driver;
using MongocinAPI.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace MongocinAPI.Services
{
    public class TransferService
    {

        #region Attributes

        private MongoDBContext _dbContext;
        private IMongoCollection<TransferRequest> _transferRequestCollection;

        #endregion

        #region Constructors

        public TransferService()
        {
            _dbContext = new MongoDBContext();
            _transferRequestCollection = _dbContext.Database.GetCollection<TransferRequest>
                (ConfigurationManager.AppSettings["RequestCollectionName"]);
        }

        public List<TransferRequest> GetTransfers(int numberOfWarehouses)
        {
            try
            {
                List<TransferRequest> listofTransfers = new List<TransferRequest>();
                listofTransfers = _transferRequestCollection.Find<TransferRequest>(Builders<TransferRequest>.Filter.Empty).ToList();
                if (listofTransfers.Count < numberOfWarehouses || numberOfWarehouses == 0)
                    return listofTransfers;
                else
                    return listofTransfers.GetRange(0, numberOfWarehouses);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Methodes

        public TransferRequest GetTransferRequest(string transferRequestId)
        {
            try
            {
                FilterDefinition<TransferRequest> Filer = Builders<TransferRequest>.Filter
                    .Eq("Id",transferRequestId);
                List<TransferRequest> Results = _transferRequestCollection.Find(Filer).ToList();
                if (Results.Count == 0)
                    return null;

                return Results.First();
            }
            catch
            {
                return null;
            }
        }

        public bool InsertTransferRequest(TransferRequest transferRequest)
        {
            try
            {
                if (_transferRequestCollection == null)
                    return false;

                transferRequest.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                TransferRequest prevTransferRequest = GetTransferRequest(transferRequest.Id.ToString());
                if (prevTransferRequest == null)
                {
                    _transferRequestCollection.InsertOne(transferRequest);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTransfer(string transferRequestId)
        {
            try
            {
                if (_transferRequestCollection == null || GetTransferRequest(transferRequestId) == null)
                    return false;
                _transferRequestCollection.DeleteOne(Builders<TransferRequest>.Filter.Eq("Id", transferRequestId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTransferRequest(TransferRequest transferRequest)
        {
            try
            {
                if (_transferRequestCollection == null || GetTransferRequest(transferRequest.Id.ToString()) == null)
                    return false;
                UpdateDefinition<TransferRequest> UpdateTransferRequest = Builders<TransferRequest>.Update
                    .Set("ShopId", transferRequest.ShopId)
                    .Set("StorageId", transferRequest.StorageId)
                    .Set("State", transferRequest.State);
                _transferRequestCollection.UpdateOne(Builders<TransferRequest>.Filter.Eq("Id", transferRequest.Id), UpdateTransferRequest);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TransferRequest> ReturnAllTransfersOfShop(string ShopId)
        {
            try
            {
                List<TransferRequest> listOfTransfers;
                FilterDefinition<TransferRequest> Filter = Builders<TransferRequest>.Filter.Eq("ShopId", ShopId);
                listOfTransfers = _transferRequestCollection.Find<TransferRequest>(Filter).ToList();
                return listOfTransfers;
            }
            catch
            {
                return null;
            }
        }

        public List<TransferRequest> ReturnAllTransfersOfWarehouse(string WarehouseId)
        {
            try
            {
                List<TransferRequest> listOfTransfers;
                FilterDefinition<TransferRequest> Filter = Builders<TransferRequest>.Filter.Eq("StorageId", WarehouseId);
                listOfTransfers = _transferRequestCollection.Find<TransferRequest>(Filter).ToList();
                return listOfTransfers;
            }
            catch
            {
                return null;
            }
        }

        public bool DoTheTransfer(string TransferId)
        {
            ShopService ShopS = new ShopService();
            WarehouseService WarehouseS = new WarehouseService();

            TransferRequest TargetedRequest = GetTransferRequest(TransferId);
            if (TargetedRequest == null)
                return false;
            if (!WarehouseS.WarehouseExists(TargetedRequest.StorageId) || !ShopS.ShopExists(TargetedRequest.ShopId))
                return false;
            if(!TargetedRequest.ProductList.All(SingleProduct=>
                WarehouseS.CheckProductQuantity(TargetedRequest.StorageId, SingleProduct.ProductId, SingleProduct.ProductQuantity)))
                return false;

            foreach (ProductListElement SingleProduct in TargetedRequest.ProductList)
            {
                WarehouseS.DeleteProduct(TargetedRequest.StorageId, SingleProduct.ProductId, SingleProduct.ProductQuantity);
                ShopS.AddProduct(TargetedRequest.ShopId, SingleProduct.ProductId, SingleProduct.ProductQuantity);
            }
            try
            {
                TargetedRequest.State = StateEnum.Delivered;
                UpdateDefinition<TransferRequest> UpdateTransferRequest = Builders<TransferRequest>.Update
                        .Set("State", TargetedRequest.State);
                _transferRequestCollection.UpdateOne(Builders<TransferRequest>.Filter.Eq("Id", TargetedRequest.Id), UpdateTransferRequest);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        #endregion











    }
}