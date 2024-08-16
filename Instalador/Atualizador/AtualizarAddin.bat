@echo off
chcp 65001 > nul
setlocal enabledelayedexpansion

xcopy "P:\Projetos Leonardo\01 - Clientes\06 - FORMATEC\02 - ADDIN FORMATEC\AddinFormatec\bin\Debug\*.*" "C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS" /E /I /Y

echo pause


