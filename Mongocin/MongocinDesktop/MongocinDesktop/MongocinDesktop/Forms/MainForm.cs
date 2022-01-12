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
    public partial class MainForm : Form
    {
        List<Shop> _shops = new List<Shop>();
        List<Warehouse> _warehouses = new List<Warehouse>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateInfos()
        {
            GetAllWarehouses();
            GetAllShops();
            
            listViewShop.Items.Clear();
          
            foreach (Shop op in _shops)
            {
                ListViewItem item = new ListViewItem(new string[] { op.Name.ToString(),op.Id.ToString()});

                listViewShop.Items.Add(item);
            }
            listViewShop.Refresh();
            
            listViewWarehouse.Items.Clear();
            
            foreach (Warehouse op in _warehouses)
            {
                ListViewItem item = new ListViewItem(new string[] {op.Name.ToString() ,op.Id.ToString()});

                listViewWarehouse.Items.Add(item);
            }
            listViewWarehouse.Refresh();
        }

        private void buttonShop_Click(object sender, EventArgs e)
        {
            try
            {
                string id = listViewShop.SelectedItems[0].SubItems[1].Text;
                Shop myShop = _shops.Find(item => item.Id == id);

                EditShop editShop = new EditShop(myShop);
                editShop.ShowDialog();
                PopulateInfos();
            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a shop");
            }
        }

        private void buttonWarehouse_Click(object sender, EventArgs e)
        {
            try
            {
                string id = listViewWarehouse.SelectedItems[0].SubItems[1].Text;
                Warehouse myWarehouse = _warehouses.Find(item => item.Id == id);

                EditWarehouse editWarehouse = new EditWarehouse(myWarehouse);
                editWarehouse.ShowDialog();
                PopulateInfos();
            }
            catch (Exception ec)
            {
                MessageBox.Show("Select a warewhouse");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllProducts allProducts = new AllProducts();
            allProducts.ShowDialog();
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
                    _warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(contributorsAsJson);


                }
            }
        }
        private void GetAllShops()
        {
            var webRequest = WebRequest.Create("https://localhost:44382/Shop/GetAllShop/5") as HttpWebRequest;
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
                    _shops = JsonConvert.DeserializeObject<List<Shop>>(contributorsAsJson);


                }
            }
        }
    }
}
