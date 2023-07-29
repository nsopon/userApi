FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /source
## Copy everything
#COPY . .
## Restore as distinct layers
#RUN dotnet restore
## Build and publish a release
#RUN dotnet publish -c Release -o /app --no-restore
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#COPY --from=build /app ./
#
#EXPOSE 5000
#
#ENTRYPOINT ["dotnet", "userApi.dll"]




#FROM centos:7 AS base
#
## Add Microsoft package repository and install ASP.NET Core
#RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm \
    #&& yum install -y aspnetcore-runtime-6.0
#
## Ensure we listen on any IP Address 
#ENV ASPNETCORE_URLS=http://+:5000
#
#WORKDIR /app
#
## ... remainder of dockerfile as before
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
##COPY ["userApi.csproj", "."]
##RUN dotnet restore "./userApi.csproj"
##COPY . .
#
#COPY . .
#RUN dotnet restore
#
#WORKDIR "/src/."
#RUN dotnet build -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "userApi.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["userApi.csproj", "."]
RUN dotnet restore "./userApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "userApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "userApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "userApi.dll"]

