cd bin\Debug\netcoreapp3.1
dotnet SampleNetCore.API.dll
set url=https://localhost:5001/swagger/index.html
start chrome %url%
pause