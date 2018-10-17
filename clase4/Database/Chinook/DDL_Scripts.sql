--PROBANDO EL SP
EXEC usp_GetArtists '%PL%'
GO

CREATE PROCEDURE usp_GetArtists
(
	@FiltroByName NVARCHAR(100)
)
AS
BEGIN
	SELECT 
		[Name], 
		ArtistId
	FROM Artist WITH(NOLOCK)
	WHERE [Name] LIKE @FiltroByName
END

GO

CREATE PROCEDURE usp_InsertArtist
(
	@Name NVARCHAR(120)
)
AS
BEGIN

	INSERT INTO Artist([Name])
	VALUES(@Name)
	
	SELECT SCOPE_IDENTITY()
END

