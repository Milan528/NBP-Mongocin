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
    public partial class HandleTransferRequest : Form
    {
        string selectedTransferID;
        Warehouse warehouse;
        List<Models.TransferRequest> transferRequests = new List<Models.TransferRequest>();
        public HandleTransferRequest(Warehouse warehouse)
        {
            InitializeComponent();
            this.warehouse = warehouse;
        }

        private void HandleTransferRequest_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }
        private void PopulateInfos()
        {
            GetWarehouseRequest();
            listViewTransferProducts.Items.Clear();

            foreach (Models.TransferRequest op in transferRequests)
            {
                ListViewItem item = new ListViewItem(new string[] { op.Id.ToString(), op.ShopId.ToString(), op.StorageId.ToString(),op.State.ToString() });

                listViewTransferProducts.Items.Add(item);
            }
            listViewTransferProducts.Refresh();
        }

        private void GetWarehouseRequest()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/TransferRequest/GetAllTransfersOfWarehouse/" + warehouse.Id + "/") as HttpWebRequest;
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
                    transferRequests = JsonConvert.DeserializeObject<List<Models.TransferRequest>>(contributorsAsJson);


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHandle_Click(object sender, EventArgs e)
        {
            try
            {
                selectedTransferID = listViewTransferProducts.SelectedItems[0].SubItems[0].Text;
                string state= listViewTransferProducts.SelectedItems[0].SubItems[3].Text;
                if (state == StateEnum.Delivered.ToString())
                {
                    MessageBox.Show("Transfer has been delivered");
                    return;
                }
                else
                {
                    HandleTransfer();
                    PopulateInfos();
                }
                


            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a request");
            }
        }

        private void HandleTransfer()
        {
            try
            {
                WebRequest webRequest = WebRequest.Create("https://localhost:44382/TransferRequest/DoTheRequest");
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";



                string postData = "{\"RequestId\":\"" + selectedTransferID + "\"}";
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
