@echo off
set scripts=%~dp0
set scripts=%scripts:~0,-1%

set project=%1.Tests

if not defined configuration set configuration=Release

set assembly=%project%\bin\%configuration%\%project%.dll

%scripts%\OpenCover\OpenCover.Console.exe -returntargetcode -register:path32 -target:"vstest.console.exe" -targetargs:"/logger:Appveyor %assembly%" -output:coverage.xml -oldstyle
if %errorlevel% neq 0 exit /b %errorlevel%

%scripts%\coveralls.io\coveralls.net.exe --opencover coverage.xml
if %errorlevel% neq 0 exit /b %errorlevel%
