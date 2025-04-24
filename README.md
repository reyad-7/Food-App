# Food App

**foodapp** is a mobile application developed as a course project for the **Enterprise Mobile Application Development** course. The app allows users to discover restaurants and cafes, browse their products, and find venues that offer specific food items, complete with map and direction features.

## Project Overview

This project demonstrates the use of modern state management (using RxDart or another state management solution) and API integration in Flutter. It is developed collaboratively by our team as part of the course requirements.

## Features

- **User Signup**
  - Name (mandatory)
  - Gender (optional, radio button)
  - Email (mandatory, with email validation)
  - Level (optional, 4 options: 1, 2, 3, 4)
  - Password (mandatory, at least 8 characters)
  - Confirm Password (mandatory, at least 8 characters, must match password)
  - Signup fails if any mandatory field is invalid

- **User Login**

- **Restaurants/Cafes List**
  - View a list of all available restaurants and cafes

- **Products List**
  - View a list of products for each restaurant or cafe

- **Product Search**
  - Select a product from a list
  - View all restaurants/cafes that provide the selected product (list view)
  - Switch to map view to see locations of all restaurants/cafes offering the product

- **Directions & Distance**
  - Select a restaurant/cafe from search results to view the distance and directions from your current location
