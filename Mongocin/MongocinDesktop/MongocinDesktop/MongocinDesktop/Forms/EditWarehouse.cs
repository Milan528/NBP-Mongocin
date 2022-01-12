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

namespace MongocinDesktop.Forms
{
    public partial class EditWarehouse : Form
    {
        Warehouse _wareHouse;
        public EditWarehouse(Warehouse warehouse)
        {
            InitializeComponent();
            _wareHouse = warehouse;
            nameTextBox.Text = _wareHouse.Name;
            addressTextBox.Text = _wareHouse.Address;
        }

        private void EditWarehouse_Load(object sender, EventArgs e)
        {

        }

        private void saveWarehouseChangesButton_Click(object sender, EventArgs e)
        {
            _wareHouse.Address = addressTextBox.Text;
            _wareHouse.Name = nameTextBox.Text;
            
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
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Warehouse/Edit/");
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            List<ProductListElement> myProducts = _wareHouse.Products;
            string productString = "[";
           
            string data;
            for(int i=0;i< myProducts.Count;i++)
            {
                if(i != myProducts.Count-1)
                  data = "{\"ProductId\":\"" + myProducts[i].ProductId + "\", \"ProductQuantity\":\"" + myProducts[i].ProductQuantity + "\"},";
                else
                  data = "{\"ProductId\":\"" + myProducts[i].ProductId + "\", \"ProductQuantity\":\"" + myProducts[i].ProductQuantity + "\"}";
                
                productString = productString + data;

            }
            productString = productString + "]";


            /*

            List<string> myOrders = _wareHouse.Orders;
            string orderString = "[";

            string orderData;
            if (myOrders != null)
            {
                for (int i = 0; i < myOrders.Count; i++)
                {
                    if (i != myProducts.Count - 1)
                        orderData = "\"" + myOrders[i] + "\",";
                    else
                        orderData = "\"" + myOrders[i] + "\"";

                    orderString = orderString + orderData;

                }
            }

            orderString = orderString + "]";*/

            string postData = "{\"Name\":\"" + _wareHouse.Name + "\", \"Address\":\"" + _wareHouse.Address + "\", \"Id\":\"" + _wareHouse.Id + "\", \"Products\":"+productString+"}";
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
            Products p = new Products(_wareHouse);
            p.ShowDialog();

        }

        private void viewOrdersButton_Click(object sender, EventArgs e)
        {
            Orders p = new Orders(_wareHouse);
            p.ShowDialog();
        }

        private void buttonHandleRequest_Click(object sender, EventArgs e)
        {
            HandleTransferRequest rq = new HandleTransferRequest(_wareHouse);
            rq.ShowDialog();
        }
    }
}
