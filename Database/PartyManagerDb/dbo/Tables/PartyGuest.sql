CREATE TABLE [dbo].[PartyGuest] (
    [Id]            INT IDENTITY NOT NULL,
    [PartyId]       INT NOT NULL,
    [PersonId]      INT NOT NULL,
    [ChosenDrinkId] INT NULL,
    [IsVIP]         BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PartyGuest_Drink] FOREIGN KEY ([ChosenDrinkId]) REFERENCES [dbo].[Drink] ([Id]),
    CONSTRAINT [FK_PartyGuest_Party] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Party] ([Id]),
    CONSTRAINT [FK_PartyGuest_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [CK_PartyGuest_PartyPersonUnique] UNIQUE ([PartyId], [PersonId])
);


GO

CREATE INDEX [IX_PartyGuest_PartyId] ON [dbo].[PartyGuest] ([PartyId])
GO
CREATE INDEX [IX_PartyGuest_PersonId] ON [dbo].[PartyGuest] ([PersonId])
GO