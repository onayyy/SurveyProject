#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SurveyProject/SurveyProject.WebApi.csproj", "SurveyProject/"]
COPY ["SurveyProject.BusinessLayer/SurveyProject.BusinessLayer.csproj", "SurveyProject.BusinessLayer/"]
COPY ["SurveyProject.DataAccessLayer/SurveyProject.DataAccessLayer.csproj", "SurveyProject.DataAccessLayer/"]
COPY ["SurveyProject.EntityLayer/SurveyProject.EntityLayer.csproj", "SurveyProject.EntityLayer/"]
RUN dotnet restore "./SurveyProject/SurveyProject.WebApi.csproj"
COPY . .
WORKDIR "/src/SurveyProject"
RUN dotnet build "./SurveyProject.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SurveyProject.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveyProject.WebApi.dll"]