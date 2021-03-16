CREATE TABLE [dbo].[Party] (
    [Id]        INT            NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Location]  NVARCHAR (100) NOT NULL,
    [StartTime] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

