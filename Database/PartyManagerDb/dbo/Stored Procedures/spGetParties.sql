CREATE PROCEDURE [dbo].[spGetParties]
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		 P.[Id]
		,[Name]
		,[Location]
		,[StartTime]
		,COUNT(G.Id) AS NumberOfGuests
		,SUM(CONVERT(INT, IsVIP)) AS NumberOfVIPs
		,SUM(CASE WHEN G.[ChosenDrinkId] IS NULL THEN 1 ELSE 0 END) AS NumberOfDrinkChoicesOutstanding
	FROM 
		Party P
	LEFT JOIN 
		PartyGuest G
			ON P.[Id] = G.[PartyId]
	GROUP BY
		 P.[Id]
		,[Name]
		,[Location]
		,[StartTime]

END