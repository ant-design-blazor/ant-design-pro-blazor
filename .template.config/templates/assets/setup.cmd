@echo off
setlocal enabledelayedexpansion

set "targetDir=.\src\AntDesign.Pro.Template.Client" 
set "searchText=AntDesign.Pro.Template" 
set "replaceText=AntDesign.Pro.Template.Client" 

for /r "%targetDir%" %%f in (*) do (
    if exist "%%f" (
        echo Processing file: %%f
        powershell -Command "(Get-Content '%%f') -replace '%searchText%', '%replaceText%' | Set-Content '%%f'"
    )
)

endlocal
exit 0