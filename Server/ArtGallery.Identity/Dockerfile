#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ArtGallery.Identity/ArtGallery.Identity.csproj", "ArtGallery.Identity/"]
COPY ["ArtGallery.Common/ArtGallery.Common/ArtGallery.Common.csproj", "ArtGallery.Common/ArtGallery.Common/"]
RUN dotnet restore "ArtGallery.Identity/ArtGallery.Identity.csproj"
COPY . .
WORKDIR "/src/ArtGallery.Identity"
RUN dotnet build "ArtGallery.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArtGallery.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtGallery.Identity.dll"]