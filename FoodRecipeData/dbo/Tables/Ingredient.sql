CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [PictureUrl] NVARCHAR(MAX) NOT NULL, 
    [MesurementType] NVARCHAR(50) NOT NULL
)
