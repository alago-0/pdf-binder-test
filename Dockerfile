FROM mcr.microsoft.com/dotnet/sdk:8.0

EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

# Get source code
WORKDIR pdf-binder-test
COPY . . 

# Build and publish
RUN dotnet restore
WORKDIR Web
RUN dotnet publish -o out

# Run
WORKDIR out
CMD ["dotnet", "Web.dll"]
