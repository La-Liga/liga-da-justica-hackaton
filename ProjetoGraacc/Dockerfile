FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ProjetoGraacc/ProjetoGraacc.csproj", "ProjetoGraacc/"]
RUN dotnet restore "ProjetoGraacc/ProjetoGraacc.csproj"
COPY . .
WORKDIR "/src/ProjetoGraacc"
RUN dotnet build "ProjetoGraacc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProjetoGraacc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjetoGraacc.dll"]