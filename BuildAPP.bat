
@echo off
cd Build

if "%*"=="-r" goto RELEASE else goto DEBUG

:DEBUG
echo [101;43m================================[0m
echo [101;43m= Building Launcher DL DEBUG   =[0m
echo [101;43m================================[0m
echo.
echo Add "-r" to build it on Release
echo.
dotnet build -c Debug
exit

:RELEASE
echo [101;43m================================[0m
echo [101;43m= Building Launcher DL RELEASE =[0m
echo [101;43m================================[0m
dotnet build -c Release
exit