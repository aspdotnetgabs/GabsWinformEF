# User Registration and Login 
A very simple membership class library for your .NET/C# application with Entity Framework 6.

## [User.cs](https://raw.githubusercontent.com/aspdotnetgabs/GabsWinformEF/UserAuth/GabsWinformEF/Models/User.cs)
**Properties**

|  Property | Type  |  Description |
|---|---|---|
| Id  |  `int` | A database-generated unique number which identifies the user  |
|  Email | `string`  | Unique username or email  |
|  Password Hash/Salt | `byte[]`  |  Encrypted password data [read only] |
|  LastLogin | Nullable `DateTime`  | The last successful login of the user  |
| Roles  |  `string` | Comma-separated role(s) of a user  |
|  UserProfiles | any  | You can add more user profile data e.g. FirstName, LastName, BirthDate, Gender, Phone, Address, etc  |

**Public Methods**

|  Method |  Type | Description  |
|---|---|---|
| Create(User, strUserPassword)  |  `User` |  Creates new `User`. Return `null` if registration fails |
|  Authenticate(userEmail, userPassword) |  `bool` | Returns `true` if login is valid  |
|  Update(User, *optional* userPassword, *optional* newPassword) | `User`  | Updates the user. This also serves as ChangePassword if parameter userPass and newPass are not empty  |
|  GetAll() | `List<User>`  | Returns all users  |
|  GetUserById(id) | `User`  | Returns `User` by Id |
|  GetUserByEmail(email) | `User`  | Returns `User` by email or username |
|  GetCurrentUser() | `User`  | Returns currently logged-in user |
|  GetUserRoles(id *or* email) | `string[]`  | Returns the roles of user as string array |
|  Deactivate() | `User`  | Disables user from logging in  |
|  Activate() | `User`  | Re-enables user  |

## Usage
Copy paste **User.cs** in your project and set the username and password for the auto-generated default administrator. The code below automatically creates user with username, password, and role set to "admin".

    private const string DEFAULT_ADMIN_LOGIN = "admin";

Then change the type of `_db` instance to your app `DbContext`.

     private static MyDbContext _db = new MyDbContext();

**Create New User**

    public void Register()
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
                MessageBox.Show("You have successfully registered. \nUserId: " + user.Id);
                // Logic for successful registration...
            }
            else
                MessageBox.Show("Registration failed.");
        }
        else
            MessageBox.Show("Password is not the same.");

    }

**Login**

    public void Login()
    {
        var valid = User.Authenticate(txtLoginEmail.Text, txtLoginPassword.Text);
        if(valid)
        {
            var currentUser = User.GetCurrentUser();
            MessageBox.Show("Hello " + currentUser.FirstName + ", you have successfully logged in to the system.");
            // Do what you want to do as login is successful...
        }
        else
            MessageBox.Show("Invalid email and/or password.");
    }
