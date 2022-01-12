using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongocinAPI.Models
{
    public class TransferRequest:IStatefull
    {
        #region Attributes

        [BsonElement("ShopId")]
        private string _shopId;

        [BsonElement("StorageId")]
        private string _storageId;

        [BsonElement("ProductList")]
        private List<ProductListElement> _productList;

        #endregion

        #region Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }

        [BsonIgnore]
        public string ShopId
        {
            get { return _shopId; }
            set { _shopId = value; }
        }

        [BsonIgnore]
        public string StorageId
        {
            get { return _storageId; }
            set { _storageId = value; }
        }

        [BsonIgnore]
        public List<ProductListElement> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }

        [BsonElement("State")]
        public StateEnum State { get; set; }

        #endregion

    }
}