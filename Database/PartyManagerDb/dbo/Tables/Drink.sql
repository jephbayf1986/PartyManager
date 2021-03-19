CREATE TABLE [dbo].[Drink] (
    [Id]   INT IDENTITY   NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Drink_NameUnique] UNIQUE ([Name])
);

