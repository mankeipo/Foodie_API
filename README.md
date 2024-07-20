# Foodie

# Endpoints:
1. api/restaurants                    
2. api/restaurants/{id}               
3. api/restaurants/foodType/{foodtype}




# Sample Request Body
1. GET …api/restaurants                         #This retrieves the data of all restaurants 
2. GET …api/restaurants/{id}                    #This retrieves the data of this specific restaurant
3. GET …api/restaurants/foodType/{foodtype}     #This retrieves the data of all restaurants with this specific foodtype
4. POST …api/restaurants/                       #This adds a new restaurant to the database.
5. PUT …api/restaurants/{id}                    #This updates a current restaurant in the database with this specific id
6. DELETE …api/restaurants/{id}                 #This deletes a current restaurant in the database with this specific id

# Sample Response Body
```
GET …api/restaurants/{id}
"statusCode": 200,
"statusDescription": "Successfully retrieved restaurants.",
"restaurantId": 1,
    "restaurant_Name": "Emily - West Village",
    "foodType": "Burger",
    "overall_Rating": 4,
    "locationId": 1,
    "address": {
        "location": "35 Downing St New York, NY 10014",
        "borough": "Manhattan",
        "locationId": 1
    }
```

# Changes to your API
```
	I changed my API from three tables to two tables because I realized my third table is unnecessary because 
the third table contains all duplicated information from table 1 and 2, and I added an endpoint where users are 
allowed to search for a specific food type that you want and the API will respond with a list of restaurant with 
the specific food type. 
```