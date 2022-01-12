
using System;
using System.Collections.Generic;

namespace MongocinDesktop.Models
{
    public class Receipt : Bill
    {
        #region Attributes

       
        private string _shopId;

        #endregion

        #region Properties

       
        public string ShopId
        {
            get { return _shopId; }
            private set { _shopId = value; }
        }

        #endregion

    }
}