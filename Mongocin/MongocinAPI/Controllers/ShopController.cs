using System.Collections.Generic;
using System.Web.Mvc;
using MongocinAPI.Models;
using MongocinAPI.Services;

namespace MongocinAPI.Controllers
{
    public class ShopController : Controller
    {
        #region Attributes

        private ShopService _shopService;

        #endregion

        #region Constructors

        public ShopController()
        {
            _shopService = new ShopService();
        }

        #endregion

        #region Actions

        [HttpGet]
        [Route("Shop/GetAllShop/{NumberOfShops}")]
        public ActionResult GetAllShops(string NumberOfShops)
        {
            int RequestedNumber;
            if (!int.TryParse(NumberOfShops, out RequestedNumber))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            List<Shop> ListOfShops = _shopService.GetNShops(RequestedNumber);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = ListOfShops;
            return Response;
        }

        [HttpGet]
        public ActionResult Get(string Id)
        {
            Shop Result = _shopService.GetShop(Id);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = Result;
            return Response;
        }

        [HttpPost]
        public ActionResult Create(Shop NewShop)
        {
            if (NewShop.Address != null
                && NewShop.Name != null)
            {
                if (_shopService.InsertShop(NewShop))
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            if (_shopService.DeleteShop(Id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public ActionResult Edit(Shop ShopToEdit)
        {
            if (ShopToEdit.Address == null
              // || ShopToEdit.Products == null
               || ShopToEdit.Name == null
               /*|| ShopToEdit.Receipts == null*/)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_shopService.UpdateShop(ShopToEdit))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("Shop/AddProduct")]
        public ActionResult AddProduct(string ShopId, string ProductId, int Quantity)
        {
            if (_shopService.AddProduct(ShopId, ProductId, Quantity))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Route("Shop/DeleteProduct")]
        public ActionResult DeleteProduct(string ShopId, string ProductId, int Quantity)
        {
            if (_shopService.DeleteProduct(ShopId, ProductId, Quantity))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Shop/CalculateFullValueOfAllProducts/{ShopId}")]
        public ActionResult CalculateFullValueOfAllProducts(string ShopId)
        {
            double? FullValue = _shopService.CalculateFullValueOfAllProducts(ShopId);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = FullValue;
            return Response;
        }

        [HttpGet]
        [Route("Shop/ReturnAllProductsOfShop/{ShopId}")]
        public ActionResult ReturnAllProductsOfShop(string ShopId)
        {
            List<Product> listOfProducts = new List<Product>();
            listOfProducts = _shopService.ReturnAllProductsOfShop(ShopId);

            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = listOfProducts;
            return Response;
        }

        public ActionResult Index => View();

        #endregion
    }
}
