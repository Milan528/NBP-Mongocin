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
    public partial class EditOrder : Form
    {
        Order _order;
        public EditOrder(Order order)
        {
            InitializeComponent();
            _order = order;
            textBoxCustomerAddress.Text = _order.CustomerAddress;
            textBoxCustomerNmae.Text = _order.CustomerName;
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/order/Edit/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            string postData = "{\"Id\":\"" + _order.Id + "\", \"CustomerName\":\"" + _order.CustomerName + "\", \"CustomerAddress\":\"" + _order.CustomerAddress + "\",  \"StorageId\":\"" + _order.StorageId + "\",  \"DateOfBill\":\"" + _order.DateOfBill + "\"}";
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
