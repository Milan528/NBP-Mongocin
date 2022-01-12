using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongocinAPI.Models
{
    public class Order : Bill,IStatefull
    {

        #region Attributes

        [BsonElement("CustomerAddress")]
        private string _customerAddress;

        [BsonElement("CustomerName")]
        private string _customerName;

        [BsonElement("StorageId")]
        private string _storageId;

        #endregion


        #region Properties

        [BsonIgnore]
        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; }
        }

        [BsonIgnore]
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        [BsonIgnore]
        public string StorageId
        {
            get { return _storageId; }
            set { _storageId = value; }
        }

        [BsonElement("State")]
        public StateEnum State
        {
            get;
            set;
        }

        #endregion




    }
}