using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongocinAPI.Models
{
    public class Receipt : Bill
    {
        #region Attributes

        [BsonElement("ShopId")]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _shopId;

        #endregion

        #region Properties

        [BsonIgnore]
        public string ShopId
        {
            get { return _shopId; }
            set { _shopId = value; }
        }

        #endregion
    }
}