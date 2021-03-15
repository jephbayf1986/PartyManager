CREATE PROCEDURE [dbo].[spGetPersonInfo]
	@PersonId int
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		 P.[Id]
		,[FirstName]
		,[LastName]
		,[DOB]
		,[Email]
		,[Phone]
		,[FavouriteDrinkId]
		,D.[Name] AS 'FavouriteDrink'
	FROM 
		Person P
	LEFT JOIN
		Drink D
			ON P.[FavouriteDrinkId] = D.[Id]
	WHERE
		P.[Id] = @PersonId

END