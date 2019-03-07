# User Registration and Login 
A very simple membership class library for your .NET/C# application with Entity Framework 6.

## User.cs
**Properties**
|  Property | Type  |  Description |
|---|---|---|
| Id  |  `int` | A database-generated unique number which identifies the user  |
|  Email | `string`  | Unique username or email  |
|  Password Hash/Salt | `byte[]`  |  Encrypted password data read only |
|  LastLogin | Nullable `DateTime`  | The last successful login of the user  |
| Roles  |  `string` | Comma-separated role(s) of a user  |
|  UserProfiles | any  | You can add more user profile data e.g. FirstName, LastName, BirthDate, Gender, Phone, Address, etc  |

**Public Methods**
|  Method |  Type | Description  |
|---|---|---|
| Create(User, strUserPassword)  |  `User` |  Creates new `User`. Return `null` if registration fails |
|  Authenticate(userEmail, userPassword) |  `bool` | Returns `true` if user is valid  |
|  Update(User, *optional* userPassword, *optional* newPassword) | `User`  | Updates the user. This also also serves as ChangePassword if userPass and newPass are filled  |
|  GetAll() | `List<User>`  | Returns all users  |
|  GetUserById(id) | `User`  | Returns `User` by Id |
|  GetUserByEmail(email) | `User`  | Returns `User` by email or username |
|  GetCurrentUser() | `User`  | Returns currently logged-in user |
|  GetUserRoles(id *or* email) | `string[]`  | Returns the roles of user as string array |
|  Deactivate() | `User`  | Disables user from logging in  |
|  Activate() | `User`  | Re-enables user  |
