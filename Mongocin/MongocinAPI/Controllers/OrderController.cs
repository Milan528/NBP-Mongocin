using MongocinAPI.Models;
using MongocinAPI.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using MongoDB.Driver;

namespace MongocinAPI.Controllers
{
    public class OrderController : Controller
    {
        #region Attributes

        private OrderService _orderService;

        #endregion

        #region Constructors

        public OrderController()
        {
            _orderService = new OrderService();
        }

        #endregion

        #region Actions

        [HttpGet]
        [Route("Order/GetAllOrders/{NumberOfOrders}")]
        public ActionResult GetAllOrders(string NumberOfOrders)
        {
            int RequestedNumber;
            if (!int.TryParse(NumberOfOrders, out RequestedNumber))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            List<Order> ListOfOrders = _orderService.GetNOrders(RequestedNumber);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = ListOfOrders;
            return Response;
        }

        [HttpGet]
        public ActionResult Get(string Id)
        {
            Order Result = _orderService.GetOrder(Id);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = Result;
            return Response;
        }

        [HttpPost]
        public ActionResult Create(Order NewOrder)
        {
            if (NewOrder.CustomerName != null
                && NewOrder.CustomerAddress != null
                && NewOrder.DateOfBill != null
                && NewOrder.StorageId != null
                && NewOrder.ProductList != null)
            {
                if (_orderService.InsertOrder(NewOrder))
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            if (_orderService.DeleteOrder(Id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public ActionResult Edit(Order OrderToEdit)
        {
            if (OrderToEdit.CustomerName == null
               || OrderToEdit.CustomerAddress == null
               || OrderToEdit.DateOfBill == null
               || OrderToEdit.StorageId == null
               || OrderToEdit.ProductList == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_orderService.UpdateOrder(OrderToEdit))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("Order/ChangeState")]
        public ActionResult ChangeState(string OrderId, StateEnum NewState)
        {
            if (OrderId == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_orderService.ChangeState(OrderId, NewState))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Order/GetAllOrdersOfWarehouse/{WarehouseId}")]
        public ActionResult GetAllOrdersOfWarehouse(string WarehouseId)
        {
            List<Order> Result = _orderService.GetAllOrdersOfOneWarehouse(WarehouseId);
            if (Result == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            JsonResult response = new JsonResult();
            response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            response.Data = Result;
            return response;
        }

        [HttpPost]
        [Route("Order/ProcessOrder")]
        public ActionResult ProcessOrder(string OrderId)
        {
            if (_orderService.ProcessOrder(OrderId))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        public ActionResult Index => View();

        #endregion

    }
}