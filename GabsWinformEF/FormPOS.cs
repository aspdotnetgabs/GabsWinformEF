using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabsWinformEF
{
    public partial class FormPOS : Form
    {
        Dictionary<string, double> productList = new Dictionary<string, double>();

        public FormPOS()
        {
            InitializeComponent();
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            productList.Add("", 0.00);
            productList.Add("Argentina", 10.00);
            productList.Add("Bulad", 50.50);
            productList.Add("Bugas", 48.00);

            //comboItemName.ValueMember = "Key";
            comboItemName.DisplayMember = "Key";
            comboItemName.DataSource = productList.ToList();

        }

        private void comboItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var price = productList[comboItemName.Text];
            var qty = double.Parse(txtQty.Text);
            var amount = qty * price;
            txtPrice.Text = price.ToString();
            txtAmount.Text = amount.ToString();
            txtQty.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new ItemPOS();
            item.ItemName = comboItemName.Text;
            item.Quantity = double.Parse(txtQty.Text);
            item.Price = double.Parse(txtPrice.Text);
            item.Amount = double.Parse(txtAmount.Text);

            bindingSource1.Add(item);
            dataGridView1.Refresh();
        }
    }
}
