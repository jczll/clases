exec usp_getAlbunesVendidos

create procedure usp_getAlbunesVendidos
as
begin
SELECT dbo.Playlist.Name AS PlaylistName,
       dbo.Track.Name AS TrackName,        
	   dbo.Album.Title AS AlbumName, 
	   dbo.Artist.Name AS ArtistName, 
	   sum(dbo.InvoiceLine.Quantity) as TotalQuantity 
FROM  dbo.Album INNER JOIN
      dbo.Artist ON dbo.Album.ArtistId = dbo.Artist.ArtistId INNER JOIN
      dbo.Invoice INNER JOIN
      dbo.Customer ON dbo.Invoice.CustomerId = dbo.Customer.CustomerId INNER JOIN
      dbo.InvoiceLine ON dbo.Invoice.InvoiceId = dbo.InvoiceLine.InvoiceId INNER JOIN
      dbo.PlaylistTrack INNER JOIN
      dbo.Playlist ON dbo.PlaylistTrack.PlaylistId = dbo.Playlist.PlaylistId INNER JOIN
      dbo.Track ON dbo.PlaylistTrack.TrackId = dbo.Track.TrackId ON dbo.InvoiceLine.TrackId = dbo.Track.TrackId ON dbo.Album.AlbumId = dbo.Track.AlbumId
group by
      dbo.Playlist.Name,
	  dbo.track.Name,
	  dbo.Album.Title,
	  dbo.Artist.Name 
order by 
      dbo.Playlist.Name asc,
	  dbo.track.Name asc,
	  dbo.Album.Title asc,
	  dbo.Artist.Name asc 
end
