CREATE PROCEDURE [dbo].[spInsertPerson]
	 @FirstName NVARCHAR(50)
	,@LastName NVARCHAR(50)
	,@DOB DATETIME
	,@Email NVARCHAR(254)
	,@Phone NVARCHAR(20)
AS
BEGIN

	SET NOCOUNT ON

	INSERT INTO 
		Person
			(FirstName
			,LastName
			,DOB
			,Email
			,Phone)
	VALUES 
		(@FirstName
		,@LastName
		,@DOB
		,@Email
		,@Phone)

	SELECT SCOPE_IDENTITY()

END
