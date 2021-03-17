CREATE TABLE #Drink
(
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (100) NOT NULL
)

INSERT INTO #Drink
VALUES 
     (1, 'Red Wine')
    ,(2, 'White Wine')
    ,(3, 'Vodka Martini')
    ,(4, 'Blue WKD')
    ,(5, 'Lime Cordial')

SET IDENTITY_INSERT Drink ON;
GO

MERGE Drink AS target  
USING #Drink AS source 
    ON (target.[Id] = source.[Id])  
WHEN MATCHED THEN
    UPDATE SET [Name] = source.[Name]  
WHEN NOT MATCHED THEN  
    INSERT ([Id], [Name])
    VALUES (source.[Id], source.[Name]);  

SET IDENTITY_INSERT Drink OFF;
GO

DROP TABLE #Drink
GO