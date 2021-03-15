﻿CREATE PROCEDURE [dbo].[spInsertPartyGuest]
	 @PartyId INT
	,@PersonId INT
	,@IsVIP BIT = 0
	,@ChosenDrinkId INT = NULL
AS
BEGIN
	
	SET NOCOUNT ON

	INSERT INTO
		PartyGuest
	VALUES 
		(@PartyId
		,@PersonId
		,@ChosenDrinkId
		,@IsVIP)
		
	SELECT SCOPE_IDENTITY()

END