using MongocinDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongocinDesktop.Forms
{
    public partial class Orders : Form
    {
        Warehouse _warehouse;
        string selectedReceipt;
        List<Order> orders = new List<Order>();
        List<ProductListElement> orderProducts = new List<ProductListElement>();
        public Orders(Warehouse warehouse)
        {
            InitializeComponent();
            _warehouse = warehouse;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateInfos()
        {/*
            GetShopReceipts();
            listViewReceipts.Items.Clear();
            foreach (Order op in orders)
            {
                ProductListElement pe = Warehouse.OrdersList.Find(x => x.ProductId == op.Id);

                ListViewItem item = new ListViewItem(new string[] { op.FullCost.ToString(), op.DateOfBill.ToString(), op.Id.ToString() });

                listViewReceipts.Items.Add(item);
            }
            listViewReceipts.Refresh();*/
        }
        private void editOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = listViewReceipts.SelectedItems[0].SubItems[5].Text;
                Order myOrder = _warehouse.OrdersList.Find(item => item.Id == id);

                EditOrder dialog = new EditOrder(myOrder);
                dialog.ShowDialog();

            }

            catch (Exception ec)
            {
                MessageBox.Show("Select an order");
            }
        }

        private void viewProductsButton_Click(object sender, EventArgs e)
        {

        }
    }
 }

