using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Faker;

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
                var currentUser = User.GetCurrentUser();
                MessageBox.Show("Hello " + currentUser.FirstName + ", you have successfully logged in to the system.");
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

        // PM> Install-Package Faker.Net
        void CreateFakeUser(int howMany = 20)
        {
            for (int i = 0; i < howMany; i++)
            {
                var newUser = new User();
                newUser.FirstName = Faker.Name.First();
                newUser.LastName = Faker.Name.Last();
                newUser.Phone = Faker.Phone.Number();
                newUser.Roles = "fakeuser";
                newUser.Email = newUser.FirstName
                    + Faker.RandomNumber.Next(10, 999)
                    + "@"
                    + Faker.Internet.DomainName();
                string password = newUser.FirstName + "123";
                User.Create(newUser, password);
            }
        }

        private void btnRaffleDraw_Click(object sender, EventArgs e)
        {
            MyDbContext _db = new MyDbContext();
            // List is also an array!
            List<User> userEntries = _db.Users.ToList(); 
            // Create random integer from 0 to total number of Users in the Db
            var rnd = new Random();
            int winningIndex = rnd.Next(0, userEntries.Count);
            // Get the winnder by index. userEntries after all is an array!
            User winningUser = userEntries[winningIndex];
            // Announce the winnder in MessageBox!
            MessageBox.Show("And the winner is... \n\n" 
                + winningUser.FirstName + " " 
                + winningUser.LastName + "!!!");                      
        }
    }
}
