FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src

# Copy everything else and build
COPY src/ .

# Test
RUN dotnet restore \
 && dotnet test PracticalTest.Tests/PracticalTest.Tests.csproj

# Publish
RUN dotnet publish src/PracticalTest.Api/PracticalTest.Api.csproj -c Release -o out -r alpine.3.7-x64

#
# Build runtime image
#
FROM microsoft/dotnet:2.2-runtime-deps-alpine AS runtime

# Default AspNetCore directory
WORKDIR /app


# Copy from build stage
COPY --from=build /app/out ./

# Using 5000 for http, 5001 for https
EXPOSE 5000 5001

ENTRYPOINT ["./PracticalTest.Api"]