call "%VS120COMNTOOLS%vsvars32.bat"
MSBuild.exe /nologo /v:minimal /p:Configuration=Release build.xml /t:BuildSolution

MSBuild.exe /nologo /v:minimal /p:Configuration=Release build.xml /t:CreateNuGetPackages
MSBuild.exe /nologo /v:minimal /p:Configuration=Release build.xml /t:PublishToMyGet
MSBuild.exe /nologo /v:minimal /p:Configuration=Release build.xml /t:PublishToNuGet

pause