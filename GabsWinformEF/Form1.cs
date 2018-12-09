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
        MyDbContext _db = new MyDbContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var contact = new Contact
            {
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            };

            _db.Contacts.Add(contact);
            _db.SaveChanges();

            dataGridContacts.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contactBindingSource.DataSource = _db.Contacts.ToList();
        }

    }
}
