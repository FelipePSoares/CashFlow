FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["../CashFlow.Api/CashFlow.Api.csproj", "../CashFlow.Api/"]
RUN dotnet restore "../CashFlow.Api/CashFlow.Api.csproj"
COPY . .
WORKDIR "/src/../CashFlow.Api"
RUN dotnet build "CashFlow.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CashFlow.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]