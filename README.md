# B8IT150_2223_TME4_MPower_CA

## Assignment Submission Details

### Project: Power Family Farm E-Commerce Web application

- Module: B8IT150 Advanced Programming
- Module Code: B8IT150_2223_TME4
- Student Name: Maurice Power
- Student ID: 10609394
- Email: 10609394@mydbs.ie
- Submission Date: 10 September 2023
- Document size: 1,800 words
- GitHub Repository:
 
# Table of Contents
1.	Project Overview
2.	Developer documentation - how to set-up the application
3.	Test login credentials
4.	Requirements
    -	User requirements
    -	Security & Access Control
    -	Data requirements
    -	Functionality
        -  Summary of key application functionality.
        -   Detailed page by page summary and functionality.
5.	Scope Movement
    -	Additional Scope
    -	Scope Reduction
6.	References - Summary of code attributes / reference material.
 
# 1. Project Overview 
Power Family Farm E-commerce web application is used for promotion and to facilitate the sale of organic farm produce.

For customers, in addition to the standard home and privacy pages, the application includes a catalogue page to allow for browsing products, a details page for further information on each product, a shopping cart, user registration, log-in / log-out and account management.

For owners, the application includes functionality to create, edit and delete products, users and company roles. 

This application was developed using Visual Studio code and hosted on GitHub.  The framework used to develop the web application was Microsoft ASP.NET core 7.0. Languages used to develop the web application include:
1.	C#: used to develop the back end.
2.	CSHTML, CSS and JavaScript: used to develop the front end.
3.	Bootstrap and jQuery libraries were also used to develop the front end. 

The application consists of two distinct parts. The main application and a separate Application Programming Interface (“API”) that contains a SQLite database which stores web application products. 

Both parts of the application use the Model View Controller (“MVC”) architecture. These parts are named “FarmApp” and “ProductsApi” respectively in the underlying code folder structure.
 
# 2. Developer Documentation
**To set up the web application, please follow these steps:**
1.	Extract all folders / files from the zipped folder provided and save in the chosen location on your local machine. 

**Setup and installation:**

For the main application, in your chosen code editor, open a command terminal and navigate to the “FarmApp” folder. 
1.	To setup and build the project, enter the command: dotnet build
2.	To add migration scripts, enter the command: dotnet ef database update
3.	To run the application, enter the command: dotnet run

For the products Api, in your chosen code editor, open a second command terminal and navigate to the “ProductsApi” folder.  
1.	Follow steps 1 – 3 above.

# 3. Test Login Credentials
The following test login credentials are pre-stored in the application for testing and review purposes:

## Role: Administration
-	Username: admin@pff.ie
-	Password: @dminPword1

## Role: Manager
-	Username: manager@pff.ie
-	Password: M@nagerPword1

## Role: Customer (aka: User / visitor)
-	Username: customer@example.ie
-	Password: Cu$tPword1

## Role: visitor
-	Username: TestUser1@example.com
-	Password: TestUser1Pword@1

## Role: Visitor
-	Username: TestUser2@example.com
-	Password: TestUser2Pword@1

# 4. Requirements
This section outlines the web applications requirements which in summary include:
1.	User requirements
2.	Security & Access Control
3.	Data requirements
4.	Functionality

## 4.1 User Requirements
User profiles included in the web application include:
1.	Individual customers
2.	Company manager(s)
3.	Company Administrator(s)
Individual customers should be able to browse the website as a visitor or can create an account. Currently the having an account grants a customer no additional benefits, however the intention is to develop the application further to include individual customer orders history and an option to save customer details to provide a smoother check-out experience. 
Company managers have elevated access privileges. Once signed in a manager has access to create, edit and delete products.
Administrators have further elevated access privileges. Once logged in, in addition to Manager privileges, Administrators can also create, edit, and delete user accounts. Administrators can also create, edit and delete Company roles and can assign or revoke user permissions to access web application services.

## 4.2 Security and Access Control
The web application was created using Microsoft ASP.NET Core 7.0 including Individual Authentication. The ‘out of the box’ individual user accounts scaffolded authentication was supplemented with additional Authorisation by the developer. As outlined I the previous section, sample roles included in the web application for testing and review purposes include the following:
1.	Administrator
2.	Manager
3.	Viewer
Please refer to section 2 for test user login details for each of the above roles.

## 4.3 Data Requirements
The main data sources in the web application are SQLite databases used in both the main application and the products API which will be used to store user input.
The key data entities for this application include:
-	Product: 
-	User Profile: 
-	User Role: 
-	Cart: 
-	Cart Item: 
-	Audit Log:  

In addition to the above, Microsofts ASP.NET Core Identity API is used to manage the web applications Authorisation functionality

As part of future development external APIs will be implemented for:
-	Payments (e.g., PayPal, Stripe, MasterCard, etc.) 
-	Ability to upload photos to cloud based storage for use in the e-commerce application (e.g. to promote display new products).
-	Sign-in with Google


## 4.4 Functionality

### Summary of key functionality included in the application

#### Visitor Account Management (Authentication)

All users, regardless of role, can:

-	Register a new account.
-	Once registered, users can login or logout
-	Users can manage their account, including:
    -	Add phone number.
    -	Update email address.
    -	Update password.
    -	Set-up two factor authentication.
    -	Download account data. 
    -	Delete account.

#### Account Management (Authentication)

When signed in as an Administrator only, users can:

-	Add new user account.
-	Edit existing user account.
-	Delete existing user account.
-	Add users to a role.
-	Remove users from a role.

#### Role Management (Authorization)

When signed in as an Administrator only, users can:

-	View all users under each company role.
-	Create a new company role (e.g., Social Media Manager, Accounts Administrator etc.).
-	Edit existing company role.
-	Delete company role.
-	Add or remove existing users to company roles (e.g.: Manager, Administrator etc. The default role is ‘Viewer’).

#### Product Management

All users regardless of role can do the following:
-	Browse all products (as stored in the ProductsApi Database (“DB”))
-	Search for products by title or category.
-	Sort products by title or category.
-	View individual product details.
-	Add products to a shopping cart.
-	Cycle through pages of products (Number of products per page is limited to 10 by default)
-	Select the number of products to appear on a page (up to a maximum of 50 products per page). 

When logged in as an Administrator, Manager or other company role, the user should be able to:
-	Create new products.
-	Edit existing products.
-	Delete existing products.

####  Shopping cart
All users can do the following:
-	Add product(s) to the shopping cart.
-	View quantity, unit price and total for each product in the cart.
-	Increase number of existing product(s) in a shopping cart.
-	Decrease the number of product(s) in a shopping cart.
-	Remove a product from the shopping cart.
-	Clear all products from the shopping cart.
-	Navigate to check-out (functionality to be developed).
 
# 5. Scope Movement

## 5.1 Additional Scope

User and role management was not included in the original scope at the outset of this project, however, the developer become of this requirement early in the process and adjusted the project scope. As a result, a reduction of scope was required in other areas as detailed in the next section.

## 5.2 Scope Reduction

Originally the requirements scheduled below were included in the original scope at project inception. However due additional requirements as detailed in the previous section and due to time constraints, the scope had to be reduced.

### Account Management

-	Set-up email verification.
-	Set-up single sign-in (e.g., Google, Facebook etc.).
-	Set-up image store (Google Cloud or similar).

### Data-manipulation / Marketing 

-	Set-up image store (Google Cloud or similar).
-	Sort products by price.

### Order processing

-	Create and save orders from the cart summary page.
-	Set-up Payments API integration (e.g., PayPal, Stripe, Mastercard etc.).

### Deployment

-	Deployment of the web application. 

## 5.3 Future Development
-	Resolve all null referance warnings.
-   Set up reporting.
-	Move cart / orders to a separate web API.
-	Introduce a data access layer to promote ‘do not repeat’ (“DRY”) coding principles. The various controllers would handle http requests while the data access layer would be used to  handle the various functions. 
-	Add authentication to API(s) (JWT token).

# 6.0 References - Summary of code attributes / reference material
The following resources were used to aid in the development of this web application:

## 6.1 Prior DBS modules
1.	Dublin Business School (March - May 2023) B8IT146 Web and Cloud Application Development B8IT146_2223_TME3. Available at: https://elearning.dbs.ie/course/view.php?id=17202 

## 6.2 Websites
1.	Microsoft (2023) ASP.NET Core documentation, Various pages used (e.g. MVC tutorials, make HTTP requests etc). Available at: https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0 

2.	W3schools (1999 - 2023) Various pages used for C#, CSS, Html and JavaScript. Available at: https://www.w3schools.com

3.	Bootstrap (Code licensed MIT, docs CC BY 3.0. Currently v5.3.1.) Various pages used (e.g., grid system, cards, search, dropdown etc.). Available at: https://getbootstrap.com 

4.	Stackoverflow (Site design / logo © 2023 Stack Exchange Inc; user contributions licensed under CC BY-SA. rev 2023.9.5.43611) Various threads accessed. Available at: https://stackoverflow.com
## 6.3 YouTube video series
Shopping cart video
1.	Blender Up (2022) ASP.NET Core 6 .NET 6 Project - Shopping Cart. Available at: https://www.youtube.com/watch?v=sX3g6hQZ8Lw&t=2705s&ab_channel=BlenderUp 
Authorisation video series
2.	kudventkat (2019) Custom validation attribute in asp net core. Available at: https://www.youtube.com/watch?v=o_AH2MGti0A&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=76&ab_channel=kudvenkat 

3.	kudventkat (2019) Extend IdentityUser in ASP NET Core. Available at: https://www.youtube.com/watch?v=NV734cJdZts&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=77&ab_channel=kudvenkat 

4.	kudventkat (2019) Creating roles in asp net core. Available at: https://www.youtube.com/watch?v=TuJd2Ez9i3I&ab_channel=kudvenkat 

5.	kudventkat (2019) Get list of roles in asp core net. Available at: https://www.youtube.com/watch?v=KGIT8P29jf4&ab_channel=kudvenkat 

6.	kudventkat (2019) Edit role in asp net core. Available at:
https://www.youtube.com/watch?v=7ikyZk5fGzk&ab_channel=kudvenkat 

7.	kudventkat (2019) Add or remove users from role in asp net core. Available at: https://www.youtube.com/watch?v=TzhqymQm5kw&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=81&ab_channel=kudvenkat 

8.	kudventkat (2019) List all users from asp net core identity database. Available at:  https://www.youtube.com/watch?v=OMX0UiLpMSA&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=84&ab_channel=kudvenkat 

9.	Kudvenkat (2019) Edit identity user in asp net core. Available at: https://www.youtube.com/watch?v=QYlIfH8qyrU&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=85&ab_channel=kudvenkat 

10.	Kudvenkat (2019) Delete identity user in asp net core. Available at: https://www.youtube.com/watch?v=MhNfyZGfY-A&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=86&ab_channel=kudvenkat 

11.	Kudvenkat (2019) ASP NET Core delete confirmation. Available at: https://www.youtube.com/watch?v=hKLjt9GzYM8&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=87&ab_channel=kudvenkat 

12.	Kudvenkat (2019) Delete identity role in asp net core. Available at: https://www.youtube.com/watch?v=pj3GCelrIGM&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=88&ab_channel=kudvenkat 
