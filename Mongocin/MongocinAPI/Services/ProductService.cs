using MongocinAPI.App_Start;
using MongocinAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MongocinAPI.Services
{
    public class ProductService
    {
        private MongoDBContext _dbContext;
        private IMongoCollection<Product> _productCollection;

        public ProductService()
        {
            _dbContext = new MongoDBContext();
            _productCollection = _dbContext.Database.GetCollection<Product>
                (ConfigurationManager.AppSettings["ProductCollectionName"]);
        }

        public Product GetProduct(string productId)
        {
            try
            {
                FilterDefinition<Product> Filer = Builders<Product>.Filter.Eq("Id", productId);
                List<Product> Results = _productCollection.Find(Filer).ToList();
                if (Results.Count == 0)
                    return null;

                return Results.First();
            }
            catch
            {
                return null;
            }
        }

        public bool InsertProduct(Product Product)
        {
            try
            {
                if (_productCollection == null)
                    return false;
                Product.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                Product prevProduct = GetProduct(Product.Id.ToString());
                if (prevProduct == null)
                {
                    _productCollection.InsertOne(Product);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProduct(string productId)
        {
            try
            {
                if (_productCollection == null || GetProduct(productId) == null)
                    return false;
                _productCollection.DeleteOne(Builders<Product>.Filter.Eq("Id", productId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                if (_productCollection == null || GetProduct(product.Id.ToString()) == null)
                    return false;
                UpdateDefinition<Product> UpdateProduct = Builders<Product>.Update
                    .Set("Name", product.Name)
                    .Set("Description", product.Description)
                    .Set("Price", product.Price);
                _productCollection.UpdateOne(Builders<Product>.Filter.Eq("Id", product.Id.ToString()), UpdateProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Count() => (int)_productCollection.CountDocuments(product => true);

        public List<Product> GetProducts(int numberOfProducts)
        {
            try
            {
                List<Product> listOfProducts;
                listOfProducts = _productCollection.Find<Product>(Builders<Product>.Filter.Empty).ToList();
                if (listOfProducts.Count < numberOfProducts || numberOfProducts == 0)
                    return listOfProducts;
                else
                    return listOfProducts.GetRange(0, numberOfProducts);
            }
            catch
            {
                return null;
            }
        }
    }
}