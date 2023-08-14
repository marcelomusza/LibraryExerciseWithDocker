FROM mcr.microsoft.com/dotnet/runtime:7.0
COPY LibraryExercise.ConsoleUI/bin/Release/net7.0 .
ENTRYPOINT ["dotnet", "LibraryExercise.ConsoleUI.dll"]