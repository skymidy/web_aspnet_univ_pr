FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ASPnetWebApp.csproj", "./"]
RUN dotnet restore "ASPnetWebApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ASPnetWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASPnetWebApp.csproj" -c Release -o /app/publish

FROM node AS react-app  
WORKDIR /app/client  
COPY ./client .  
RUN npm install  
RUN npm run build  

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=react-app ./app/client/build /app/client/build  
ENTRYPOINT ["dotnet", "ASPnetWebApp.dll"]
