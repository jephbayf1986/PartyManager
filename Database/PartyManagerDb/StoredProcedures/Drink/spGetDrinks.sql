CREATE PROCEDURE [dbo].[spGetDrinks]
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT
		 [Id]
		,[Name]
	FROM
		Drink

END