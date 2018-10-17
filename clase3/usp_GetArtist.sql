exec usp_GetArtists '%pl%'
go

Create procedure usp_GetArtists
(
   @FiltroByName nvarchar(100)
)
as
begin
   Select [Name],
          ArtistId 
		  from Artist with (nolock) 
		  where [Name] like @FiltroByName
end
go

Create procedure usp_InsertArtist
(
   @Name nvarchar(120)
)
as
begin
   insert into Artist([Name]) values(@Name)
   Select SCOPE_IDENTITY()

end
go

Create procedure usp_DeleteArtist
(
   @ArtistID int
)
as
begin 
   delete artist where ArtistID=@ArtistID
end
go     