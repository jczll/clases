using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.DataAccess.Interfaces;
using Chinook.Entities.Base;

namespace Chinook.DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext pContext) : base(pContext)
        {

        }
    }
}
