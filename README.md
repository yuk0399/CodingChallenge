# CodingChallenge

This repository is made for **The Coding Challenge, powered by SchoolBell.chat.**

by Yutaka Kawakami & Harry Lo

# Requirements

1. Capture basic employee information 
2. Search for employees and display results
3. Sortable based on Employee Name, Department Name, Manager Name

![Employee](https://user-images.githubusercontent.com/54500481/64244788-c8d7ba00-cf5d-11e9-99fb-5f4b8a7b4566.png)

4. Display hierarchy of Managers to whom the employee reports
5. Display all the staff who reports to this employee

![Employee Detail](https://user-images.githubusercontent.com/54500481/64244795-cb3a1400-cf5d-11e9-997a-675142daee6b.png)

# Documents

## Documents

[Coding Challenge Document](/2019AraCodingChallenge.pptx)

This file includes below:

+ Solution Architecture Document

+ High Level design document

+ Pitch deck

+ Assumptions


## Unit test

The unit test was done manually for all business logic.

[Unit Test](/UnitTest_forCodingChallenge.pdf)

*I tried to use some testingframeworks (xUnit, MSTest), but there was no time to finish all.

##  Defect list

- Login function is unavailable

# Tools used

- ASP.NET Core MVC framework

- Entity framework (for database)

- Razor Pages (for view)

- MySQL

- Admin LTE (includes Bootstrap, jQuery)

# Application Setup

This application is using ASP.NET Core framework.

So, developers need Windows, Mac or Linux OS which can install ASP.NET Core.

1. Install mySQL

    https://www.mysql.com/downloads/

2. Install ASP.NET Core SDK

    https://dotnet.microsoft.com/download

3. Change the connection string

    Open `/EmployeeManagement/appsettings.json` and update `"ConnectionString"`

    ex:
    server=localhost;userid=username;password=yourpassword;database=EmployeeDB;

4. Create Database

    Open terminal window and move to EmployeeManagement directory, and do below commands.

    `dotnet ef database update`

5. Start application!

# Continuous deployment

This working application enables continuous deployment from GitHub.

Once latest code pushes to the Github repository, the application on the cloud will also update automatically.

https://ara-coding-emservice3.azurewebsites.net/

*This application deployed on Microsoft Azure but not working yet.

 It will move soon.

# Known issues

### Employee search function

- When you input characters except numbers in `Age`, it will be considered as 0.

### Employee Create / Update

- When you input characters (include empty) except numbers in `Age`, `Salary`, it will be considered as 0.

- You can make a employee with empty `FirstName`, `LastName`, `Salary`.

### Department Create / Update

- You can make a department with empty `DepartmentName`.
