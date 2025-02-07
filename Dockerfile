# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /serviceordersearch

EXPOSE 80
EXPOSE 5000

COPY ./*.csproj ./
RUN dotnet restore 

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 
WORKDIR /serviceordersearch
COPY --from=build /serviceordersearch/out .
ENTRYPOINT ["dotnet", "services-order-search.dll"]
