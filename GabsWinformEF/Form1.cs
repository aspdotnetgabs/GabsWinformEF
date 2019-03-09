using GabsWinformEF.Models;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(chkChessy.Checked)
            {
                //var od = new OrderDetail();
                //// od.OrderId = the Id of the added order
                //od.MenuName = "Chessy Pizza";
                //od.Price = 150.00d;
                //od.Quantity = txtChessy.Text
                // add to database
            }

            if (chkMeaty.Checked)
            {
                //var od = new OrderDetail();
                //// od.OrderId = the Id of the added order
                //od.MenuName = "Meaty Pizza";
                //od.Price =230.00d;
                //od.Quantity = txtMeaty.Text
                // add to database
            }
        }
    }
}
