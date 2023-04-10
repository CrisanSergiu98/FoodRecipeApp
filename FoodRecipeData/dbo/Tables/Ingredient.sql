CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryId] INT NOT NULL CONSTRAINT FK_CategoryIngredient FOREIGN KEY ([CategoryId])
    REFERENCES Ingredient_Category(Id) , 
    [Name] NVARCHAR(100) NOT NULL UNIQUE, 
    [Description] NVARCHAR(500) NOT NULL, 
    [PictureUrl] NVARCHAR(2048) NOT NULL, 
    [MesurementType] NVARCHAR(100) NOT NULL,

    
)
