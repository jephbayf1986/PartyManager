CREATE PROCEDURE [dbo].[spUpdatePartyGuest]
	 @PartyGuestId INT
	,@ChosenDrinkId INT = NULL
	,@IsVIP BIT = NULL
AS
BEGIN
	
	UPDATE
		PartyGuest
	SET
		 [ChosenDrinkId] = ISNULL(@ChosenDrinkId, [ChosenDrinkId])
		,[IsVIP] = ISNULL(@IsVIP, [IsVIP])
	WHERE 
		Id = @PartyGuestId

END