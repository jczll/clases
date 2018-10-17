create procedure usp_GetListByName
(
   @Name NVARCHAR(120)
)
as
begin
SELECT ArtistId,[Name] from Artist where Name like @Name
end