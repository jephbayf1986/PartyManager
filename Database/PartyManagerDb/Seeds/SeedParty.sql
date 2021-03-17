CREATE TABLE #Party
(
    [Id]        INT            NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Location]  NVARCHAR (100) NOT NULL,
    [StartTime] DATETIME       NULL
);

INSERT INTO #Party
VALUES (1, 'End of Lockdown Big Bash', 'Everywhere', '2034-08-02 08:00'),
       (2, 'New Years Eve', 'London', '2021-12-31 11:00'),
       (3, 'MCS Decomissioning Celebration', 'Warrington', '2076-04-08 17:00'),
       (4, 'Halloween', 'Liverpool', '2021-11-05 19:00');

SET IDENTITY_INSERT Party ON;
GO

INSERT INTO Party 
          ([Id]
          ,[Name]
          ,[Location]
          ,[StartTime])
SELECT [Id]
      ,[Name]
      ,[Location]
      ,[StartTime]
FROM #Party
WHERE [Id] NOT IN (SELECT [Id] From Party)

SET IDENTITY_INSERT Party OFF;
GO

DROP TABLE #PARTY
GO