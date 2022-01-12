
using System;
using System.Collections.Generic;

namespace MongocinDesktop.Models
{
    public class Order : Bill,IStatefull
    {

        #region Attributes

      
        private string _customerAddress;

       
        private string _customerName;

       
        private string _storageId;

        #endregion


        #region Properties

       
        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; }
        }

      
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

    
        public string StorageId
        {
            get { return _storageId; }
            set { _storageId = value; }
        }

        
        public StateEnum State
        {
            get;
            set;
        }

        #endregion




    }
}