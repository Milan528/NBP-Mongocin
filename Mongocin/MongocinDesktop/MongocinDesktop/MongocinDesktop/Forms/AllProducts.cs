using Newtonsoft.Json.Linq;
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
using Newtonsoft.Json;
using System.Net.Http;

namespace MongocinDesktop.Forms
{
    public partial class AllProducts : Form
    {
        List<Product> _allProducts = new List<Product>();
        public AllProducts()
        {
            InitializeComponent();

        }

        private void AllProducts_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateInfos()
        {

            GetAllProducts();

            listViewProducts.Items.Clear();
            foreach (Product op in _allProducts)
            {
                ListViewItem item = new ListViewItem(new string[] { op.Name.ToString(), op.Price.ToString(), op.Description.ToString(), op.Id.ToString() });

                listViewProducts.Items.Add(item);
            }
            listViewProducts.Refresh();



        }

        private void GetAllProducts()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Product/GetAllProducts/5") as HttpWebRequest;
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
        private void DeleteProduct(string id)
        {   
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Product/Delete/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            string postData = "{\"Id\":\"" + id + "\"}";
            using (var streamW = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamW.Write(postData);

                streamW.Flush();
                streamW.Close();

                var response = (HttpWebResponse)webRequest.GetResponse();
            }

            PopulateInfos();

        }
        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = listViewProducts.SelectedItems[0].SubItems[3].Text;
               
                DeleteProduct(id);
                
               
            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a product");
            }
            
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            AddAllProducts addProduct = new AddAllProducts();
            addProduct.ShowDialog();
            PopulateInfos();
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = listViewProducts.SelectedItems[0].SubItems[3].Text;
                Product myProduct = _allProducts.Find(item => item.Id == id);
                EditAllProducts addProduct = new EditAllProducts(myProduct);
                addProduct.ShowDialog();
                PopulateInfos();
               


            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a product");
            }
        }
    }
}
