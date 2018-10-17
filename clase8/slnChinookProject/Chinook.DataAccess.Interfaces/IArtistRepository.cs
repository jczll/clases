using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Interfaces
{
    public interface IArtistRepository: IGeneryRepository<Artist>
    {
        IEnumerable<Artist> GetListByName(string name);
        IEnumerable<Artist> GetListByNameStore(string name);
    }
}
