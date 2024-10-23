
# FoodApplication

## Overview
FoodApplication is a web-based platform built with ASP.NET Core for managing recipes, carts, and user orders. This application provides a seamless way for users to browse recipes, add them to their cart, and place orders.

## Features
- **User Authentication**: Secure login and registration system.
- **Recipe Management**: Browse a variety of recipes, view details, and add to cart.
- **Cart System**: Manage items in the cart, update quantities, and proceed to checkout.
- **Order Management**: Place and track orders.

## Project Structure

- `Controllers/`: Contains the logic for handling user requests, including:
  - `AccountController.cs`: Manages user login, registration, and authentication.
  - `CartController.cs`: Handles cart operations such as adding, updating, and removing items.
  - `HomeController.cs`: Displays the homepage and general information.
  - `RecipeController.cs`: Manages recipe-related actions like viewing details and adding to the cart.

- `Data/`: Contains database-related operations.
  - `FoodDbContext.cs`: Manages interactions with the database.
  - `Migrations/`: Contains database migrations for managing schema changes.

- `wwwroot/`: Contains static files (CSS, JavaScript, libraries like Bootstrap and jQuery).

## Setup Instructions

### Prerequisites
- .NET Core SDK
- SQL Server (or another compatible database)
- Entity Framework Core

### Steps to Run Locally
1. Clone the repository:
    ```bash
    git clone <repository-url>
    ```
2. Navigate to the project directory:
    ```bash
    cd FoodApplication
    ```
3. Install dependencies:
    ```bash
    dotnet restore
    ```
4. Update the `appsettings.json` file with your database connection string.
5. Apply database migrations:
    ```bash
    dotnet ef database update
    ```
6. Run the application:
    ```bash
    dotnet run
    ```

## Technologies Used
- **ASP.NET Core**: Web framework for building modern, cloud-based applications.
- **Entity Framework Core**: ORM for database interactions.
- **Bootstrap**: For responsive design and layout.
- **jQuery**: JavaScript library for DOM manipulation and event handling.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.
