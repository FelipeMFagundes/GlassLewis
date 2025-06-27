# How to use:
Clone the GitHub project by clone https://github.com/FelipeMFagundes/GlassLewis.git

Execute the project in your Visual Studio or Vs Code

If the application doesn't open
The local url should be https://localhost:7074/index.html

# CompanyRecords.API

A minimal ASP.NET Core Web API project for managing company-related data, built with .NET 9.0 with Jwt Authorization Token

## 🚀 Project Overview

This project sets up a lightweight API server that integrates with a local SQLite database (`company.db`). It uses ASP.NET Core's minimal hosting model and can be used as a foundation for building more complex APIs.
Build with Generic repository, AutoMapper and .Net 9
This project can grow and will not be difficult to maintain and test.
By using generic repositories we can save time since the standard methods have already been implemented, using time only to implement specific methods such as GetByIsinAsync.

![image](https://github.com/user-attachments/assets/52da4512-53ff-4869-8331-eec607d77004)

Here you will find the AuthController and CompanyController.
To access the CompanyController you will need to get the Bearer Token executing the AuthController

![image](https://github.com/user-attachments/assets/77b1f71e-ba95-48fa-b591-97b3c38247f4)

The UserName and Password are set:
{
  "userName": "admin",
  "password": "password123"
}

After copy the Bearer Token, past into the authorize

![image](https://github.com/user-attachments/assets/746a9a50-e882-4bac-a872-c9b0f6eb9183)

E.g: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJhZG1pbiIsIm5iZiI6MTc1MTA0Nzk1NywiZXhwIjoxNzUxMDQ5NzU3LCJpYXQiOjE3NTEwNDc5NTcsImlzcyI6IkNvbXBhbnlSZWNvcmRzQVBJIiwiYXVkIjoiQ29tcGFueVJlY29yZHNVc2VycyJ9.7ZK749o4eoOjzxq6kWb_E1j3omm2v363ZiRdT6-NjB4

Now you are authorized to use the CompanyController

Create Method

![image](https://github.com/user-attachments/assets/da80f51f-5710-4ab9-9908-02bd4482ba80)

input the Company Data followed by the image

![image](https://github.com/user-attachments/assets/2a34518a-28e3-49d2-beaa-211701209a04)

If the Isin Already exists will throw an error saying: "ISIN already exists."
if the Isin doesn't start with 2 Letter followed by 10 numbers will return an error saying: "ISIN must start with 2 letters and be 12 characters."

List Method

Will list all the companies that been saved into database

![image](https://github.com/user-attachments/assets/0ebb8908-7919-41a8-bbdf-4e2d1508a734)

Search By Id

Will return a company with the Id that has been input 
If the Id doesn't exists into data database returns Not Found
![image](https://github.com/user-attachments/assets/92192682-3260-4863-bf50-622696f1de0e)


Update Company

Updates following that was inputed into json
![image](https://github.com/user-attachments/assets/4b952cba-76e7-4371-a515-d904783efcf0)


Search by Isin

Will return the company that corresponding with the Isin has been typed
![image](https://github.com/user-attachments/assets/6de23afb-cb4f-46df-8d93-9b417f6bbf3c)




