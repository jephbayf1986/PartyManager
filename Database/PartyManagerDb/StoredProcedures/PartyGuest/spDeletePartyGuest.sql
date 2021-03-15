CREATE PROCEDURE [dbo].[spDeletePartyGuest]
	@PartyGuestId INT
AS
BEGIN
	
	SET NOCOUNT ON

	DELETE
	FROM
		PartyGuest
	WHERE
		Id = @PartyGuestId

END