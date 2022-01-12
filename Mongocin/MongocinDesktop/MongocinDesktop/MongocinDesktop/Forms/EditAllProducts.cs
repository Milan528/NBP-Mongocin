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
    public partial class EditAllProducts : Form
    {
        Product _product;
        public EditAllProducts(Product product)
        {
            InitializeComponent();
            _product = product;
            textBoxName.Text = _product.Name;
            textBoxPrice.Text = _product.Price;
            richTextBoxDescription.Text = _product.Description;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EditAllProducts_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _product.Price = textBoxPrice.Text;
            _product.Name = textBoxName.Text;
            _product.Description = richTextBoxDescription.Text;
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
            WebRequest webRequest = WebRequest.Create("https://localhost:44382/Product/Edit/");
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            string postData = "{\"Price\":\"" + _product.Price + "\", \"Name\":\"" + _product.Name + "\", \"Description\":\"" + _product.Description + "\", \"Id\":\"" + _product.Id + "\"}";
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
