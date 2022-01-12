using MongoDB.Bson.Serialization.Attributes;

namespace MongocinAPI.Models
{
    public class ProductListElement
    {
        [BsonElement("ProductId")]
        [BsonRequired]
        public string ProductId { get; set; }

        [BsonElement("ProductQuantity")]
        [BsonRequired]
        public int ProductQuantity { get; set; }

        public ProductListElement()
        {
            ProductId = null;
            ProductQuantity = 0;
        }

        public ProductListElement(string ProductId,int ProductQuantity)
        {
            this.ProductId = ProductId;
            this.ProductQuantity = ProductQuantity;
        }
    }
}