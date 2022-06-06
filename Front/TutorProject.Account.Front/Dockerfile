FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TutorProject.Account.Front/TutorProject.Account.Front.csproj", "TutorProject.Account.Front/"]
RUN dotnet restore "TutorProject.Account.Front/TutorProject.Account.Front.csproj"
COPY . .
WORKDIR "/src/TutorProject.Account.Front"
RUN dotnet build "TutorProject.Account.Front.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TutorProject.Account.Front.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TutorProject.Account.Front.dll"]
