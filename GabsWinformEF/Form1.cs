using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabsWinformEF
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> productList = new Dictionary<string, double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DTI SRP: https://drive.google.com/file/d/1ZEqNOwsCTz_YAfdW3FUmlVrHjgU83o5A/view
            productList.Add(string.Empty, 0.00f);
            productList.Add("Argentina 150g", 30.95);
            productList.Add("Nescafe Classic 25g", 19.70);
            productList.Add("Young’s Town (Easy Open Can)", 16.50);
            productList.Add("Alaska Sweetened Filled Milk", 56.50);
            productList.Add("Silver Swan 350ml", 13.50);
            productList.Add("Surf Bar (kalamansi)", 21.00d);
            productList.Add("Wilkins Pure 1L", 22.00d);

            comboItemName.DisplayMember = "key";
            comboItemName.DataSource = productList.ToList(); // Convert Dictionary to List

        }

        private void comboItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedText = comboItemName.Text;
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                txtPrice.Text = productList[selectedText].ToString();
                CalculteTotal();
                txtQuantity.Focus();
            }

        }

        private void CalculteTotal()
        {
            if(!string.IsNullOrEmpty(txtQuantity.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                double qty = double.Parse(txtQuantity.Text);
                double price = double.Parse(txtPrice.Text);
                double amount = qty * price;
                txtAmount.Text = amount.ToString();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculteTotal();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                var newItem = new POSItem();
                newItem.ItemName = comboItemName.Text;
                newItem.Quantity = double.Parse(txtQuantity.Text);
                newItem.Price = double.Parse(txtPrice.Text);
                newItem.Amount = double.Parse(txtAmount.Text);
                bindingSource1.Add(newItem);

                txtTotal.Text = (double.Parse(txtTotal.Text) + double.Parse(txtAmount.Text)).ToString();
            }

            ClearTextBoxes();
            comboItemName.Focus();
        }

        private void ClearTextBoxes()
        {
            comboItemName.Text = string.Empty;
            txtQuantity.Text = "1";
            txtPrice.Text = string.Empty;
            txtAmount.Text = string.Empty;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTotal.Text) && !string.IsNullOrEmpty(txtCash.Text))
            {
                double total = double.Parse(txtTotal.Text);
                double cash = double.Parse(txtCash.Text);
                if(cash >= total)
                {
                    double change = cash - total;
                    string formattedChange = String.Format("{0:c}", change);
                    MessageBox.Show("Your change is " + formattedChange + ". \n\nThank you for shopping with us.");


                    ClearTextBoxes();

                    txtTotal.Text = "0";
                    txtCash.Text = string.Empty;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Kulang imong bayad!");
                    txtCash.Focus();
                }

            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new FormTransactions().Show();
        }
    }
}
