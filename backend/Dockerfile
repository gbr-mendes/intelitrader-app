FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY *.sln .
COPY ./UserRegistration/*.csproj ./UserRegistration/
COPY ./UserRegistration.Tests/*.csproj ./UserRegistration.Tests/
RUN dotnet restore
COPY . .
RUN dotnet build
FROM build AS testrunner
WORKDIR /app/UserRegistration.Tests
CMD ["dotnet", "test", "--logger:trx"]
# run the unit tests
FROM build AS test
WORKDIR /app/UserRegistration.Tests
RUN dotnet test --logger:trx
# publish the API
FROM build AS publish
WORKDIR /app/UserRegistration
RUN dotnet publish -c Release -o out
# run the api
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/UserRegistration/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "UserRegistration.dll"]