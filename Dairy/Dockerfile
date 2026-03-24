# 1. Use the .NET 9 SDK to build the app (The "Kitchen")
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 2. Copy the project file and "Restore" (downloading NuGet packages)
# We do this first so Docker doesn't re-download everything if you only change code
COPY ["Dairy.csproj", "./"]
RUN dotnet restore "Dairy.csproj"

# 3. Copy every other file from your folder into the container
COPY . .

# 4. Compile the app into a folder called /app/publish
RUN dotnet publish "Dairy.csproj" -c Release -o /app/publish

# 5. Use the .NET 9 Runtime (The "Serving Plate")
# This image is much smaller because it doesn't contain the compiler
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080

# 6. Copy only the finished "Published" files from the build stage
COPY --from=build /app/publish .

# 7. Start the app!
ENTRYPOINT ["dotnet", "Dairy.dll"]