#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Security-Design-Net-Prj/Security-Design-Net-Prj.csproj", "Security-Design-Net-Prj/"]
RUN dotnet restore "Security-Design-Net-Prj/Security-Design-Net-Prj.csproj"
COPY . .
WORKDIR "/src/Security-Design-Net-Prj"
RUN dotnet build "Security-Design-Net-Prj.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Security-Design-Net-Prj.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Security-Design-Net-Prj.dll"]