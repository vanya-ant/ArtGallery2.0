#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ArtGallery.Orders/ArtGallery.Orders.csproj", "ArtGallery.Orders/"]
COPY ["ArtGallery.Common/ArtGallery.Common/ArtGallery.Common.csproj", "ArtGallery.Common/ArtGallery.Common/"]
RUN dotnet restore "ArtGallery.Orders/ArtGallery.Orders.csproj"
COPY . .
WORKDIR "/src/ArtGallery.Orders"
RUN dotnet build "ArtGallery.Orders.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArtGallery.Orders.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtGallery.Orders.dll"]