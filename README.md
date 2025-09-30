Employee & Department Management System

A simple Employee & Department Management System built with:

- Database: MSSQL
- Backend: ASP.NET Core Web API (using Dapper)
- Frontend: Angular

1. Database Setup

1.1. Create database:

CREATE DATABASE hasib_Playon24Db;
GO
USE hasib_Playon24Db;
GO

1.2. Run the provided SQL script to create:
- Tables: Department, Employee, Attendance
- Stored Procedures: sp_GetEmployees, sp_GetEmployeeAttendance, sp_AddEmployee, sp_AddAttendance

2. Backend Setup (ASP.NET Core Web API + Dapper)

2.1. Open the backend project in Visual Studio or VS Code.

2.2. Restore NuGet packages:

dotnet restore

2.3. Update connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=hasib_Playon24Db;Trusted_Connection=True;"
}

2.4. Run the backend:

dotnet run

- Default URL: https://localhost:7230

API Endpoints:

Method | Endpoint | Description
GET    | /api/employees | List employees with department
POST   | /api/employees | Add new employee
GET    | /api/attendance?start=YYYY-MM-DD&end=YYYY-MM-DD | Attendance summary per employee
POST   | /api/attendance | Add attendance records (multiple)

Note: All DB operations use Dapper to call stored procedures.

3. Frontend Setup (Angular)

3.1. Go to Angular project folder:

cd playon24-frontend

3.2. Install dependencies:

npm install

3.3. Update API URL in src/environments/environment.ts if needed:

export const environment = {
  production: false,
  apiUrl: 'https://localhost:7230/api'
};

3.4. Run Angular app:

ng serve

- Open browser at http://localhost:4200

Features:

- Employee Management: List employees with department, Add new employee
- Attendance Report: Filter by date range, Show summary (Employee Name, Department, PresentCount, AbsentCount)

4. Notes

- Start backend before frontend.
- Make sure to run `npm install` before starting Angular app.
- Attendance POST uses Table-Valued Parameter to insert multiple records.
- Dapper is used in backend for all stored procedure calls.
