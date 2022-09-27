https://exambk.somee.com

cd /

git clone https://github.com/Berk6/Exams-MVC-Project-NTier-Architecture.git Exams

`$pathToJson = "C:\Exams\Exams.WEB\appsettings.json"

$a = Get-Content $pathToJson | ConvertFrom-Json

$a.ConnectionStrings.'SqlCon'= "AppSetingsJson”

$a | ConvertTo-Json | set-content $pathToJson`

cd /Exams/Exams.Repository

dotnet ef database update --context AppDbContext --startup-project /Exams/Exams.WEB/Exams.WEB.csproj

cd /Exams/Exams.WEB

dotnet run --urls=https://localhost:5001 
