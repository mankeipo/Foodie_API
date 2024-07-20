CREATE DATABASE Foodie;
USE Foodie;

CREATE TABLE Restaurants(
	RestaurantId INT NOT NULL AUTO_INCREMENT,
    Restaurant_Name VARCHAR(1000) NOT NULL,
    FoodType VARCHAR(1000) NOT NULL,
    Overall_Rating INT NOT NULL,
    PRIMARY KEY(RestaurantId)
);
    
CREATE TABLE Address(
	Location VARCHAR(3000) NOT NULL,
    Borough VARCHAR(1000) NOT NULL,
    LocationId INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY(LocationId)
);

ALTER TABLE Restaurants ADD COLUMN LocationId INT;
ALTER TABLE Restaurants ADD CONSTRAINT FK_RestaurantsAddress FOREIGN KEY (LocationId) REFERENCES Address(LocationId);
INSERT INTO Address(Location, Borough) VALUES ("35 Downing St New York, NY 10014", "Manhattan");
INSERT INTO Restaurants(Restaurant_Name, FoodType, Overall_Rating, LocationId) VALUES ("Emily - West Village", "Burger", 4, 1);

