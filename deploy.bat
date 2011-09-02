rmdir /S /Q "PoL.WinFormsView\bin\Release\data"
rmdir /S /Q "PoL.WinFormsView\bin\Release\graphics"
rmdir /S /Q "PoL.WinFormsView\bin\Release\save"
rmdir /S /Q "PoL.WinFormsView\bin\Release\decks"
rmdir /S /Q "PoL.WinFormsView\bin\Release\temp"
xcopy /E /Q /I "lib\*.dll" "PoL.WinFormsView\bin\Release"
mkdir "PoL.WinFormsView\bin\Release\temp"
copy "lib\ilmerge.exe" "PoL.WinFormsView\bin\Release\ilmerge.exe"
cd "PoL.WinFormsView\bin\Release"
ilmerge.exe /ndebug /out:temp\PoL.exe PoL.WinFormsView.exe Communication.dll Patterns.dll PoL.Common.dll PoL.Configuration.dll PoL.Logic.dll PoL.Models.dll PoL.Services.dll RibbonStyle.dll  ICSharpCode.SharpZipLib.dll
cd ..\..\..
del /Q "PoL.WinFormsView\bin\Release\*.*"
move "PoL.WinFormsView\bin\Release\temp\PoL.exe" "PoL.WinFormsView\bin\Release\PoL.exe"
rmdir "PoL.WinFormsView\bin\Release\temp"
xcopy /E /Q /I "data" "PoL.WinFormsView\bin\Release\data"
xcopy /E /Q /I "graphics" "PoL.WinFormsView\bin\Release\graphics"
copy "license.txt" "PoL.WinFormsView\bin\Release\license.txt"
mkdir "PoL.WinFormsView\bin\Release\save"
mkdir "PoL.WinFormsView\bin\Release\decks"
mkdir "PoL.WinFormsView\bin\Release\logs"

pause
