CREATE TABLE [dbo].[Recipe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(100) unique NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    [Published] BIT NOT NULL ,
    [PictureUrl] NVARCHAR(2048) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [CategoryId] INT NOT NULL CONSTRAINT FK_CategoryRecipe FOREIGN KEY ([CategoryId])
    REFERENCES Recipe_Category(Id), 
    [UserId] NVARCHAR(50) NOT NULL,

    
)
