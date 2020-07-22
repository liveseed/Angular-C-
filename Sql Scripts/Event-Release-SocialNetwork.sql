    SELECT e.EventId,  Type, e.Name, Location, EventDate, r.Name, r.Price
	FROM dbo.Events AS e
	FULL JOIN dbo.Releases AS r
	ON e.EventId = r.EventId
	ORDER BY e.EventId

	SELECT e.EventId,  Type, e.Name, Location, EventDate, s.Name, s.URL
	FROM dbo.Events AS e
	FULL JOIN dbo.SocialNetworks AS s
    ON e.EventId = s.EventId
	/*WHERE e.EventId = s.EventId*/	
	ORDER BY e.EventId
		
	SELECT h.Name, h.HighLight, s.Name, s.URL
	FROM dbo.Headlines AS h
	FULL JOIN dbo.SocialNetworks AS s
    ON h.HeadlineId = s.HeadlineId
	/*WHERE e.EventId = s.EventId*/	
	ORDER BY h.HeadlineId
		