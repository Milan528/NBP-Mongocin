using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MongocinDesktop.Models.Abstract
{
   
    public class Storehouse
    {
            #region Attributes

           
            public string Address { get; set; }

     
            public List<ProductListElement> Products { get; set; }

        
            public string Name { get; set; }

            #endregion

            #region Properties

           
            public string Id { get; set; }

          
            
           

          
           
            
            
          

            #endregion

            #region Methodes

            public void AddProduct(ProductListElement NewProduct)
            {
                if (this.Products == null)
                Products = new List<ProductListElement>();

                this.Products.Add(NewProduct);
                
            }

            public void DeleteProduct(string ProductId)
            {
                if (this.Products == null)
                    return;
                this.Products.RemoveAt(this.Products.FindIndex(SingleProduct => SingleProduct.ProductId == ProductId));
            }

            #endregion









    }
}
