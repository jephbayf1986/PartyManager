CREATE PROCEDURE [dbo].[spGetPeople]
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		 [Id]
		,[FirstName]
		,[LastName]
		,[DOB]
	FROM 
		Person

END