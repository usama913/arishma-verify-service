FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.sln ./
COPY src/Arishma.Verify.Api/Arishma.Verify.Api.csproj src/Arishma.Verify.Api/
COPY src/Arishma.Verify.Application/Arishma.Verify.Application.csproj src/Arishma.Verify.Application/
COPY src/Arishma.Verify.Domain/Arishma.Verify.Domain.csproj src/Arishma.Verify.Domain/
COPY src/Arishma.Verify.Infrastructure/Arishma.Verify.Infrastructure.csproj src/Arishma.Verify.Infrastructure/
RUN dotnet restore src/Arishma.Verify.Api/Arishma.Verify.Api.csproj
COPY . .
RUN dotnet publish src/Arishma.Verify.Api/Arishma.Verify.Api.csproj -c Release -o /app/publish --no-restore
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://*:5003
ENTRYPOINT ["dotnet", "Arishma.Verify.Api.dll"]
