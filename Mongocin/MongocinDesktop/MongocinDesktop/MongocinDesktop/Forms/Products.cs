using MongocinDesktop.Models;
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
using Newtonsoft.Json;
namespace MongocinDesktop.Forms
{
    public partial class Products : Form
    {
        int quantity;
        string selectedID;
        Warehouse warehouse;
        List<Product> warehouseProducts = new List<Product>();
        List<Product> _allProducts = new List<Product>();
        public Products(Warehouse warehouse)
        {
            InitializeComponent();
            this.warehouse = warehouse;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            GetAllProducts();
            GetWarehouseProducts();
            PopulateInfos();
           
        }

        private void GetWarehouseProducts()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Warehouse/ReturnAllProductsOfWarehouse/" + warehouse.Id + "/") as HttpWebRequest;
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
                    warehouseProducts = JsonConvert.DeserializeObject<List<Product>>(contributorsAsJson);


                }
            }
        }

        private void GetAllProducts()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Product/GetAllProducts/20") as HttpWebRequest;
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

        private void PopulateInfos()
        {
            listViewProducts.Items.Clear();
            listViewAllProducts.Items.Clear();


            foreach (Product op in warehouseProducts)
            {
                ProductListElement pe = warehouse.Products.Find(x => x.ProductId == op.Id);

                ListViewItem item = new ListViewItem(new string[] { op.Id.ToString(), op.Name.ToString(), pe.ProductQuantity.ToString() });

                listViewProducts.Items.Add(item);
            }
            listViewProducts.Refresh();

            foreach (Product op in _allProducts)
            {

                ListViewItem item = new ListViewItem(new string[] { op.Id.ToString(), op.Name.ToString() });

                listViewAllProducts.Items.Add(item);
            }
            listViewAllProducts.Refresh();

        }

        private void listViewAllProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                selectedID = listViewAllProducts.SelectedItems[0].SubItems[0].Text;
                quantity = int.Parse(textBoxQuantity.Text);


                ProductListElement pe = warehouse.Products.Find(x => x.ProductId == selectedID);
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
                    warehouse.Products.Add(pe1);

                    Product p = _allProducts.Find(x => x.Id == selectedID);
                    warehouseProducts.Add(p);


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
                warehouse.Products.RemoveAll(x => x.ProductId == id);
                warehouseProducts.RemoveAll(x => x.Id == id);


                PopulateInfos();


            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a product");
            }
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Warehouse/Edit/");
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            List<ProductListElement> myProducts = warehouse.Products;
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


           
            string postData = "{\"Name\":\"" + warehouse.Name + "\", \"Address\":\"" + warehouse.Address + "\", \"Id\":\"" + warehouse.Id + "\", \"Products\":" + productString + "}";
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
