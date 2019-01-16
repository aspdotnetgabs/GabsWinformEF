using GabsWinformEF.DAL;
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
    public partial class DataBindingDemo : Form
    {
        public DataBindingDemo()
        {
            InitializeComponent();
        }

        private List<Girlfriend> girlfriends = new List<Girlfriend>();


        private void DataBindingDemo_Load(object sender, EventArgs e)
        {
            userBindingSource.DataSource = UserRepository.GetAll().Select(s => new UserViewModel
            {
                Id = s.Id,
                Email = s.Email,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Phone = s.Phone
            }).ToList();

            tsUserSelect.ComboBox.DataSource = userBindingSource;
            tsUserSelect.ComboBox.ValueMember = "Id";
            tsUserSelect.ComboBox.DisplayMember = "FullName";
        }

        private void cboUserSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGFs_Click(object sender, EventArgs e)
        {

            var g1 = new Girlfriend();
            g1.Id = 1;
            g1.Name = "Lanie";
            g1.Facebook = "lanz";
            g1.Phone = "099987483";
            girlfriends.Add(g1);

            var g2 = new Girlfriend();
            g2.Id = 2;
            g2.Name = "Anna";
            g2.Phone = "2447656565";
            girlfriends.Add(g2);

            gfDropdown.DataSource = girlfriends;
            gfDropdown.ValueMember = "Id";
            gfDropdown.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g3 = new Girlfriend();
            g3.Id = int.Parse(txtId.Text);
            g3.Name = txtName.Text;
            g3.Phone = txtPhone.Text;
            girlfriends.Add(g3);
            gfDropdown.Refresh();
        }
    }
}
