CREATE TABLE [dbo].[Party] (
    [Id]        INT IDENTITY   NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Location]  NVARCHAR (100) NOT NULL,
    [StartTime] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

