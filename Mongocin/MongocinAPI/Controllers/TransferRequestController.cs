using System.Collections.Generic;
using System.Web.Mvc;
using MongocinAPI.Models;
using MongocinAPI.Services;

namespace MongocinAPI.Controllers
{
    public class TransferRequestController : Controller
    {
        #region Attributes

        private TransferService _transferService;

        #endregion

        #region Constructors

        public TransferRequestController()
        {
            _transferService = new TransferService();
        }

        #endregion

        #region Actions
        [HttpGet]
        [Route("TransferRequest/GetAllRequests/{NumberOfRequests}")]
        public ActionResult GetAllRequests(string NumberOfRequests)
        {
            int RequestedNumber;
            if (!int.TryParse(NumberOfRequests, out RequestedNumber))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            List<TransferRequest> listOfTransfers = _transferService.GetTransfers(RequestedNumber);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = listOfTransfers;
            return Response;
        }
        [HttpGet]
        public ActionResult Get(string Id)
        {
            TransferRequest Result = _transferService.GetTransferRequest(Id);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = Result;
            return Response;
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            if (_transferService.DeleteTransfer(Id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Create(TransferRequest TransferRequest)
        {
            if (TransferRequest.ProductList == null ||
                TransferRequest.ShopId == null ||
                TransferRequest.StorageId == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_transferService.InsertTransferRequest(TransferRequest))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            else
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public ActionResult Edit(TransferRequest TransferToEdit)
        {
            if (TransferToEdit.ProductList == null ||
                TransferToEdit.ShopId == null ||
                TransferToEdit.StorageId == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_transferService.UpdateTransferRequest(TransferToEdit))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        public ActionResult Index => View();

        [HttpGet]
        [Route("TransferRequest/GetAllTransfersOfShop/{ShopId}")]
        public ActionResult GetAllTransferRequestsOfShop(string ShopId)
        {
            List<TransferRequest> result = _transferService.ReturnAllTransfersOfShop(ShopId);
            if (result == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            JsonResult response = new JsonResult();
            response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            response.Data = result;
            return response;
        }

        [HttpGet]
        [Route("TransferRequest/GetAllTransfersOfWarehouse/{WarehouseId}")]
        public ActionResult GetAllTransferRequestsOfWarehouse(string WarehouseId)
        {
            List<TransferRequest> result = _transferService.ReturnAllTransfersOfWarehouse(WarehouseId);
            if (result == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            JsonResult response = new JsonResult();
            response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            response.Data = result;
            return response;
        }

        [HttpPost]
        [Route("TransferRequest/DoTheRequest")]
        public ActionResult DoTheRequest(string RequestId)
        {
            if (_transferService.DoTheTransfer(RequestId))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        #endregion
    }
}