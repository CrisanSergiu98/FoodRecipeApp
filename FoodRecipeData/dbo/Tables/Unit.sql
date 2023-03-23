CREATE TABLE [dbo].[Unit]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Symbol] NVARCHAR(50) NOT NULL, 
    [MesurementType] NVARCHAR(50) NOT NULL, 
    [MetricUnitValue] REAL NOT NULL, 
    [MetricUnitId] INT NOT NULL
)
