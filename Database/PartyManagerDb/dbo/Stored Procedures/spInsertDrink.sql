﻿CREATE PROCEDURE [dbo].[spInsertDrink]
	@Name NVARCHAR(100)
AS
BEGIN
	
	SET NOCOUNT ON

	INSERT INTO
		Drink 
			([Name])
	VALUES
		(@Name)

END