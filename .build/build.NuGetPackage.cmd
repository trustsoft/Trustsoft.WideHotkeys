call "%VS120COMNTOOLS%vsvars32.bat"
MSBuild.exe /nologo /v:minimal /p:Configuration=Release build.xml /t:CreateNuGetPackages

pause