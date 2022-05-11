FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TextRun/TextRun.csproj", "TextRun/"]
RUN dotnet restore "TextRun/TextRun.csproj"
COPY . .
WORKDIR "/src/TextRun"
RUN dotnet build "TextRun.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TextRun.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TextRun.dll"]
