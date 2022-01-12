
using System;
using System.Collections.Generic;

namespace MongocinDesktop.Models
{

   
    public class Bill
    {
        #region Attributes

        
        private double _fullCost;

       
        private ProductListElement[] _productList;

        
        private DateTime _dateOfBill;

        #endregion

        #region Properties

       
        public string Id { get; set; }

       
        public double FullCost
        {
            get 
            {/*
                if (_fullCost == default(double))
                {
                    _fullCost = 0;
                    foreach (Product SingleProduct in _productList)
                    {
                        _fullCost += SingleProduct.Value;
                    }
                }*/
                return _fullCost;
            }
            set { _fullCost = value; }
        }

       
        public ProductListElement[] ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }

       
        public DateTime DateOfBill
        {
            get { return _dateOfBill; }
            set { _dateOfBill = value; }
        }

        #endregion

        #region Methodes

        /* public void AddProduct(Product NewProduct)
         {
             if(this._productList == null)
                 _productList = new List<Product>();

             this._productList.Add(NewProduct);
             FullCost += NewProduct.Value;
         }

         public void DeleteProduct(string ProductId)
         {
             if (this._productList == null)
                 return;
             this._productList.RemoveAt(this._productList.FindIndex(SingleProduct => SingleProduct.ID == ProductId));
         }
         */

        private void CalculateFullCost()
        {
            
                _fullCost = 0;
                foreach (ProductListElement SingleProduct in _productList)
                {
                    _fullCost += SingleProduct.ProductQuantity;
                }

                
            
        }
        #endregion

    }
}