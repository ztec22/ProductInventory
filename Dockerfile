FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /ProductInventory

COPY . ./
RUN dotnet restore
RUN dotnet publish -o out

#Create migration bundle
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations bundle --output out/efbundle --self-contained --no-build --verbose
RUN chmod +x ./out/efbundle

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /ProductInventory
COPY --from=build /ProductInventory/out .

EXPOSE 8080

#Run migrations and start
ENTRYPOINT ["/bin/bash", "-c", "./efbundle; dotnet ProductInventory.dll"]
