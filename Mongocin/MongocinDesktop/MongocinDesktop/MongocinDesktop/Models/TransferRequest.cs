using System.Collections.Generic;


namespace MongocinDesktop.Models
{
    public class TransferRequest:IStatefull
    {
        #region Attributes

       
        

       
        private string _shopId;

      
        private string _storageId;

        
        private List<ProductListElement> _productList;

        #endregion

        #region Properties


        public string Id
        {
            get;
            set;
        }


        public string ShopId
        {
            get { return _shopId; }
            set { _shopId = value; }
        }

        
        public string StorageId
        {
            get { return _storageId; }
            set { _storageId = value; }
        }

        
        public List<ProductListElement> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }

       
        public StateEnum State { get; set; }

    }
    #endregion
}