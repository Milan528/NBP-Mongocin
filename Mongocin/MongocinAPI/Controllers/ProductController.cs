using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MongocinAPI.Models;
using MongocinAPI.Services;

namespace MongocinAPI.Controllers
{
    public class ProductController : Controller
    {
        #region Attributes

        private ProductService _productService;

        #endregion

        #region Constructors

        public ProductController()
        {
            _productService = new ProductService();
        }

        #endregion

        #region Actions

        [HttpGet]
        [Route("Product/GetAllProducts/{NumberOfProducts}")]
        public ActionResult GetAllProducts(string NumberOfProducts)
        {
            int RequestedNumber;
            if (!int.TryParse(NumberOfProducts, out RequestedNumber))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            List<Product> ListOfProducts = _productService.GetProducts(RequestedNumber);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = ListOfProducts;
            return Response;
        }

        [HttpGet]
        public ActionResult Get(string Id)
        {
            Product Result = _productService.GetProduct(Id);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = Result;
            return Response;
        }

        [HttpPost]
        public ActionResult Create(Product NewProduct)
        {
            if (NewProduct.Name != null
                && NewProduct.Description != null
                && NewProduct.Price != null)
            {
                if (_productService.InsertProduct(NewProduct))
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                // TODO: Add update logic here
                // var _filter = Builders<ProductModel>.Filter.Eq("_id", ObjectId.Parse(product.Id));
                // var _update = Builders<ProductModel>.Update
                //     .Set("Name", product.Name)
                //     .Set("Price", product.Price)
                //     .Set("Description", product.Description);
                // var _result = _productCollection.UpdateOne(_filter, _update);
                if (_productService.DeleteProduct(Id))
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
         }

        [HttpPut]
        public ActionResult Edit(Product ProductToEdit)
        {
            if (ProductToEdit.Name == null
               || ProductToEdit.Description == null
               || ProductToEdit.Price == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_productService.UpdateProduct(ProductToEdit))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        public ActionResult Index => View();

        #endregion
    }
}
