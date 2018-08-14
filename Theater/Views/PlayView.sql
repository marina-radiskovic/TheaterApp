CREATE VIEW [dbo].[PlayView]
	AS 
SELECT p.*, 
(SELECT STUFF
       (
        (SELECT ', ' + a.FirstName + ' ' + a.LastName
            FROM
            Actor AS a
			LEFT JOIN PlayActor AS pa ON pa.ActorId = a.Id
            WHERE pa.PlayId = p.Id
            FOR XML PATH('')
            ),1,1,''
       )) AS Actors
FROM Play AS p
