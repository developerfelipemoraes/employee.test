FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EmployeeAPI/EmployeeAPI.csproj", "EmployeeAPI/"]
RUN dotnet restore "EmployeeAPI/EmployeeAPI.csproj"
COPY . .
WORKDIR "/src/EmployeeAPI"
RUN dotnet build "EmployeeAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeAPI.dll"]