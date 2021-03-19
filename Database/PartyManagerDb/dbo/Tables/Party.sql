CREATE TABLE [dbo].[Party] (
    [Id]        INT IDENTITY   NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Location]  NVARCHAR (100) NOT NULL,
    [StartTime] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [CK_Party_NameUnique] UNIQUE ([Name])
);

