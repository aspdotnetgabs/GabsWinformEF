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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var valid = User.Authenticate(txtLoginEmail.Text, txtLoginPassword.Text);
            if(valid)
            {
                MessageBox.Show("You have successfully logged in.");
                // Logic for valid login...
            }
            else
                MessageBox.Show("Invalid email and/or password.");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtVerifyPass.Text)
            {
                User newUser = new User();
                newUser.Email = txtEmail.Text;
                newUser.FirstName = txtFirstName.Text;
                newUser.LastName = txtLastName.Text;
                newUser.Phone = txtPhone.Text;
                var user = User.Create(newUser, txtPassword.Text);
                if (user != null)
                {
                    foreach (var textbox in tabRegister.Controls.OfType<TextBox>())
                    {
                        textbox.Text = string.Empty;
                    }
                    MessageBox.Show("You have successfully registered. \nUserId: " + user.Id);
                    // Logic for successful registration...
                }
                else
                    MessageBox.Show("Registration failed.");
            }
            else
                MessageBox.Show("Password is not the same.");

        }
    }
}
