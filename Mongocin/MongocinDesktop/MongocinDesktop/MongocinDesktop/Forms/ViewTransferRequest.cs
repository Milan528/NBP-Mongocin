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
    public partial class ViewTransferRequest : Form
    {
        Shop shop;
        List<Models.TransferRequest> transfers = new List<Models.TransferRequest>();
        string selectedTransferID;
        public ViewTransferRequest(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;
        }

        private void ViewTransferRequest_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateInfos()
        {
            GetAllTransfers();
            listViewTransferProducts.Items.Clear();

            foreach (Models.TransferRequest op in transfers)
            {
                ListViewItem item = new ListViewItem(new string[] { op.Id.ToString(),op.ShopId.ToString(),op.StorageId.ToString() });

                listViewTransferProducts.Items.Add(item);
            }
            listViewTransferProducts.Refresh();

        }
        private void GetAllTransfers()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/TransferRequest/GetAllTransfersOfShop/"+shop.Id+"/") as HttpWebRequest;
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
                    transfers = JsonConvert.DeserializeObject<List<Models.TransferRequest>>(contributorsAsJson);


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                selectedTransferID = listViewTransferProducts.SelectedItems[0].SubItems[0].Text;
                Models.TransferRequest myTransfer = transfers.Find(item => item.Id == selectedTransferID);

                
                PopulateProducts(myTransfer.ProductList);
            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a request");
            }
        }

        private void PopulateProducts(List<ProductListElement> list)
        {
            listView1.Items.Clear();

            foreach (ProductListElement op in list)
            {
                ListViewItem item = new ListViewItem(new string[] { op.ProductId.ToString(),op.ProductQuantity.ToString() });

                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                selectedTransferID = listViewTransferProducts.SelectedItems[0].SubItems[0].Text;
                DeleteTransfer();
                PopulateInfos();

                
            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a request");
            }
        }

        private void DeleteTransfer()
        {
            try
            {
                WebRequest webRequest = WebRequest.Create("https://localhost:44382/TransferRequest/Delete/");
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";



                string postData = "{\"Id\":\"" + selectedTransferID + "\"}";
                using (var streamW = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamW.Write(postData);

                    streamW.Flush();
                    streamW.Close();

                    var response = (HttpWebResponse)webRequest.GetResponse();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
