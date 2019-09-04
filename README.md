---

# CodingChallenge

This repository is made for **The Coding Challenge, powered by SchoolBell.chat.**


by Yutaka Kawakami & Harry Lo

---

## Documents

### Documents

[Coding Challenge Document](/2019AraCodingChallenge.pptx)

This file includes below:

+ Solution Architecture Document

+ High Level design document

+ Pitch deck

+ Assumptions


### Unit test

The unit test was done manually for all business logic.

[Unit Test](/UnitTest_forCodingChallenge.pdf)

###  Defect list

- Login function is unavailable

---

## Tools used

- ASP.NET Core MVC framework

- Entity framework (for database)

- Razor Pages (for view)

- MySQL

- Admin LTE (includes Bootstrap, jQuery)

---

## Application Setup

This application made by ASP.NET Core.

Developer needs windows, mac or any OS system which can setup ASP.NET Core.

1. Install mySQL

    https://www.mysql.com/downloads/

2. Install ASP.NET Core SDK

    https://dotnet.microsoft.com/download

3. Change the connection string

    Open `/EmployeeManagement/appsettings.json` and update `"ConnectionString"`

    ex:
    server=<your ServerAddress ex)localhost>;userid=<your mySQL user name>;password=<password>;database=EmployeeDB;

4. Create Database

    Open terminal window and move to EmployeeManagement directory, and do below commands.

    `dotnet ef migrations add InitialCreate`

    `dotnet ef database update`

5. Start application!

---

## Continuous deployment

This working application enables continuous deployment from GitHub.

Once latest code pushes to the Github repository, the application on the cloud will also update automatically.

https://ara-coding-emservice.azurewebsites.net/

*This application deployed on Microsoft Azure but not working yet.

 It will move soon.
 
---

## Known issues

### Employee search function

- When you input characters except numbers in `Age`, it will be considered as 0.

### Employee Create / Update

- When you input characters (include empty) except numbers in `Age`, `Salary`, it will be considered as 0.

- You can make a employee with empty `FirstName`, `LastName`, `Salary`.


### Department Create / Update

- You can make a department with empty `DepartmentName`.
