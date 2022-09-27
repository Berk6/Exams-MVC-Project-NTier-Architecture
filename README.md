https://exambk.somee.com

<h3 align="left">Languages and Tools:</h3>
<p align="Middle"> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> </p>
- `cd /`

- `git clone https://github.com/Berk6/Exams-MVC-Project-NTier-Architecture.git Exams`

- `$pathToJson = "C:\Exams\Exams.WEB\appsettings.json"` 
- `$a = Get-Content $pathToJson | ConvertFrom-Json` 
- `$a.ConnectionStrings.'SqlCon'= "Your Connection String Should Be Here”` 
- `$a | ConvertTo-Json | set-content $pathToJson`

- `cd /Exams/Exams.Repository`

- `dotnet ef database update --context AppDbContext --startup-project /Exams/Exams.WEB/Exams.WEB.csproj`

- `cd /Exams/Exams.WEB`

- `dotnet run --urls=https://localhost:5001 `
<p align="left">
<a href="https://linkedin.com/in/https://www.linkedin.com/in/berk-karasu-939a0b18a/" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/linked-in-alt.svg" alt="https://www.linkedin.com/in/berk-karasu-939a0b18a/" height="30" width="40" /></a>
</p>
