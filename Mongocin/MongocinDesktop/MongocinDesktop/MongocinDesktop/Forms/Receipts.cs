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
    public partial class Receipts : Form
    {
        string selectedReceipt;
        Shop shop;
        List<Receipt> receipts = new List<Receipt>();
        List<ProductListElement> receitProducts = new List<ProductListElement>();
        public Receipts(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Receipts_Load(object sender, EventArgs e)
        {
            
            PopulateINfos();
        }

        private void GetShopReceipts()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Receipt/GetAllReceiptsOfShop/" + shop.Id + "/") as HttpWebRequest;
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
                    receipts = JsonConvert.DeserializeObject<List<Receipt>>(contributorsAsJson);


                }
            }
        }

        private void PopulateINfos()
        {
            GetShopReceipts();
            listViewReceipts.Items.Clear();
            foreach (Receipt op in receipts)
            {
                ProductListElement pe = shop.Products.Find(x => x.ProductId == op.Id);

                ListViewItem item = new ListViewItem(new string[] { op.FullCost.ToString(),op.DateOfBill.ToString(),op.Id.ToString()});

                listViewReceipts.Items.Add(item);
            }
            listViewReceipts.Refresh();
        }

        private void deleteReceiptButton_Click(object sender, EventArgs e)
        {
            try
            {
                selectedReceipt = listViewReceipts.SelectedItems[0].SubItems[2].Text;
                DeleteReceipt();
                PopulateINfos();


            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a warewhouse");
            }
        }

        private void DeleteReceipt()
        {
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Receipt/Delete/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            string postData = "{\"Id\":\"" + selectedReceipt + "\"}";
            using (var streamW = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamW.Write(postData);

                streamW.Flush();
                streamW.Close();

                var response = (HttpWebResponse)webRequest.GetResponse();
            }

            
        }

        private void viewProductsButton_Click(object sender, EventArgs e)
        {
            try
            {
                selectedReceipt = listViewReceipts.SelectedItems[0].SubItems[2].Text;
                receitProducts = receipts.Find(x => x.Id == selectedReceipt).ProductList.ToList();
               
                
                PopulateProducts();


            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a Receipt");
            }
        }

        private void PopulateProducts()
        {
            
            listView1.Items.Clear();
            foreach (ProductListElement op in receitProducts)
            {
                

                ListViewItem item = new ListViewItem(new string[] { op.ProductId.ToString(),op.ProductQuantity.ToString() });

                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void buttonCreateReceipt_Click(object sender, EventArgs e)
        {
            ShopRecept shopRecept = new ShopRecept(shop);
            shopRecept.ShowDialog();
            PopulateINfos();
        }
    }
}
