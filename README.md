https://exambk.somee.com

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
