using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess.Interfaces
{
    public interface IGeneryRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void update(TEntity entity);
        void Remove(TEntity entity);
        int Count();
    }
}
