using MongocinDesktop.Models;
using Newtonsoft.Json;
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

namespace MongocinDesktop.Forms
{
    public partial class ShopProducts : Form
    {
        int quantity;
        string selectedID;
        Shop shop;
        List<Product> shopProducts = new List<Product>();
        List<Product> _allProducts = new List<Product>();
        public ShopProducts(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;

        }

        private void ShopProducts_Load(object sender, EventArgs e)
        {
            GetAllProducts();
            GetShopProducts();
            PopulateInfos();
        }

        private void PopulateInfos()
        {
            
            listViewProducts.Items.Clear();
            listViewAllProducts.Items.Clear();
           

            foreach (Product op in shopProducts)
            {
                ProductListElement pe = shop.Products.Find(x => x.ProductId == op.Id);

                ListViewItem item = new ListViewItem(new string[] { op.Id.ToString(),op.Name.ToString(),pe.ProductQuantity.ToString()});

                listViewProducts.Items.Add(item);
            }
            listViewProducts.Refresh();

            foreach(Product op in _allProducts)
            {

                ListViewItem item = new ListViewItem(new string[] { op.Id.ToString(),op.Name.ToString()});

                listViewAllProducts.Items.Add(item);
            }
            listViewAllProducts.Refresh();


        }

        private void GetShopProducts()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Shop/ReturnAllProductsOfShop/"+shop.Id+"/") as HttpWebRequest;
            if (webRequest == null)
            {
                return;
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    shopProducts = JsonConvert.DeserializeObject<List<Product>>(contributorsAsJson);


                }
            }
        }

        private void GetAllProducts()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Product/GetAllProducts/6") as HttpWebRequest;
            if (webRequest == null)
            {
                return;
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    _allProducts = JsonConvert.DeserializeObject<List<Product>>(contributorsAsJson);


                }
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                selectedID = listViewAllProducts.SelectedItems[0].SubItems[0].Text;
                quantity = int.Parse(textBoxQuantity.Text);


                ProductListElement pe = shop.Products.Find(x => x.ProductId == selectedID);
                if (pe != null)
                {
                    pe.ProductQuantity = pe.ProductQuantity + quantity;
                    PopulateInfos();
                }
                else
                {
                    ProductListElement pe1 = new ProductListElement();
                    pe1.ProductId = selectedID;
                    pe1.ProductQuantity = quantity;
                    shop.Products.Add(pe1);

                    Product p = _allProducts.Find(x => x.Id == selectedID);
                    shopProducts.Add(p);


                    PopulateInfos();


                }

               
            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a warewhouse");
            }
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = listViewProducts.SelectedItems[0].SubItems[0].Text;
                shop.Products.RemoveAll(x => x.ProductId == id);
                shopProducts.RemoveAll(x => x.Id == id);


                PopulateInfos();


            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a warewhouse");
            }
        }

        private void editProductButton_Click(object sender, EventArgs e)
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
    }
}
