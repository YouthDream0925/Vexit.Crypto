# VEXIT Wallet


|            |                   |               |
| ---------- | ----------------- | ------------- |
| Copyright: | © 2022 VEXIT®     | www.vexit.com |
| Trademark: | Be the code ... ® |               |
| Author:    | Vex Tatarevic     |               |
| Date:      | 2022-09-04        |               |
|            |                   |               |





<br>

## Create Project

- Open Visual Studio
- Create New Project
- Select template named **ASP.NET Core with Angular**
  - If you cannot see it in the list, type Angular in the search box at the top

- Fill out the rest of the project creation fields as per table below:
  
|                                                  |          |
| ------------------------------------------------ | -------- |
| Project name                                     | Web      |
| Location                                         | C:\Dev\  |
| Solution name                                    | Web      |
| Place solution and project in the same directory | [ ]      |
| Framework                                        | .NET 6.0 |
| Authentication type                              | None     |
| Configure for HTTPS                              | v/       |
| Do not use top-level statements                  | v/       |
|                                                  |          |


## Install Packages
<br>

- Entity Framework Core

  Ref: https://docs.microsoft.com/en-us/ef/core/get-started/overview/install

  - Open PM (**Package Manager Console**)
  - on top menu select: View > Other Windows > Package Manager Console
  - Inside PM run install statements
    
		Install-Package Microsoft.EntityFrameworkCore.SqlServer
		Install-Package Microsoft.EntityFrameworkCore.Tools


 