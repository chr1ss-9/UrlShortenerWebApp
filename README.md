# UrlShortenerWebApp

⚠ A light-hearted side project, completed in about an hour, just to indulge my coding cravings and having git activity! 😅

This is a web application developed using ASP.NET Core, focusing on web development, MVC pattern, handling HTTP requests, and potentially including database interaction for persisting short URLs.

## Description

Users can visit the website to input a long URL, and the application will generate a short URL. The website is designed to redirect users from the short URL to the original one.

## Project Structure

The project is organized into the following directories:

- **Controllers:** Contains controllers responsible for handling HTTP requests and defining URL shortening logic.

- **Models:** Includes models representing the data structures used in the application.

- **Views/UrlShortener:** Contains views for the URL shortener functionality.

- **Properties:** Project properties.

- **wwwroot:** Publicly accessible files such as stylesheets and client-side scripts.

- **bin/Debug/net8.0:** Compiled binaries.

- **obj:** Temporary build objects.

- **Program.cs:** Entry point for the application.

- **Startup.cs:** Configuration for the application.

- **UrlShortenerWebApp.csproj:** Project file containing configuration and dependencies.

- **appsettings.Development.json:** Development environment settings.

- **appsettings.json:** Application settings.

## Getting Started

1. **Prerequisites:** Make sure you have [ASP.NET Core](https://dotnet.microsoft.com/download) installed.

2. **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/UrlShortenerWebApp.git
    ```

3. **Navigate to the project directory:**
    ```bash
    cd UrlShortenerWebApp
    ```

4. **Run the application:**
    ```bash
    dotnet run
    ```

5. **Open your browser and visit:**
    ```
    http://localhost:5000
    ```

## Next Steps

The current state of the project has implemented the basic URL shortener functionality. The next steps involve extending and enhancing the application. 
