@echo off
set scripts=%~dp0
set scripts=%scripts:~0,-1%

set solution=%1%.sln

if not defined configuration set configuration=Release

msbuild /p:Configuration=%configuration% %solution%
