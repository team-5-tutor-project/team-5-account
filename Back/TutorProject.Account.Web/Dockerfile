FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /back
COPY . ./
RUN dotnet restore Back
RUN dotnet publish Back -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /back
COPY --from=build /back/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "TutorProject.Account.Web.dll"]