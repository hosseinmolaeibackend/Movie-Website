# Movie Website

🎬 **Description:**
The Movie Website project is a web application designed to manage and display movie information. It provides functionalities for managing movies, users, and other related data.

✨ **Features:**
- 🎥 Movie management (add, edit, delete)
- 👤 User management
- 🔍 View movie details

💻 **Technologies Used:**
- ASP.NET Core
- Entity Framework Core
- Razor Pages
- Bootstrap
- Clean Architecture

🚀 **Setup Instructions:**
1. Clone the repository.
2. Switch to the `dev` branch with `git checkout dev`.
3. Restore NuGet packages with `dotnet restore`.
4. Update the database with `dotnet ef database update`.
5. Run the application with `dotnet run`.

📁 **Project Structure:**
- **Core**: Contains domain entities and interfaces.
- **Application**: Business logic and application services.
- **Infrastructure**: Data access and external services implementation.
- **Presentation**: Razor Pages and UI logic.
- **AppContext**: Database context.
- **Migrations**: Database migrations.
- **ViewComponents**: Reusable UI components.
- **Views**: Razor views.
- **wwwroot**: Static files.

📄 **License:**
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

For more details, visit the [GitHub repository](https://github.com/hosseinmolaeibackend/Movie-Website/tree/dev).
