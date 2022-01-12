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
    public partial class EditShop : Form
    {
        Shop _shop;
        public EditShop(Shop shop)
        {
            InitializeComponent();
            this._shop = shop;
            shopNameTextBox.Text = _shop.Name;
            shopAddressTextBox.Text = _shop.Address;
        }

        private void EditShop_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ShopProducts shopProducts = new ShopProducts(_shop);
            shopProducts.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveShopChangesButton_Click(object sender, EventArgs e)
        {
            _shop.Address = shopAddressTextBox.Text;
            _shop.Name = shopNameTextBox.Text;

            try
            {
                SaveProduct();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            this.Close();
        }
        private void SaveProduct()
        {
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Shop/Edit/");
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            List<ProductListElement> myProducts = _shop.Products;
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


            /*
            List<string> myReceipts = _shop.Receipts;
            string receiptString = "[";


            string orderData;
            if (myReceipts != null)
            {
                for (int i = 0; i < myReceipts.Count; i++)
                {
                    if (i != myProducts.Count - 1)
                        orderData = "\"" + myReceipts[i] + "\",";
                    else
                        orderData = "\"" + myReceipts[i] + "\"";

                    receiptString = receiptString + orderData;

                }
            }

            receiptString = receiptString + "]";
            */
            string postData = "{\"Name\":\"" + _shop.Name + "\", \"Address\":\"" + _shop.Address + "\", \"Id\":\"" + _shop.Id + "\", \"Products\":" + productString + "}";
            using (var streamW = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamW.Write(postData);

                streamW.Flush();
                streamW.Close();

                var response = (HttpWebResponse)webRequest.GetResponse();
            }

        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            TransferRequest transferRequest = new TransferRequest(_shop.Id);
            transferRequest.ShowDialog();
        }

        private void buttonViewRequest_Click(object sender, EventArgs e)
        {
            ViewTransferRequest transferRequest = new ViewTransferRequest(_shop);
            transferRequest.ShowDialog();

        }

        private void viewReceiptsButton_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts(_shop);
            receipts.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            var webRequest = WebRequest.Create("https://localhost:44382/Shop/CalculateFullValueOfAllProducts/" + _shop.Id + "/") as HttpWebRequest;
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
                    value = JsonConvert.DeserializeObject<int>(contributorsAsJson);


                }
            }

            MessageBox.Show(value.ToString());
        }
    }
}
