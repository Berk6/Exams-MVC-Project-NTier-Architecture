<h3 align="middle">Demo Site</h3>
<p align="Middle"> <a href="https://exambk.somee.com" target="blank" rel="noreferrer"> <img src="https://exambk.somee.com/images/logoExamBK.png" alt="csharp" width="200" height="100"/> </a>
 
<h3 align="middle">Languages and Tools:</h3>
<p align="Middle">  <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="80" height="80"/>   <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="80" height="80"/>  <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="80" height="80"/> </p>

While creating the project, .Net6 and MsSql were used.
## Nuget Packages Used
- Microsoft.AspNetCore.Identity.EntityFramework (6.0.9)
- Microsoft.EntityFrameworkCore (6.0.9)
- FluentValidation.AspNetCore (11.2.2)
- Mapster (7.3.0)
- AutoFac.Extensions.DependencyInjection (8.0.0)
- Serilog.AspNetCore (6.0.1)

It is aimed that any user on this site can be tested by connecting with other users and that users are subject to scoring through these tests. It is a development that can be used for personal or educational purposes.

## Getting Started

- `cd /`

- `git clone https://github.com/Berk6/Exams-MVC-Project-NTier-Architecture.git Exams`

In order to run it in your local, you need to enter your connection string.

- `$pathToJson = "C:\Exams\Exams.WEB\appsettings.json"` 
- `$a = Get-Content $pathToJson | ConvertFrom-Json` 
- `$a.ConnectionStrings.'SqlCon'= "Your Connection String Should Be Here”` 
- `$a | ConvertTo-Json | set-content $pathToJson`

database update operations
- `cd /Exams/Exams.Repository`
- `dotnet ef database update --context AppDbContext --startup-project /Exams/Exams.WEB/Exams.WEB.csproj`

running the project
- `cd /Exams/Exams.WEB`
- `dotnet run --urls=https://localhost:5001 `

You can start using it by copying https://localhost:5001 to your internet browser.

The installation will be done in your `C:\` folder, if you want to install in a different location, you need to make changes in the terminal codes.

<p align="right">
<a href="https://www.linkedin.com/in/berk-karasu-939a0b18a/" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/linked-in-alt.svg" alt="https://www.linkedin.com/in/berk-karasu-939a0b18a/" height="60" width="80" /></a>
</p>
