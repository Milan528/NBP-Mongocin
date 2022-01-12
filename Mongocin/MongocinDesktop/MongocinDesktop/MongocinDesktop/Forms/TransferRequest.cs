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
    public partial class TransferRequest : Form
    {
        string shopID;
        string warehouseID;
        List<ProductListElement> transferProducts = new List<ProductListElement>();
        List<Warehouse> warehouses;
        List<Product> products;
        public TransferRequest(string shopID)
        {
            InitializeComponent();
            this.shopID = shopID;
            
        }

        private void listViewStorage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TransferRequest_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateInfos()
        {
            GetAllWarehouses();
            GetAllProducts();

            listViewStorage.Items.Clear();

            foreach (Warehouse op in warehouses)
            {
                ListViewItem item = new ListViewItem(new string[] { op.Name.ToString(), op.Id.ToString() });

                listViewStorage.Items.Add(item);
            }
            listViewStorage.Refresh();

            listViewProducts.Items.Clear();

            foreach (Product op in products)
            {
                ListViewItem item = new ListViewItem(new string[] { op.Name.ToString(), op.Price.ToString(), op.Description.ToString(), op.Id.ToString() });

                listViewProducts.Items.Add(item);
            }
            listViewProducts.Refresh();
        }
        private void GetAllWarehouses()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Warehouse/GetAllWarehouses/5") as HttpWebRequest;
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
                    warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(contributorsAsJson);


                }
            }
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
                    products = JsonConvert.DeserializeObject<List<Product>>(contributorsAsJson);


                }
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string id = listViewProducts.SelectedItems[0].SubItems[3].Text;
                int quantity = int.Parse(textBoxQuantity.Text);
                ProductListElement pl = new ProductListElement();
                pl.ProductId = id;
                pl.ProductQuantity = quantity;

                transferProducts.Add(pl);
                PopulateTransferProduct();

                
            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a product");
            }
        }

        private void PopulateTransferProduct()
        {
            listViewTransferProducts.Items.Clear();

            foreach (ProductListElement op in transferProducts)
            {
                ListViewItem item = new ListViewItem(new string[] { op.ProductId.ToString(), op.ProductQuantity.ToString() });

                listViewTransferProducts.Items.Add(item);
            }
            listViewTransferProducts.Refresh();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                warehouseID = listViewStorage.SelectedItems[0].SubItems[1].Text;
                if (transferProducts.Count == 0)
                {
                    MessageBox.Show("Insert transfer products");
                    return;
                }

                SaveProduct();

            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a Storage");
            }
        }

        private void SaveProduct()
        {
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/TransferRequest/Create/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            
            string productString = "[";

            string data;
            for (int i = 0; i < transferProducts.Count; i++)
            {
                if (i != transferProducts.Count - 1)
                    data = "{\"ProductId\":\"" + transferProducts[i].ProductId + "\", \"ProductQuantity\":\"" + transferProducts[i].ProductQuantity + "\"},";
                else
                    data = "{\"ProductId\":\"" + transferProducts[i].ProductId + "\", \"ProductQuantity\":\"" + transferProducts[i].ProductQuantity + "\"}";

                productString = productString + data;

            }
            productString = productString + "]";

            string postData = "{\"StorageId\":\"" + warehouseID + "\", \"ShopId\":\"" + shopID + "\", \"State\":\"0\", \"ProductList\":" + productString + "}";
            using (var streamW = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamW.Write(postData);

                streamW.Flush();
                streamW.Close();

                var response = (HttpWebResponse)webRequest.GetResponse();
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            transferProducts.RemoveRange(0, transferProducts.Count-1);
            listViewTransferProducts.Items.Clear();

        }
    }
}
