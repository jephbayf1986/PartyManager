﻿CREATE PROCEDURE [dbo].[spGetPartyGuests]
	@PartyId INT
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT
		 P.[Id] AS PartyId
		,P.[Name] AS PartyName
		,P.[Location] AS PartyLocation
		,[StartTime]
		,N.[FirstName] AS GuestLFirstName
		,N.[LastName] AS GuestLastName
		,N.[DOB] AS GuestDOB
		,N.[Email] AS GuestEmail
		,N.[Phone] AS GuestPhone
		,G.[IsVIP]
		,G.[ChosenDrinkId]
		,D.[Name] AS ChosenDrink
	FROM 
		Party P
	INNER JOIN
		PartyGuest G
			ON G.[PartyId] = P.[Id]
	INNER JOIN
		Person N
			ON G.[PersonId] = N.[Id]
	LEFT JOIN
		Drink D
			ON G.[ChosenDrinkId] = D.[Id]
	WHERE 
		P.[Id] = @PartyId

END