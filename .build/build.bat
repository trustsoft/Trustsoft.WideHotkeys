call "%VS120COMNTOOLS%vsvars32.bat"
MSBuild.exe /nologo /v:minimal build.xml  %*

pause