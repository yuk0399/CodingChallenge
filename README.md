# CodingChallenge

**The Coding Challenge, powered by SchoolBell.chat**

## Documents

[Coding Challenge Document](/2019AraCodingChallenge.pptx)

This file includes below:

+ Solution Architecture Document

+ High Level design document

+ Pitch deck

+ Assumptions


### Unit test

file

###  Defect list

file

## Working Application

## Application Setup

This application made by ASP.NET Core.

Developer needs windows, mac or any OS system which can setup ASP.NET Core.

1. Install mySQL

https://www.mysql.com/downloads/

1. Install ASP.NET Core SDK

https://dotnet.microsoft.com/download

1. Change the connection string

Open `/EmployeeManagement/appsettings.json` and update `"ConnectionString"`

ex:
server=<your ServerAddress ex)localhost>;userid=<your mySQL user name>;password=<password>;database=EmployeeDB;

1. Create Database

Open terminal window and move to EmployeeManagement directory, and do below commands.

`dotnet ef migrations add InitialCreate`

`dotnet ef database update`

1. Start application!

# Working application

link


# Known issue

- Login function is unavailable

- 
