FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /back
COPY . ./
RUN dotnet publish Back/TutorProject.Account.Web/TutorProject.Account.Web.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 4000
ENV ASPNETCORE_URLS=http://+:4000
WORKDIR /back
COPY --from=build /back/out .
ENTRYPOINT ["dotnet", "TutorProject.Account.Web.dll"]