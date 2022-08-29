FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerAPI/CustomerAPI.csproj", "CustomerAPI/"]
COPY ["CustomerService/CustomerService.csproj", "CustomerService/"]
COPY ["CustomerDomain/CustomerDomain.csproj", "CustomerDomain/"]
COPY ["CustomerApplication/CustomerApplication.csproj", "CustomerApplication/"]
COPY ["CustomerInfra/CustomerInfra.csproj", "CustomerInfra/"]
RUN dotnet restore "CustomerAPI/CustomerAPI.csproj"
COPY . .
WORKDIR "/src/CustomerAPI"
RUN dotnet build "CustomerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerAPI.dll"]