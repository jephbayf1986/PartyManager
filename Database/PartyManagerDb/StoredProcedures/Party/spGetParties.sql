CREATE PROCEDURE [dbo].[spGetParties]
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		 P.[Id]
		,[Name]
		,[Location]
		,[StartTime]
		,COUNT(G.Id) NumberOfGuests
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