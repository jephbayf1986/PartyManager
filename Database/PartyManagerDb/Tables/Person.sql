CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[DOB] DATE NOT NULL,
	[Email] NVARCHAR(254) NULL,
	[Phone] NVARCHAR(20) NULL,
	[FavouriteDrinkId] INT NULL, 
    CONSTRAINT [FK_Person_Drink] FOREIGN KEY ([FavouriteDrinkId]) REFERENCES [Drink]([Id])
)
