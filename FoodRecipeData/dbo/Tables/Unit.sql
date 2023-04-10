CREATE TABLE [dbo].[Unit]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL UNIQUE, 
    [Symbol] NVARCHAR(10) NOT NULL UNIQUE, 
    [MesurementType] NVARCHAR(100) NOT NULL, 
    [MetricUnitValue] REAL NOT NULL CHECK (MetricUnitValue > 0), 
    [MetricUnitId] INT CONSTRAINT [FK_UnitUnit] FOREIGN KEY ([MetricUnitId])
    REFERENCES Unit(Id)
)
