FROM ubuntu:22.04

EXPOSE 5247

# Get packages
RUN apt-get update
RUN apt-get install -y git dotnet-sdk-8.0

# Get repo
RUN git clone https://github.com/alago-0/pdf-binder-test.git
WORKDIR pdf-binder-test
RUN dotnet build --configuration Release

# Run
WORKDIR Web
CMD ["dotnet", "run", "--configuration", "Release"]
