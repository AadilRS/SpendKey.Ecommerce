# SpendKey.Ecommerce


SpendKey Ecommerce
📂 Project Structure
SpendKeyEcommerce/
├── SpendKey.Ecommerce.Api # .NET 8 Web API
└── SpendKey.Ecommerce.Frontend # Angular 18 Frontend

### ✅ Backend (.NET Core API)
- .NET 8, C#
- Entity Framework Core with SQL Server
- RESTful APIs for:
  - Category tree (recursive)
  - Products by category (with subcategories)
  - Cart operations (add item, list cart)
- DTOs service and Repositories-layer architecture
- Manual DB seeding (SQL scripts)
- Swagger enabled for local testing

### ✅ Frontend (Angular 18)
- Angular CLI project with plain CSS styling
- Category tree navigation (recursive)
- Product listing with name, price, and "Add to Cart"
- Cart page with item list, subtotal, tax, and total
- Template-driven forms used in cart quantity inputs


##############################################################################
Instructions to Setup and Run the Project
###############################################################################
### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli) 
- SQL Server (Express)

Steps:
1.Install all Prerequites.
2.Update the connection string in appsettings.json eg: username and password
  .\SpendKey.Ecommerce\SpendKeyEcommerce\SpendKey.Ecommerce.Api\appsetings.json
3.Create Database with name SpendKeyDb and run these scripts to seed data:
  CREATE TABLE Category (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    parent_id INT NULL,
    FOREIGN KEY (parent_id) REFERENCES Category(id)
);
CREATE TABLE Product (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    price DECIMAL(10, 2),
    availability_qty INT,
    category_id INT,
    FOREIGN KEY (category_id) REFERENCES Category(id)
);

CREATE TABLE Cart (
    id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES Product(id)
);

-- Root Categories
INSERT INTO Category (id, name, parent_id) VALUES (1, 'Electronics', NULL);
INSERT INTO Category (id, name, parent_id) VALUES (2, 'Home Appliances', NULL);

-- Level 1 Subcategories
INSERT INTO Category (id, name, parent_id) VALUES (3, 'Mobiles', 1);
INSERT INTO Category (id, name, parent_id) VALUES (4, 'Laptops', 1);
INSERT INTO Category (id, name, parent_id) VALUES (5, 'Kitchen', 2);

-- Level 2 Subcategories
INSERT INTO Category (id, name, parent_id) VALUES (6, 'Gaming Laptops', 4);

INSERT INTO Product (id, name, price, availability_qty, category_id)
VALUES 
(1, 'iPhone 13', 75000.00, 10, 3),
(2, 'Samsung Galaxy S21', 60000.00, 5, 3),
(3, 'HP Pavilion', 55000.00, 7, 4),
(4, 'Dell XPS', 88000.00, 0, 4), -- won't show due to availability 0
(5, 'Asus ROG Strix', 95000.00, 3, 6),
(6, 'Samsung Microwave', 12000.00, 8, 5);

INSERT INTO Cart (user_id, product_id, quantity)
VALUES
(1, 1, 2),
(1, 3, 1),
(1, 5, 1);

4.Run the backend solution in http Debug mode: ( Default URL: http://localhost:5066)

Use Swagger at:
http://localhost:5066/swagger

###################################################################################################
Frontend Setup
###################################################################################################
1.cd .\SpendKey.Ecommerce\SpendKeyEcommerce\SpendKey.Ecommerce.Frontend
2.npm install
3.ng serve
App runs at: http://localhost:4200
