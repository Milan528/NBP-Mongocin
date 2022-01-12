using MongocinAPI.Models;
using MongocinAPI.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MongocinAPI.Controllers
{
    public class ReceiptController : Controller
    {

        #region Attributes

        private ReceiptService _receiptService;

        #endregion

        #region Constructors

        public ReceiptController()
        {
            _receiptService = new ReceiptService();
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Get(string Id)
        {
            Receipt Result = _receiptService.GetReceipt(Id);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = Result;
            return Response;
        }

        [HttpGet]
        [Route("Receipt/GetAllReceipts/{NumberOfReceipts}")]
        public ActionResult GetAllReceipts(string NumberOfReceipts)
        {
            int RequestedNumber;
            if (!int.TryParse(NumberOfReceipts, out RequestedNumber))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            List<Receipt> ListOfReceipts = _receiptService.GetNReceipts(RequestedNumber);
            JsonResult Response = new JsonResult();
            Response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Response.Data = ListOfReceipts;
            return Response;
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            if (_receiptService.DeleteReceipt(Id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Create(Receipt NewReceipt)
        {
            if (NewReceipt.ShopId == null
                || NewReceipt.ProductList == null
                || NewReceipt.DateOfBill == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_receiptService.InsertReceipt(NewReceipt))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            else
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            
        }


        [HttpPut]
        public ActionResult Edit(Receipt ReceiptToEdit)
        {
            if (ReceiptToEdit.ProductList == null
                || ReceiptToEdit.ShopId == null
                || ReceiptToEdit.DateOfBill == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_receiptService.UpdateReceipt(ReceiptToEdit))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("Receipt/GetAllReceiptsOfShop/{ShopId}")]
        public ActionResult GetAllReceiptsOfShop(string ShopId)
        {
            List<Receipt> result = _receiptService.ReturnAllReceiptsOfShop(ShopId);
            if (result == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            JsonResult response = new JsonResult();
            response.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            response.Data = result;
            return response;
        }

        public ActionResult Index => View();

        #endregion

    }
}