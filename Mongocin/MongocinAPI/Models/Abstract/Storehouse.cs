using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongocinAPI.Models.Abstract
{
    [BsonKnownTypes(typeof(Shop), typeof(Warehouse))]
    public class Storehouse
    {
            #region Attributes

            [BsonElement("Address")]
            public string Address { get; set; }

            [BsonElement("Products")]
            public List<ProductListElement> Products { get; set; }

            [BsonElement("Name")]
            public string Name { get; set; }

            #endregion

            #region Properties

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            #endregion

            #region Methodes

            public void AddProduct(ProductListElement NewProduct)
            {
                if (this.Products == null)
                Products = new List<ProductListElement>();

                this.Products.Add(NewProduct);
                
            }

            public void DeleteProduct(string ProductId)
            {
                if (this.Products == null)
                    return;
                this.Products.RemoveAt(this.Products.FindIndex(SingleProduct => SingleProduct.ProductId == ProductId));
            }

            #endregion
    }
}
