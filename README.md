Database:

Please update the dbContext connection string and seed the database.
There is seed data available for all data entities.

The following user data is seeded and can be used to log in with different roles to experience all the feature of the application:


Roles - there are two types of roles:
- customer - a user that is registered in the application.
  Customers can access all views of the public area of the shop. They can check their order history and current order status.
  Also, by entering their address in their profile, it is automatically populated on the checkout page for each new order they place.
- admin - a user that has full access to all views and actions in the store. Admin users have access to the admin area where they can:
  - read, create, delete and edit products
  - edit the shop currency and change the shipping fee rate applied to products in cart as a percentage of the cart total amount
  - manage all users and edit their roles in the system

Unregistered users without profile and role can also use the website. 
They can place orders and do the same things as customer users except for accessing order history and status and not being able to save customer data for next purchase.

---------------------------------------------------

Users - the following users are seeded by default:

Admin user:
Username: admin@mail.com
Password: AdminPassword123!
Role: admin

Customer user:
Username: customer@mail.com
Password: CustomerPassword123!
Role: customer

---------------------------------------------------

Cookies:

The application uses cookies to manage products in cart and keep order information until a successful payment is made and a new order is created.
For the purposes of the project, it disables cookies if user refuses to give cookie consent. 
The website informs users they need to enable cookies if they want to use some features and redirects them to a page where they can modify their consent.

---------------------------------------------------

Payment (Test mode):

The shop uses Stripe API for test payments. Test credentials are available in appsettings.

In order to test shop payment, please use the following mock data:

Card number: 4242424242424242
CVC: Any 3 digits
Date: Any future date

Or use any other card mock data on:
https://docs.stripe.com/testing#cards


---------------------------------------------------

