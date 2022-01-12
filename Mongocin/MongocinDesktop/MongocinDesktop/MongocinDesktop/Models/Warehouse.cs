using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongocinDesktop.Models.Abstract;



namespace MongocinDesktop.Models
{
    public class Warehouse : Storehouse
    {
      
        public List<Order> OrdersList { get; set; }

       
        public List<String> Orders { get; set; }
    }
}