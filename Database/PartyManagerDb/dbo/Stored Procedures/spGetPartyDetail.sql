CREATE PROCEDURE [dbo].[spGetPartyDetail]
	@PartyId int
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		 [Id]
		,[Name]
		,[Location]
		,[StartTime]
	FROM 
		Party
	WHERE 
		[Id] = @PartyId

END