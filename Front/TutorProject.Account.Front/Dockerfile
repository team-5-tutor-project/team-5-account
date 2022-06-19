FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Front/TutorProject.Account.Front/TutorProject.Account.Front.csproj .
RUN dotnet restore TutorProject.Account.Front.csproj
COPY Front/TutorProject.Account.Front/ .
RUN dotnet build TutorProject.Account.Front.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish TutorProject.Account.Front.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Front/TutorProject.Account.Front/nginx.conf /etc/nginx/nginx.conf