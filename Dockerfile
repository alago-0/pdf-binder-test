FROM ubuntu:22.04

EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

# Get packages
RUN apt-get update
RUN apt-get install -y git dotnet-sdk-8.0

# Get repo
RUN git clone https://github.com/alago-0/pdf-binder-test.git

# Build
WORKDIR pdf-binder-test
RUN dotnet restore

# Publish
WORKDIR Web
RUN dotnet publish -o out

# Run
WORKDIR out
CMD ["dotnet", "Web.dll"]
