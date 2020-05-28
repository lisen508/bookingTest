#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BookingPlatformApi/BookingPlatformApi.csproj", "BookingPlatformApi/"]
COPY ["BookingPlatform.Extensions/BookingPlatform.Extensions.csproj", "BookingPlatform.Extensions/"]
COPY ["BookingPlatform.Common/BookingPlatform.Common.csproj", "BookingPlatform.Common/"]
COPY ["BookingPlatform.Core/BookingPlatform.Core.csproj", "BookingPlatform.Core/"]
COPY ["BookingPlatform.Service/BookingPlatform.Service.csproj", "BookingPlatform.Service/"]
COPY ["BookingPlatform.Dal/BookingPlatform.Dal.csproj", "BookingPlatform.Dal/"]
RUN dotnet restore "BookingPlatformApi/BookingPlatformApi.csproj"
COPY . .
WORKDIR "/src/BookingPlatformApi"
RUN dotnet build "BookingPlatformApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingPlatformApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingPlatformApi.dll"]
#
