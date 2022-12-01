#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Banco_Loja/Banco_Loja.csproj", "Banco_Loja/"]
RUN dotnet restore "Banco_Loja/Banco_Loja.csproj"
COPY . .
WORKDIR "/src/Banco_Loja"
RUN dotnet build "Banco_Loja.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banco_Loja.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banco_Loja.dll"]