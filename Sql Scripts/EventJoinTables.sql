    SELECT e.EventId, Location, Type, e.Name, EventDate, r.Name, r.Price, s.Name, s.URL
	FROM dbo.Events AS e
	FULL JOIN dbo.Releases AS r
    ON e.EventId = r.EventId
    FULL JOIN dbo.SocialNetworks AS s
    ON r.EventId = s.EventId	