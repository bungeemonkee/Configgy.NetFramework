@echo off
set scripts=%~dp0
set scripts=%scripts:~0,-1%

set project=%1%\%1%.csproj

if not defined configuration set configuration=Release

%scripts%\Nuget\nuget.exe pack -Symbols -Properties Configuration=%configuration% --output %scripts%\.. %project%
if %errorlevel% neq 0 exit /b %errorlevel%
