# 📔 Diary Pro - .NET 9 MVC Web Application

A professional-grade personal diary application built with a focus on **Clean Architecture**, security, and modern DevOps practices. This project serves as a showcase for implementing the Repository Pattern, Dependency Injection Stored Procedures, GitHub Actions, and Docker.

## 🚀 Key Features
- **Full CRUD Operations:** Create, View, Update, and Delete diary entries with ease.
- **Secure Data Handling:** All database interactions are executed via **SQL Stored Procedures** to prevent SQL injection and optimize performance.
- **Modern UI/UX:** Responsive design using Bootstrap 5, featuring custom modal confirmations for record deletion.
- **Automated CI/CD:** Fully integrated GitHub Actions pipeline that builds and pushes Docker images to the **GitHub Container Registry (GHCR)**.

## 🚀 Looking forward   
- - **Calendar Integration:** A month-based calendar view for intuitive navigation of past activities.

## 🛠️ Technical Stack
- **Framework:** ASP.NET Core 8.0 MVC
- **Database:** SQL Server (using EF Core for migrations and raw SQL for execution)
- **Architecture:** Repository Design Pattern (Decoupled Data Layer)
- **Frontend:** Razor Views, Bootstrap 5, jQuery, FullCalendar API
- **DevOps:** Docker, GitHub Actions, YAML Workflows

## 📂 Project Structure
The solution is divided into three distinct layers to ensure a clean separation of concerns:
- **Diary.App:** The presentation layer containing Controllers, Views, and UI logic.
- **Diary.Data:** The data access layer containing the `DbContext`, Repositories, and SQL Migration scripts.
- **Diary.Models:** A shared library for Entity models and data transfer objects.

## ⚙️ Setup & Installation

### Local Development
1. Clone the repository:
   ```bash
   git clone https://github.com/Shubhangi-2503/diary
   ```
2. Update the connection string in `Diary.App/appsettings.json`.
3. Apply migrations to create the database and Stored Procedures:
   ```bash
   dotnet ef database update --project Diary.Data --startup-project Diary.App
   ```
4. Run the application:
   ```bash
   dotnet run --project Diary.App
   ```

### Docker Deployment
Build and run the application locally using the provided Dockerfile:
```bash
docker build -t diary-app .
docker run -p 8080:8080 -e "ConnectionStrings__DefaultConnection=YOUR_SQL_CONNECTION" diary-app
```

## 🛡️ Security Implementation
- **Anti-Forgery:** Implemented `[ValidateAntiForgeryToken]` on all POST actions.
- **Input Sanitization:** Utilized Parameterized SQL via `FromSqlInterpolated` to mitigate SQL Injection risks.

## 📧 Contact
- [Shubhangi Tomar](www.linkedin.com/in/shubhangitomar)
- Project Link: https://github.com/Shubhangi-2503/diary
