using MongocinAPI.App_Start;
using MongocinAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MongocinAPI.Services
{
    public class ShopService
    {
        private MongoDBContext _dbContext;
        private IMongoCollection<Shop> _shopCollection;

        public ShopService()
        {
            _dbContext = new MongoDBContext();
            _shopCollection = _dbContext.Database.GetCollection<Shop>
                (ConfigurationManager.AppSettings["ShopCollectionName"]);
        }

        public Shop GetShop(string shopId)
        {
            try
            {
                FilterDefinition<Shop> Filer = Builders<Shop>.Filter.Eq("Id", shopId);
                List<Shop> Results = _shopCollection.Find(Filer).ToList();
                if (Results.Count == 0)
                    return null;

                return Results.First();
            }
            catch
            {
                return null;
            }
        }

        public bool InsertShop(Shop Shop) 
        {
            try
            {
                if (_shopCollection == null)
                    return false;
                Shop.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
                Shop prevShop = GetShop(Shop.Id.ToString());
                if (prevShop == null)
                {
                    _shopCollection.InsertOne(Shop);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteShop(string shopId) 
        {
            try
            {
                if (_shopCollection == null || GetShop(shopId) == null)
                    return false;
                _shopCollection.DeleteOne(Builders<Shop>.Filter.Eq("Id", shopId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateShop(Shop shop)
        {
            try
            {
                if (_shopCollection == null || GetShop(shop.Id.ToString()) == null)
                    return false;
                UpdateDefinition<Shop> UpdateShop = Builders<Shop>.Update
                    .Set("Address",shop.Address)
                    .Set("Products",shop.Products)
                    .Set("Name",shop.Name);
                _shopCollection.UpdateOne(Builders<Shop>.Filter.Eq("Id", shop.Id.ToString()), UpdateShop);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddProduct(string ShopId, string ProductId, int Quantity)
        {
            try
            {
                if (_shopCollection == null || GetShop(ShopId) == null)
                    return false;
                Shop ShopToAdd = GetShop(ShopId);

                if (ShopToAdd.Products == null)
                    ShopToAdd.Products = new List<ProductListElement>();

                ProductListElement ProductToChange = ShopToAdd.Products.Find(SingleProduct => SingleProduct.ProductId == ProductId);

                if (ProductToChange != null)
                    ProductToChange.ProductQuantity += Quantity;
                else
                    ShopToAdd.Products.Add(new ProductListElement(ProductId, Quantity));

                UpdateDefinition<Shop> UpdateShop = Builders<Shop>.Update.Set("Products", ShopToAdd.Products);
                _shopCollection.UpdateOne(Builders<Shop>.Filter.Eq("Id", ShopToAdd.Id.ToString()), UpdateShop);
                return true;
            }
            catch
            {
                return false;
            }    
        }

        public bool DeleteProduct(string ShopId, string ProductId, int Quantity)
        {
            try
            {
                if (_shopCollection == null || GetShop(ShopId) == null)
                    return false;

                Shop Shop = GetShop(ShopId);

                if (Shop.Products == null)
                    Shop.Products = new List<ProductListElement>();

                ProductListElement ProductToDelete = Shop.Products.Find(product => product.ProductId == ProductId);

                if (ProductToDelete == null)
                    return false;
                else if (Quantity > ProductToDelete.ProductQuantity)
                    return false;

                ProductToDelete.ProductQuantity -= Quantity;

                if (ProductToDelete.ProductQuantity == 0)
                    Shop.Products.Remove(ProductToDelete);

                UpdateDefinition<Shop> UpdateShop = Builders<Shop>.Update.Set("Products", Shop.Products);
                _shopCollection.UpdateOne(Builders<Shop>.Filter.Eq("Id", Shop.Id.ToString()), UpdateShop);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public double? CalculateFullValueOfAllProducts(string ShopId)
        {
            Shop Shop = GetShop(ShopId);
            if (Shop == null)
                return null;

            try
            {
                double FullValue = 0;
                ProductService productService = new ProductService();

                foreach (ProductListElement singleElement in Shop.Products)
                    FullValue += productService.GetProduct(singleElement.ProductId).Price * singleElement.ProductQuantity;

                return FullValue;
            }
            catch
            {
                return null;
            }
        }

        public List<Product> ReturnAllProductsOfShop(string ShopId)
        {
            List<Product> listOfProducts = new List<Product>();
            Shop Shop = GetShop(ShopId);
            if (Shop == null)
                return null;
            ProductService productService = new ProductService();

            foreach (ProductListElement singleElement in Shop.Products)
                listOfProducts.Add(productService.GetProduct(singleElement.ProductId));
            return listOfProducts;
        }
         
        public bool ShopExists(string ShopId)
        {
            try
            {
                FilterDefinition<Shop> Filer = Builders<Shop>.Filter.Eq("Id", ShopId);
                List<Shop> Results = _shopCollection.Find(Filer).ToList();
                if (Results.Count == 0)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Count() => (int)_shopCollection.CountDocuments(shop => true);

        public List<Shop> GetNShops(int numberOfShops) 
        {
            try
            {
                List<Shop> listOfShops = new List<Shop>();
                listOfShops = _shopCollection.Find<Shop>(Builders<Shop>.Filter.Empty).ToList();
                if (listOfShops.Count < numberOfShops || numberOfShops == 0)
                    return listOfShops;
                else
                    return listOfShops.GetRange(0, numberOfShops);
            }
            catch
            {
                return null;
            }
        }
    }
}