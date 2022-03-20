FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Antoine.Mortelier.FeatureMatching.WebApi/Antoine.Mortelier.FeatureMatching.WebApi.csproj", "Antoine.Mortelier.FeatureMatching.WebApi/"]
RUN dotnet restore "Antoine.Mortelier.FeatureMatching.WebApi/Antoine.Mortelier.FeatureMatching.WebApi.csproj"
COPY . .
WORKDIR "/src/Antoine.Mortelier.FeatureMatching.WebApi"
RUN dotnet build "Antoine.Mortelier.FeatureMatching.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Antoine.Mortelier.FeatureMatching.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Antoine.Mortelier.FeatureMatching.WebApi.dll"]
