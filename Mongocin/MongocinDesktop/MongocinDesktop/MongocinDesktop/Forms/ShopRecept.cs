using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongocinDesktop.Models;

namespace MongocinDesktop.Forms
{
    public partial class ShopRecept : Form
    {

        string selectedID;
        int selectedQuantity;
        int quantityToAdd;

        Shop shop;
        List<ProductListElement> currentProducts = new List<ProductListElement>();
       

        public ShopRecept(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;
        }
        
        private void ShopRecept_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateInfos()
        {

            listViewCurrentProducts.Items.Clear();
            listViewProductsInShop.Items.Clear();


            foreach (ProductListElement op in currentProducts)
            {
               

                ListViewItem item = new ListViewItem(new string[] { op.ProductId.ToString(), op.ProductQuantity.ToString() });

                listViewCurrentProducts.Items.Add(item);
            }
            listViewCurrentProducts.Refresh();

            foreach (ProductListElement op in shop.Products)
            {

                ListViewItem item = new ListViewItem(new string[] { op.ProductId.ToString(), op.ProductQuantity.ToString() });

                listViewProductsInShop.Items.Add(item);
            }
            listViewProductsInShop.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                CreateReceipt();
                UpdateShop();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                selectedID = listViewProductsInShop.SelectedItems[0].SubItems[0].Text;
                selectedQuantity = int.Parse(listViewProductsInShop.SelectedItems[0].SubItems[1].Text);
                quantityToAdd = int.Parse(textBoxQuantity.Text);

                


                if(selectedQuantity >= quantityToAdd)
                {
                    
                    ProductListElement current = currentProducts.Find(x=>x.ProductId==selectedID);
                    if (current == null)
                    {
                        ProductListElement product = new ProductListElement();
                        product.ProductId = selectedID;
                        product.ProductQuantity = quantityToAdd;
                        currentProducts.Add(product);
                    }
                    else
                    {
                        current.ProductQuantity = current.ProductQuantity + quantityToAdd;
                    }

                    
                    

                    selectedQuantity -= quantityToAdd;
                    shop.Products.Find(x => x.ProductId == selectedID).ProductQuantity = selectedQuantity;
                    PopulateChangedShop();
                    PopulateCurrentProducts();
                }
                else
                {
                    MessageBox.Show("Inserted quantity is greater than selected");
                }
                

            }
            catch(Exception)
            {
                MessageBox.Show("Select a product");
            }
           
        }
        private void PopulateCurrentProducts()
        {
            listViewCurrentProducts.Items.Clear();
            foreach (ProductListElement op in currentProducts)
            {
                ListViewItem item = new ListViewItem(new string[] { op.ProductId.ToString(), op.ProductQuantity.ToString() });

                listViewCurrentProducts.Items.Add(item);
            }
            listViewCurrentProducts.Refresh();
        }
        private void PopulateChangedShop()
        {
            listViewProductsInShop.Items.Clear();
            foreach (ProductListElement op in shop.Products)
            {
                ListViewItem item = new ListViewItem(new string[] { op.ProductId.ToString(), op.ProductQuantity.ToString() });

                listViewProductsInShop.Items.Add(item);
            }
            listViewProductsInShop.Refresh();
        }
        private void UpdateShop()
        {
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Shop/Edit/");
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            List<ProductListElement> myProducts = shop.Products;
            string productString = "[";

            string data;
            for (int i = 0; i < myProducts.Count; i++)
            {
                if (i != myProducts.Count - 1)
                    data = "{\"ProductId\":\"" + myProducts[i].ProductId + "\", \"ProductQuantity\":\"" + myProducts[i].ProductQuantity + "\"},";
                else
                    data = "{\"ProductId\":\"" + myProducts[i].ProductId + "\", \"ProductQuantity\":\"" + myProducts[i].ProductQuantity + "\"}";

                productString = productString + data;

            }
            productString = productString + "]";


          
            
            string postData = "{\"Name\":\"" + shop.Name + "\", \"Address\":\"" + shop.Address + "\", \"Id\":\"" + shop.Id + "\", \"Products\":" + productString + "}";
            using (var streamW = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamW.Write(postData);

                streamW.Flush();
                streamW.Close();

                var response = (HttpWebResponse)webRequest.GetResponse();
            }

        }

        private void CreateReceipt()
        {
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Receipt/Create/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            List<ProductListElement> myProducts = currentProducts;
            string productString = "[";

            string data;
            for (int i = 0; i < myProducts.Count; i++)
            {
                if (i != myProducts.Count - 1)
                    data = "{\"ProductId\":\"" + myProducts[i].ProductId + "\", \"ProductQuantity\":\"" + myProducts[i].ProductQuantity + "\"},";
                else
                    data = "{\"ProductId\":\"" + myProducts[i].ProductId + "\", \"ProductQuantity\":\"" + myProducts[i].ProductQuantity + "\"}";

                productString = productString + data;

            }
            productString = productString + "]";


           
            string postData = "{\"Date\":\"" + DateTime.Now + "\", \"ShopId\":\"" + shop.Id + "\", \"ProductList\":" + productString + "}";
            using (var streamW = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamW.Write(postData);

                streamW.Flush();
                streamW.Close();

                var response = (HttpWebResponse)webRequest.GetResponse();
            }

        }
    }

}
