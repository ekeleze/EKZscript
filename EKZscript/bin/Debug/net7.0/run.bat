@echo off
:main
set /p input="Please enter the full path of the file to launch: "
call "%cd%\EKZscript.exe" "%input%"
set /p choice="Do you want to run another file? (y/n): "
if /i "%choice%"=="y" goto main
pause