using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongocinAPI.Models
{

    [BsonKnownTypes(typeof(Receipt),typeof(Order))]
    public class Bill
    {
        #region Attributes

        [BsonElement("Cost")]
        private double _fullCost;

        [BsonElement("Products")]
        private List<ProductListElement> _productList;

        [BsonElement("Date")]
        private DateTime _dateOfBill;

        #endregion

        #region Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonIgnore]
        public double FullCost
        {
            get { return _fullCost; }
            set { _fullCost = value; }
        }

        [BsonIgnore]
        public List<ProductListElement> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }

        [BsonIgnore]
        public DateTime DateOfBill
        {
            get { return _dateOfBill; }
            set { _dateOfBill = value; }
        }

        #endregion

    }
}