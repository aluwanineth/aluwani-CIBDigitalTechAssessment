FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CIBDigitalTechAssessment.WebApi/CIBDigitalTechAssessment.WebApi.csproj", "CIBDigitalTechAssessment.WebApi/"]
RUN dotnet restore "CIBDigitalTechAssessment.WebApi/CIBDigitalTechAssessment.WebApi.csproj"
COPY . .
WORKDIR "/src/CIBDigitalTechAssessment.WebApi"
RUN dotnet build "CIBDigitalTechAssessment.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CIBDigitalTechAssessment.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CIBDigitalTechAssessment.WebApi.dll"]