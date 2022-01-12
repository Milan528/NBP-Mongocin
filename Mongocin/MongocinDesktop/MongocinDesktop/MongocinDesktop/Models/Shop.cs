using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongocinDesktop.Models.Abstract;


namespace MongocinDesktop.Models
{
    public class Shop : Storehouse
    {
      
        public List<String> Receipts { get; set; }

  
        public List<Receipt> ReceiptList { get; set; }

    }
}