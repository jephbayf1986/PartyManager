CREATE PROCEDURE [dbo].[spUpdateParty]
	 @PartyId INT
	,@Name NVARCHAR(100) = NULL
	,@Location NVARCHAR(100) = NULL
	,@StartTime DATETIME = NULL
AS
BEGIN

	SET NOCOUNT ON

	UPDATE 
		Party
	SET
		 [Name] = ISNULL(@Name, [Name])
		,[Location] = ISNULL(@Location, [Location])
		,[StartTime] = ISNULL(@StartTime, [StartTime])
	WHERE 
		[Id] = @PartyId

END