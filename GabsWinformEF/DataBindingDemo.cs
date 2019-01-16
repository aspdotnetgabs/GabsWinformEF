using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
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
        private static DataBindingDemo _instance;

        public DataBindingDemo()
        {
            InitializeComponent();
            _instance = this;
        }

        private void DataBindingDemo_Load(object sender, EventArgs e)
        {
        }

        public static IFirebaseClient RefreshDatagrid()
        {
            try
            {
                var userFirebaseRepo =
                    new UserFirebaseRepository(Program.FirebaseApiKey, Program.FirebaseDatabaseURL, "users");


                _instance.userBindingSource.DataSource = userFirebaseRepo.GetAll().Select(s => new UserViewModel
                {
                    Id = s.Id,
                    Email = s.Email,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Phone = s.Phone
                }).ToList();

                return userFirebaseRepo.GetFirebaseClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async void btnFirebaseConnect_Click(object sender, EventArgs e)
        {
            Program.FirebaseApiKey = txtApiKey.Text;
            Program.FirebaseDatabaseURL = txtDatabaseURL.Text;


            var fireClient = RefreshDatagrid();

            var eventR = await UserFirebaseRepository.Listen(fireClient, "user");

            var login = new Login();
            login.Show();
        }
    }
}
