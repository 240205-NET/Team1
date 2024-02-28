CREATE SCHEMA RecipeFinder;
GO






CREATE TABLE [RecipeFinder].[User]
(
    [ID] INT PRIMARY KEY,
    [Username] VARCHAR(255) UNIQUE NOT NULL,
    [Password] VARCHAR(255) NOT NULL,
    [First_name] VARCHAR(255) NOT NULL,
    [Last_name] VARCHAR(255) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
);

CREATE TABLE [RecipeFinder].[Meal]
(
    [UserID] INT NOT NULL,
    [ID] INT PRIMARY KEY,
    [Name] VARCHAR(255) NOT NULL,
    [Category] VARCHAR(255) NOT NULL,
    [Area] VARCHAR(255) NOT NULL,
    [Instructions] VARCHAR(255) NOT NULL,
    [Meal_thumb] VARCHAR(255),
    [Tags] VARCHAR(255),
    [Youtube] VARCHAR(255),
    [Ingredient1] VARCHAR(255) NOT NULL,
    [Ingredient2] VARCHAR(255),
    [Ingredient3] VARCHAR(255),
    [Ingredient4] VARCHAR(255),
    [Ingredient5] VARCHAR(255),
    [Ingredient6] VARCHAR(255),
    [Ingredient7] VARCHAR(255),
    [Ingredient8] VARCHAR(255),
    [Ingredient9] VARCHAR(255),
    [Ingredient10] VARCHAR(255),
    [Ingredient11] VARCHAR(255),
    [Ingredient12] VARCHAR(255),
    [Ingredient13] VARCHAR(255),
    [Ingredient14] VARCHAR(255),
    [Ingredient15] VARCHAR(255),
    [Measure1] VARCHAR(255) NOT NULL,
    [Measure2] VARCHAR(255),
    [Measure3] VARCHAR(255),
    [Measure4] VARCHAR(255),
    [Measure5] VARCHAR(255),
    [Measure6] VARCHAR(255),
    [Measure7] VARCHAR(255),
    [Measure8] VARCHAR(255),
    [Measure9] VARCHAR(255),
    [Measure10] VARCHAR(255),
    [Measure11] VARCHAR(255),
    [Measure12] VARCHAR(255),
    [Measure13] VARCHAR(255),
    [Measure14] VARCHAR(255),
    [Measure15] VARCHAR(255),
    FOREIGN KEY ([UserID]) REFERENCES [RecipeFinder].[User](ID)
);
GO

DROP TABLE [RecipeFinder].[Meal];
DROP TABLE [RecipeFinder].[MealPlan];

CREATE TABLE [RecipeFinder].[Ingredient1]
(
    [ID] INT PRIMARY KEY,
    [Name] VARCHAR(255),
);

DROP TABLE [RecipeFinder].[Ingredient1];

CREATE TABLE [RecipeFinder].[MealPlan]
(
    [UserID] INT,
    [MealID] INT,
    [Date] DATETIME,
    PRIMARY KEY([UserID],[MealID],[Date]),
    FOREIGN KEY ([UserID]) REFERENCES [RecipeFinder].[User](ID),
    FOREIGN KEY ([MealID]) REFERENCES [RecipeFinder].[Meal](ID)
);


INSERT INTO [RecipeFinder].[Meal] 
(ID, Name, Category, Area, Instructions, Meal_thumb, Tags, Youtube, Ingredient1, Measure1, Ingredient2, Measure2, Ingredient3, Measure3, Ingredient4, Measure4, Ingredient5, Measure5, Ingredient6, Measure6, Ingredient7, Measure7, Ingredient8, Measure8, Ingredient9, Measure9, Ingredient10, Measure10, Ingredient11, Measure11, Ingredient12, Measure12, Ingredient13, Measure13, Ingredient14, Measure14, Ingredient15, Measure15)
VALUES 
(1, 1, 'Meal 1', 'Category 1', 'Area 1', 'Instructions 1', 'Thumb 1', 'Tag 1', 'Youtube 1', 'Ingredient 1', 'Measure 1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO [RecipeFinder].[Meal] 
(UserID, ID, Name, Category, Area, Instructions, Meal_thumb, Tags, Youtube, Ingredient1, Measure1, Ingredient2, Measure2, Ingredient3, Measure3, Ingredient4, Measure4, Ingredient5, Measure5, Ingredient6, Measure6, Ingredient7, Measure7, Ingredient8, Measure8, Ingredient9, Measure9, Ingredient10, Measure10, Ingredient11, Measure11, Ingredient12, Measure12, Ingredient13, Measure13, Ingredient14, Measure14, Ingredient15, Measure15)
VALUES 
(1, 2, 'Meal 2', 'Category 2', 'Area 2', 'Instructions 2', 'Thumb 2', 'Tag 2', 'Youtube 2', 'Ingredient 2', 'Measure 2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO [RecipeFinder].[Meal] 
(UserID, ID, Name, Category, Area, Instructions, Meal_thumb, Tags, Youtube, Ingredient1, Measure1, Ingredient2, Measure2, Ingredient3, Measure3, Ingredient4, Measure4, Ingredient5, Measure5, Ingredient6, Measure6, Ingredient7, Measure7, Ingredient8, Measure8, Ingredient9, Measure9, Ingredient10, Measure10, Ingredient11, Measure11, Ingredient12, Measure12, Ingredient13, Measure13, Ingredient14, Measure14, Ingredient15, Measure15)
VALUES 
(1, 3, 'Meal 3', 'Category 3', 'Area 3', 'Instructions 3', 'Thumb 3', 'Tag 3', 'Youtube 3', 'Ingredient 3', 'Measure 3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO [RecipeFinder].[Meal] 
(UserID, ID, Name, Category, Area, Instructions, Meal_thumb, Tags, Youtube, Ingredient1, Measure1, Ingredient2, Measure2, Ingredient3, Measure3, Ingredient4, Measure4, Ingredient5, Measure5, Ingredient6, Measure6, Ingredient7, Measure7, Ingredient8, Measure8, Ingredient9, Measure9, Ingredient10, Measure10, Ingredient11, Measure11, Ingredient12, Measure12, Ingredient13, Measure13, Ingredient14, Measure14, Ingredient15, Measure15)
VALUES 
(1, 4, 'Meal 4', 'Category 4', 'Area 4', 'Instructions 4', 'Thumb 4', 'Tag 4', 'Youtube 4', 'Ingredient 4', 'Measure 4', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO [RecipeFinder].[Meal] 
(UserID, ID, Name, Category, Area, Instructions, Meal_thumb, Tags, Youtube, Ingredient1, Measure1, Ingredient2, Measure2, Ingredient3, Measure3, Ingredient4, Measure4, Ingredient5, Measure5, Ingredient6, Measure6, Ingredient7, Measure7, Ingredient8, Measure8, Ingredient9, Measure9, Ingredient10, Measure10, Ingredient11, Measure11, Ingredient12, Measure12, Ingredient13, Measure13, Ingredient14, Measure14, Ingredient15, Measure15)
VALUES 
(1, 5, 'Meal 5', 'Category 5', 'Area 5', 'Instructions 5', 'Thumb 5', 'Tag 5', 'Youtube 5', 'Ingredient 5', 'Measure 5', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

SELECT * FROM [RecipeFinder].[Meal];

INSERT INTO [RecipeFinder].[User]
(ID, Username, Password, First_name, Last_name, Email)
VALUES
(1, 'blabla', 'blabla', 'blablabla', 'blablalbla','blallalaa');

SELECT * FROM [RecipeFinder].[User];