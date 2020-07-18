#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ArtGallery.Artists/ArtGallery.Artists.csproj", "ArtGallery.Artists/"]
COPY ["ArtGallery.Common/ArtGallery.Common/ArtGallery.Common.csproj", "ArtGallery.Common/ArtGallery.Common/"]
COPY ["ArtGallery.Items/ArtGallery.Items.csproj", "ArtGallery.Items/"]
COPY ["ArtGallery.Identity/ArtGallery.Identity.csproj", "ArtGallery.Identity/"]
RUN dotnet restore "ArtGallery.Artists/ArtGallery.Artists.csproj"
COPY . .
WORKDIR "/src/ArtGallery.Artists"
RUN dotnet build "ArtGallery.Artists.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArtGallery.Artists.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtGallery.Artists.dll"]