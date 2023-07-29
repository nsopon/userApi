
# User Management Project

This is a user management web REST Api made by .net 6 that allow you to read, create, edit and delete user information in database.

This API support following endpoints:

* GET  - Retrive user information by id.
* POST - Create a new user with name and email address.
* PUT  - Update user information by id.

# Requirement

* .NET SDK 6.0
* MSSQL database 2022
* Visual studio code 2022
* Git
* Post man (to test endpoints)
* Docker and Docker desktop

# Getting Started
1. Install Docker and Docker desktop (Skip this step if you already have it.)

    > Click this [link](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe?_gl=1*122z3pn*_ga*MTU2NzA0ODIxMS4xNjg4NTI2NTU3*_ga_XJWPQMJYHQ*MTY5MDYzMzYxNC43LjEuMTY5MDYzNDE2MC4yNy4wLjA.) to download installer.

2. Run an installer.exe 
    > Read more information in docker website. https://docs.docker.com/desktop/install/windows-install/

3. Clone project from the repository
    > git clone https://github.com/nsopon/userApi.git

4. Go to project folder
    > cd userApi

5. Run Api with docker compose
    > docker-compose up

That's it!!! Now you can go to Api with localhost url

    > http://localhost:5000/swagger/

Note : If you can't reach this page when use Edge or Chrome browser. So, you should try again in privated mode or use Post man instead.
