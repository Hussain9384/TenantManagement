#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TenantManagement.Api/TenantManagement.Api.csproj", "TenantManagement.Api/"]
COPY ["TenantManagement.InfraStructure/TenantManagement.InfraStructure.csproj", "TenantManagement.InfraStructure/"]
COPY ["TenantManagement.Processor/TenantManagement.Processor.csproj", "TenantManagement.Processor/"]
RUN dotnet restore "TenantManagement.Api/TenantManagement.Api.csproj"
COPY . .
WORKDIR "/src/TenantManagement.Api"
RUN dotnet build "TenantManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TenantManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TenantManagement.Api.dll"]