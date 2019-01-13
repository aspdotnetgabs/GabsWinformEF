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
        }
    }
}
