
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .


ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 80



# Start the app
ENTRYPOINT ["dotnet", "GEVS-API.dll"]
