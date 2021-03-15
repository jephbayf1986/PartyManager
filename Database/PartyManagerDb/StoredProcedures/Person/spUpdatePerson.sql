CREATE PROCEDURE [dbo].[spUpdatePerson]
	 @PersonId INT
	,@Email NVARCHAR(254) = NULL
	,@Phone NVARCHAR(20) = NULL
	,@FavouriteDrinkId INT = NULL
AS
BEGIN

	SET NOCOUNT ON

	UPDATE 
		Person
	SET
		 [Email] = ISNULL(@Email, [Email])
		,[Phone] = ISNULL(@Phone, [Phone])
		,[FavouriteDrinkId] = ISNULL(@FavouriteDrinkId, [FavouriteDrinkId])
	WHERE 
		[Id] = @PersonId

END
