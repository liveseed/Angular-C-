    SELECT e.EventId,  Type, e.Name, Location, EventDate, r.Name, r.Price
	FROM dbo.Events AS e, dbo.Releases AS r
	WHERE e.EventId = r.EventId
	ORDER BY e.EventId

	SELECT e.EventId,  Type, e.Name, Location, EventDate, s.Name, s.URL
	FROM dbo.Events AS e, dbo.SocialNetworks AS s
	 WHERE e.EventId = s.EventId	
	ORDER BY e.EventId