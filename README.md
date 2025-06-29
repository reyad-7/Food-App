# Food-App

FoodApp is a mobile application developed as a course project for the **Enterprise Mobile Application Development** course. The app allows users to discover restaurants and cafes, browse their products, and find venues that offer specific food items, complete with map and direction features.

**All backend logic is implemented in this repository using ASP.NET Core and Entity Framework Core, with a strong focus on RESTful API design, authentication, and modular service/repository patterns.** The backend provides all logic for user registration, login, and management, as well as for handling restaurants and products (menus).

---

## Live Demo

You can try the Food-App live at:  
**[https://foodapp.runasp.net](https://foodapp.runasp.net)**

---

## Backend Features

### Authentication & User Management

- **Registration & Login:**  
  Secure user registration and login flows implemented using ASP.NET Identity (`User` inherits from `IdentityUser`).  
  - `UserController` exposes REST endpoints for registration (`/api/User/Register`), login (`/api/User/Login`), and user retrieval.
  - Password hashing, user validation, and JWT token generation handled in service/repository layers.

- **User Model:**  
  Users have additional fields such as `Name`, `gender`, and `level` on top of standard Identity properties.

### Restaurant & Product Management

- **Restaurant Endpoints:**  
  - Retrieve all restaurants (`/api/Restaurant/GetRestaurants`)
  - List all products for each restaurant (`/api/Restaurant/ListAllProductsForEachRestauarnt`)

- **Product Endpoints:**  
  - Get all products (`/api/Product/GetAllProducts`)
  - Search for products by name (`/api/Product/SearchProduct/{name}`)

- **Data Models:**  
  - `Restaurant` includes name, address, latitude, longitude, and a list of menu products.
  - `Product` includes name, price, and belongs to a restaurant via FK.

### Architecture

- **Clean Separation:**  
  - Controllers handle HTTP/API logic only.
  - Services encapsulate business logic (UserService, RestaurantService, ProductService).
  - Repositories handle database access (not shown in this summary, but inferred from service layer usage).
  - DTOs are used for input/output to keep models decoupled from API contracts.

- **Database:**  
  - Entity Framework Core is used for ORM.
  - `FoodAppDbContext` manages DbSets for users, restaurants, and products.
  - ASP.NET Identity is integrated for authentication.

---

## Project Structure (Backend)

```
FoodApp/
├── Controllers/
│   ├── UserController/           # Registration, login, user APIs
│   ├── RestaurantController/     # Restaurant APIs
│   └── ProductController/        # Product APIs
├── Models/
│   ├── User.cs                   # User model (inherits IdentityUser)
│   ├── Restaurant.cs             # Restaurant model
│   ├── Product.cs                # Product model
│   └── FoodAppDbContext.cs       # EF Core DB context
├── Services/
│   ├── UserService/              # User business logic
│   ├── RestaurantService/        # Restaurant logic
│   └── ProductService/           # Product logic
├── Repositories/                 # (Assumed: code uses repository pattern)
└── Migrations/                   # EF Core migrations
```

---

## How to Run

1. **Clone the repository:**
    ```sh
    git clone https://github.com/reyad-7/Food-App.git
    cd Food-App
    ```

2. **Prerequisites:**
    - .NET SDK (6 or 7+)
    - SQL Server (or change connection string for another DB)

3. **Setup Database:**
    ```sh
    dotnet ef database update
    ```

4. **Run the Application:**
    ```sh
    dotnet run
    ```
    The API will be available at `http://localhost:<port>/api/`

---

## API Overview

- `POST /api/User/Register` — Register a new user
- `POST /api/User/Login` — Log in and receive a JWT token
- `GET /api/User/GetUsers` — Get all users (admin only)
- `GET /api/Restaurant/GetRestaurants` — List all restaurants
- `GET /api/Restaurant/ListAllProductsForEachRestauarnt` — List products for each restaurant
- `GET /api/Product/GetAllProducts` — List all products
- `GET /api/Product/SearchProduct/{name}` — Search for products by name

---

## Notes

- All core backend code for registration, login, restaurants, and products is implemented.
- Follows best practices for service/repository separation and uses ASP.NET Identity for secure authentication.

---

## Contribution

Contributions are welcome! Please open issues or submit pull requests.



---

## More

For more details, see the [source code](https://github.com/reyad-7/Food-App).  
If you have questions or need help, open an issue!

---

_This summary is based on code search results. For a complete view of all backend logic and files, visit the [GitHub Code Search](https://github.com/reyad-7/Food-App/search)_.
