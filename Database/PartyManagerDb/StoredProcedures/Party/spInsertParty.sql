﻿CREATE PROCEDURE [dbo].[spInsertParty]
	 @Name NVARCHAR(100)
	,@Location NVARCHAR(100)
	,@StartTime DATETIME
AS
BEGIN

	SET NOCOUNT ON

	INSERT INTO 
		Party
	VALUES 
		(@Name
		,@Location
		,@StartTime)

	SELECT SCOPE_IDENTITY()

END