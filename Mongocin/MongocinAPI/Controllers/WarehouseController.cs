using System.Collections.Generic;
using System.Web.Mvc;
using MongocinAPI.Models;
using MongocinAPI.Services;

namespace MongocinAPI.Controllers
{
    public class WarehouseController : Controller
    {
        #region Attributes

        private WarehouseService _warehouseService;

        #endregion

        #region Constructors

        public WarehouseController()
        {
            _warehouseService = new WarehouseService();
        }

        #endregion

        #region Actions

        [HttpGet]
        [Route("Warehouse/GetAllWarehouses/{NumberOfWarehouses}")]
        public ActionResult GetAllWarehouses(string NumberOfWarehouses)
        {
            int RequestedNumber;
            if (!int.TryParse(NumberOfWarehouses, out RequestedNumber))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            List<Warehouse> ListOfWarehouses = _warehouseService.GetNWarehouses(RequestedNumber);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = ListOfWarehouses;
            return Response;
        }

        [HttpGet]
        public ActionResult Get(string Id)
        {
            Warehouse Result = _warehouseService.GetWarehouse(Id);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = Result;
            return Response;
        }

        [HttpPost]
        public ActionResult Create(Warehouse NewWarehouse)
        {
            if (NewWarehouse.Address != null
                && NewWarehouse.Name != null)
            {
                if (_warehouseService.InsertWarehouse(NewWarehouse))
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            if (_warehouseService.DeleteWarehouse(Id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public ActionResult Edit(Warehouse WarehouseToEdit)
        {
            if (WarehouseToEdit.Address == null
               //|| WarehouseToEdit.Products == null
               || WarehouseToEdit.Name == null
               //|| WarehouseToEdit.Orders == null
               )
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_warehouseService.UpdateWarehouse(WarehouseToEdit))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Warehouse/ReturnAllProductsOfWarehouse/{WarehouseId}")]
        public ActionResult ReturnAllProductsOfWarehouse(string WarehouseId)
        {
            List<Product> listOfProducts = new List<Product>();
            listOfProducts = _warehouseService.ReturnAllProductsOfWarehouse(WarehouseId);

            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = listOfProducts;
            return Response;
        }

        [HttpPut]
        [Route("Warehouse/AddProduct")]
        public ActionResult AddProduct(string WarehouseId, string ProductId, int Quantity)
        {
            if (_warehouseService.AddProduct(WarehouseId, ProductId, Quantity))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        public ActionResult Index => View();

        #endregion

    }
}
