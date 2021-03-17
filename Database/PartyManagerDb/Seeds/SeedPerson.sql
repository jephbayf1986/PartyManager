CREATE TABLE #Person
(
	[Id]               INT            NOT NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [DOB]              DATE           NOT NULL,
    [Email]            NVARCHAR (254) NULL,
    [Phone]            NVARCHAR (20)  NULL,
    [FavouriteDrinkId] INT            NULL
)

INSERT INTO #Person
VALUES
     (1, 'Fred', 'Flintstone', '1984-04-15', 'fred.f@bedrock.com', '07812123123', 4)
    ,(2, 'Frida', 'Carlo', '1979-05-15', null, null, null)
    ,(3, 'Phil', 'Collins', '1966-05-15', 'phil@genesis.com', null, null)
    ,(4, 'Audrey', 'Hepburn', '1929-01-12', null, null, 2)
    ,(5, 'Winnie', 'The Pooh', '1981-12-28', 'winnie@poohbooks.com', null, null)
    ,(6, 'Mark', 'Anthony', '1975-04-06', null, null, null)
    ,(7, 'James', 'Bond', '1979-05-29', 'bnd@sis.com', null, 3)
    ,(8, 'Isaac', 'Newton', '1966-05-11', '', '', null)

SET IDENTITY_INSERT Person ON;
GO

MERGE Person AS target  
USING #Person AS source 
    ON (target.[Id] = source.[Id])  
WHEN MATCHED THEN
    UPDATE SET [FirstName] = source.[FirstName]  
              ,[LastName] = source.[LastName]  
              ,[DOB] = source.[DOB]  
              ,[Email] = source.[Email]  
              ,[Phone] = source.[Phone]  
              ,[FavouriteDrinkId] = source.[FavouriteDrinkId]  
WHEN NOT MATCHED THEN  
    INSERT ([Id], [FirstName], [LastName], [DOB], [Email], [Phone], [FavouriteDrinkId])
    VALUES (source.[Id]
           ,source.[FirstName]
           ,source.[LastName]
           ,source.[DOB]
           ,source.[Email]
           ,source.[Phone]
           ,source.[FavouriteDrinkId]);  

SET IDENTITY_INSERT Person OFF;
GO

DROP TABLE #Person
GO