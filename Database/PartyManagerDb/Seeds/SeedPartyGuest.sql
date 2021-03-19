CREATE TABLE #PartyGuest
(
	[Id]            INT NOT NULL,
    [PartyId]       INT NOT NULL,
    [PersonId]      INT NOT NULL,
    [ChosenDrinkId] INT NULL,
    [IsVIP]         BIT NOT NULL
)

INSERT INTO #PartyGuest
VALUES
     (1, 1, 1, NULL, 1)
    ,(2, 1, 2, NULL, 0)
    ,(3, 1, 3, 5, 0)
    ,(4, 1, 4, NULL, 1)
    ,(5, 1, 5, NULL, 1)
    ,(6, 1, 6, NULL, 0)
    ,(7, 1, 7, 3, 0)
    ,(8, 1, 8, NULL, 0)
    ,(9, 2, 2, NULL, 0)
    ,(10, 2, 4, NULL, 1)
    ,(11, 2, 8, NULL, 0)
    ,(12, 3, 5, NULL, 1)
    ,(13, 3, 7, 3, 0)

SET IDENTITY_INSERT PartyGuest ON;
GO

MERGE PartyGuest AS target  
USING #PartyGuest AS source 
    ON (target.[Id] = source.[Id])  
WHEN MATCHED THEN
    UPDATE SET [PartyId] = source.[PartyId]
              ,[PersonId] = source.[PersonId]
              ,[ChosenDrinkId] = source.[ChosenDrinkId]
              ,[IsVIP] = source.[IsVIP]
WHEN NOT MATCHED THEN  
    INSERT ([Id], [PartyId], [PersonId], [ChosenDrinkId], [IsVIP])
    VALUES (source.[Id]
           ,source.[PartyId]
           ,source.[PersonId]
           ,source.[ChosenDrinkId]
           ,source.[IsVIP]);  

SET IDENTITY_INSERT PartyGuest OFF;
GO

DROP TABLE #PartyGuest
GO