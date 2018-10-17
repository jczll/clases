using Chinook.Entities.Base;
using Chinook.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Interfaces
{
    public interface IAlbumRepository: IGeneryRepository<Album>
    {
        IEnumerable<AlbunesVendidosQuery> GetAlbunesVendidos();
    }
}
