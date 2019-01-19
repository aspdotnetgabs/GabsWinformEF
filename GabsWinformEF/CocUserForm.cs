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
    public partial class CocUserForm : Form
    {
        private static List<COCUser> users = new List<COCUser>();

        public CocUserForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var user = new COCUser();
            user.Name = txtName.Text;
            user.Email = txtEmail.Text;
            user.Phone = txtPhone.Text;
            users.Add(user);
            bindingSource1.DataSource = (List<COCUser>) users;
            dataGridView1.Refresh();

        }

        private void CocUserForm_Load(object sender, EventArgs e)
        {            
            bindingSource1.DataSource = users;
        }
    }
}
