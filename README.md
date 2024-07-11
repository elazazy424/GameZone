### GameZone: MVC .NET Project Overview

**Project Description:**

GameZone is a dynamic web application developed using the ASP.NET MVC framework. It provides a comprehensive platform for managing a collection of games, incorporating robust CRUD (Create, Read, Update, Delete) operations. The application features a clean and intuitive user interface built with Bootstrap, ensuring a responsive and visually appealing experience across various devices.

**Key Features:**

1. **Game Management:**
   - **Add Game:** Admin users can add new games to the platform, providing essential details such as game title, genre, cover image, and description.
   - **Update Game:** Admin users can edit existing game details to keep the information current and accurate.
   - **Delete Game:** Admin users have the authority to remove games from the collection, maintaining the relevance of the game library.
   - **View Game Details:** All users can view detailed information about each game, including the title, genre, and cover image.

2. **Role-Based Access Control:**
   - Only users with Admin roles have permissions to perform add, update, and delete operations. This ensures the integrity and security of the game data.

3. **User Authentication:**
   - The application employs ASP.NET Identity for user authentication and authorization, providing a secure login and registration system.

4. **Responsive Design:**
   - Leveraging Bootstrap, GameZone offers a responsive design that adapts seamlessly to various screen sizes, enhancing user experience on both desktop and mobile devices.

5. **JavaScript Validation:**
   - Client-side validation is implemented using JavaScript to provide immediate feedback on user inputs, ensuring data integrity and improving user experience.

**Architecture:**

- **SOLID Principles:**
  - The application follows SOLID principles, ensuring a maintainable, scalable, and testable codebase. This approach improves code quality and facilitates future enhancements.
  
- **Three-Tier Architecture:**
  - The project is structured into three main layers:
    - **Presentation Layer:** Handles user interactions and views, implemented using ASP.NET MVC.
    - **Business Logic Layer (BLL):** Contains the business logic and rules, implemented with C# classes and services.
    - **Data Access Layer (DAL):** Manages data access and storage, implemented using Entity Framework and repositories.

**Technology Stack:**

- **Frontend:**
  - HTML, CSS, Bootstrap for responsive design
  - JavaScript for client-side validation

- **Backend:**
  - ASP.NET MVC framework
  - C# for server-side logic
  - Entity Framework for data access

- **Database:**
  - SQL Server for storing game data and user information

**Development Tools:**

- Visual Studio for development and debugging
- Git for version control
- SQL Server Management Studio for database management

**Screenshots:**
![image](https://github.com/elazazy424/GameZone/assets/73352569/1e0be297-f501-4b24-8631-658e0411d3f2)
![image](https://github.com/elazazy424/GameZone/assets/73352569/f7c020c3-6b86-409b-a23f-aa69e9c14ede)

**How to Run:**

1. Clone the repository from GitHub.
2. Open the solution in Visual Studio.
3. Configure the database connection string in `appsettings.json`.
4. Run the Entity Framework migrations to set up the database.
5. Build and run the application.

**Conclusion:**

GameZone exemplifies a robust and scalable web application, offering essential game management features with a focus on security and user experience. By adhering to SOLID principles and utilizing a three-tier architecture, the application ensures high maintainability and scalability. It serves as an excellent foundation for further enhancements and can be extended to include additional functionalities like game reviews, ratings, and user comments.
