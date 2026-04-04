# AC-Judge

• AC Judge is an online platform that accurately simulates a real judge like [[codeforce](https://codeforces.com/), [atcoder](https://atcoder.jp/home), [leetcode](https://leetcode.com/)]

• By accessing problems from various online judges, AC Judge mimics the submission process of a typical online judge.

• AC Judge monitors your problem-solving performance and provides comprehensive statistics across all other online judges you have used.

## Getting Started

To get started with AC Judge, follow these simple steps:

1. Clone the repository
2. Configure your database connection in `appsettings.json`
3. Run the application using Visual Studio or the .NET CLI

## Features

- **Problem Management**: Access problems from multiple online judges (Codeforces, AtCoder, LeetCode)
- **Submission System**: Submit solutions and get real-time feedback
- **User Authentication**: Secure sign up and sign in functionality
- **Blog System**: Create and view blog posts
- **Contests**: Create and participate in coding contests
- **Groups**: Create and join groups for collaborative problem-solving
- **Statistics**: Track your performance across different online judges
- **Problem Solutions**: View and share problem solutions

## Technologies used 
- [ASP.NET CORE](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [Entity FrameWork Core](https://learn.microsoft.com/en-us/ef/)
- [Selenium WebDriver](https://www.selenium.dev/documentation/webdriver/) for web scraping
- [Bootstrap](https://getbootstrap.com/) for UI styling
- [jQuery](https://jquery.com/) for client-side scripting

## Installation/Setup

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or any compatible IDE

### Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/AC-Judge.git
   cd AC-Judge
   ```

2. **Configure Database Connection**
   
   Open `ACJudge/appsettings.json` and update the connection string:
   ```json
   "ConnectionStrings": {
     "UserAccountsContextConnection": "Server=your_server;Database=ACJudge;User Id=your_username;Password=your_password;Trusted_Connection=False;MultipleActiveResultSets=True;"
   }
   ```

3. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

4. **Apply Database Migrations**
   ```bash
   cd ACJudge
   dotnet ef database update
   ```

5. **Run the Application**
   
   Using .NET CLI:
   ```bash
   dotnet run
   ```
   
   Or using Visual Studio:
   - Open the solution file `ACJudge.sln`
   - Press F5 to start debugging

6. **Access the Application**
   
   Navigate to `https://localhost:5001` (or the port shown in your console) in your browser.

## Project Structure

```
AC-Judge/
├── ACJudge/                    # Main web application
│   ├── Areas/                   # Identity and authentication area
│   │   └── Identity/           # User authentication pages
│   ├── Controllers/            # Application controllers
│   ├── Data/                   # Database contexts and models
│   ├── Dependency/             # Dependency injection setup
│   ├── ExtensionMethods/       # Custom extension methods
│   ├── Migrations/             # Database migrations
│   ├── ViewModels/             # View models for views
│   ├── Views/                  # Razor views
│   ├── wwwroot/               # Static files (CSS, JS, images)
│   ├── Program.cs              # Application entry point
│   ├── Startup.cs              # Application startup configuration
│   └── appsettings.json        # Application configuration
│
├── GetProblemsAPI/             # API for fetching problems from online judges
│   ├── Controllers/            # API controllers
│   ├── ProblemInfo.cs          # Problem information model
│   ├── SeleniumOperations.cs   # Selenium web scraping operations
│   ├── SubmissionStatus.cs     # Submission status tracking
│   └── Program.cs              # API entry point
│
├── ACJudge.sln                # Solution file
├── ERD.drawio                 # Entity Relationship Diagram
├── UML.drawio                 # UML Diagram
└── README.md                  # Project documentation
```
## Project Demo Video
[Here](https://youtu.be/T-FBJJw4nb8)
## Screen Shots
### Database
![databaseDiagram](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/41c3c269-3d21-413e-aff6-59dc29747b76)
![databaseDigram1](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/65ea2847-78a9-4f45-b06b-292db59940fc)
![databaseDiagram2](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/413895be-2b2c-4a54-a796-e4bd498ba717)
![databaseDiagram3](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/5da32964-599e-45eb-ba44-7eb7caee0d61)
![databaseDiagram4](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/1f442b3e-c476-43e6-b8c3-3f17599cb6d1)
![databaseDiagram5](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/dbefed99-997d-4741-a010-c4b986a07114)
![databaseDiagram6](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/83f55df3-d340-4a2e-ba8a-6c3b470ab74f)

### FrotEnd 

#### View 
![inital](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/e0383626-7ffe-4c4f-b656-4ed885ed4d5d)
![initalWithlogin](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/69e5ce1a-8bea-45cc-a64d-472285a1d9ef)

#### Sign Up & Sign In
![SignUp](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/116ce60d-db03-4e6f-8264-2c24edeb3526)
![signIn](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/a6325b99-05ee-4089-a5ce-ae45eb4fa02c)

#### Blog 
![blog](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/7f12e92a-6763-4688-b0cf-fa0bdb999634)
![blogView](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/2b48fc15-4b43-41d7-8b96-1c3642794347)
![createBlog](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/fd8a80a0-84a4-44f9-ace2-ad383afa39c1)

#### Contest
![contestView](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/ea8544a3-436d-4c9f-ab38-5f62d4a9ce1a)
![createContest](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/7f588d96-5f80-4de2-a13f-6cd9685367ea)
![contestFilter](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/eb02a9bd-75f5-4a5e-946f-49e749234d1d)

#### Group
![groupView](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/2fa586ea-8968-4430-8608-fd47aec89f25)
![groupViewIn](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/8d156a59-a117-4264-a809-8c2709cebe40)
![newGroup](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/d41fab4a-8cd3-4dff-beb6-4aed4d8d5903)

#### Problem 
![problemsPage](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/acc0a327-7633-4bdf-9ac2-03318a87b19f)
![problemView](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/3c984ba3-d79c-4d88-a325-e27ab07d1814)
![sumbitProblem](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/e85692d0-1c53-4238-ba17-2dc38dd16bed)
![problemStatus](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/51b6e194-f109-4799-9b1f-9203900d300b)
![showsolution](https://github.com/MohamedSamehMohamed/AC-Judge/assets/32108759/1ab9d197-9cfd-4e13-8098-e10e0284e012)
