@echo off
setlocal
:: ============================================================================
:: BUILD BOTON REPORTES - VISUAL STUDIO 2022
:: Compila las 3 capas y deja TODAS las DLL listas en la carpeta "dist".
:: Para usarlo: en tu proyecto, Agregar referencia -> Examinar ->
::   dist\CapaVista_BtnReportes.dll  (las demas DLL se copian solas)
:: y en el Cuadro de herramientas: clic derecho -> Elegir elementos -> esa DLL.
:: ============================================================================
set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
set "RAIZ=%~dp0"
set "PROY=%RAIZ%BtnReportes\CapaVista_BtnReportes\CapaVista_BtnReportes.csproj"
set "DIST=%RAIZ%dist"

if not exist "%MSBUILD_PATH%" (
    echo [ERROR] No se encontro MSBuild en: %MSBUILD_PATH%
    pause
    exit /b 1
)

"%MSBUILD_PATH%" "%PROY%" /restore /p:RestorePackagesConfig=true /p:SolutionDir="%RAIZ%BtnReportes\\" /t:Rebuild /p:Configuration=Release /v:minimal
if errorlevel 1 (
    echo [ERROR] La compilacion fallo.
    pause
    exit /b 1
)

if exist "%DIST%" rmdir /s /q "%DIST%"
mkdir "%DIST%"
xcopy /y /q "%RAIZ%BtnReportes\CapaVista_BtnReportes\bin\Release\*.dll" "%DIST%\" >nul

echo.
echo [OK] DLL generadas en: %DIST%
pause
