CREATE PROCEDURE [dbo].[spUpdateParty]
	@Id INT,
	@Name NVARCHAR(100),
	@Location NVARCHAR(100),
	@StartTime DATETIME
AS
BEGIN

	UPDATE 
		Party
	SET
		[Name] = @Name,
		[Location] = @Location,
		[StartTime] = @StartTime
	WHERE 
		[Id] = @Id

END