
 RACEDAY — Part 3 MVC Consume

RACEDAY is an ASP.NET Core MVC web app that consumes a separate Part 2 Web API to manage users, races, and dashboards for Organisers and Participants.

 Features

Register / Login — Users register with Full Name, Email, Password, and Role (Organiser / Participant)
 Role-based Dashboards
    - Organiser Dashboard
    - Participant Dashboard
- Profile— View and update profile (Full Name, Email)
- Browse / Races — Browse races created by organisers
- Demo Profile — Quick demo login for testing (removed from Register page to avoid duplicate form bug)

 Tech Stack

- ASP.NET Core MVC (.NET 8 / .NET 9)
- C# — Controllers, Models, Services
- Razor Views (.cshtml)
- HttpClient — `ApiServices_Users` calls the Part 2 API
- Session — Stores `userID` and `email` after login
- Part 2 Web API — `api/UsersController/*` endpoints

projepart3_mvc_consume/
├── Controllers/
│   ├── UsersController.cs       -Register, Login
│   ├── HomeController.cs
│   ├── OrganiserController.cs
│   └── ParticipantController.cs
├── Models/
│   └── Users.cs                 -userID, fullName, email, password, role
├── Services/
│   ├── ApiServices_Users.cs     -store_user, login_user, get_profile, update_profile
│   └── ApiServices_categories.cs
├── Views/
│   ├── Users/
│   │   ├── Register.cshtml      -ONLY ONE Register form - do not add a second demo form
│   │   └── Login.cshtml
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Organiser/
│   └── Participant/
├── wwwroot/
│   ├── css/site.css
│   └── js/site.js
├── Program.cs                  -HttpClient BaseAddress + Session setupct structure

Register Flow
User fills: Full Name, Email, Password, RoleUsersController.Register(Users user) (POST) calls ApiServices_Users.store_user(user)Service builds URL:

User enters Email + PasswordUsersController.Login calls login_user(email, password)If API returns Login Successfull, MVC saves:csharp   HttpContext.Session.SetString("userID", userID);
   HttpContext.Session.SetString("email", email);If message contains organiser, redirect to Organiser Dashboard, else Participant Dashboard
   
Author
Project: RACEDAY Part 3 
Student: Kagisho Phaladi: 
stack: ASP.NET Core MVC + Web API
   

