CREATE PROCEDURE [dbo].[spInsertPerson]
	 @FirstName NVARCHAR(50)
	,@LastName NVARCHAR(50)
	,@DOB DATETIME
	,@Email NVARCHAR(254) = NULL
	,@Phone NVARCHAR(20) = NULL
	,@FavouriteDrinkId INT = NULL
AS
BEGIN

	SET NOCOUNT ON

	INSERT INTO 
		Person
			(FirstName
			,LastName
			,DOB
			,Email
			,Phone
			,FavouriteDrinkId)
	VALUES 
		(@FirstName
		,@LastName
		,@DOB
		,@Email
		,@Phone
		,@FavouriteDrinkId)

	SELECT SCOPE_IDENTITY()

END
