##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
##For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["fauna_db_api/fauna_db_api.csproj", "fauna_db_api/"]
#RUN dotnet restore "fauna_db_api/fauna_db_api.csproj"
#COPY . .
#WORKDIR "/src/fauna_db_api"
#RUN dotnet build "fauna_db_api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "fauna_db_api.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "fauna_db_api.dll"]
#

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENV ASPNETCORE_URLS=http://*:4000
ENTRYPOINT ["dotnet", "fauna_db_api.dll"]