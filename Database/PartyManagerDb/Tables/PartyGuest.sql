CREATE TABLE [dbo].[PartyGuest]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[PartyId] INT NOT NULL,
	[PersonId] INT NOT NULL,
	[ChosenDrinkId] INT NULL,
	[IsVIP] BIT NOT NULL, 
    CONSTRAINT [FK_PartyGuest_Party] FOREIGN KEY ([PartyId]) REFERENCES [Party]([Id]), 
    CONSTRAINT [FK_PartyGuest_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    CONSTRAINT [FK_PartyGuest_Drink] FOREIGN KEY ([ChosenDrinkId]) REFERENCES [Drink]([Id])
)
