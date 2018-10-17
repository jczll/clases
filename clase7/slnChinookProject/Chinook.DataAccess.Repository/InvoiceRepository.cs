using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.DataAccess.Interfaces;
using Chinook.Entities.Base;
using Chinook.Entities.Queries;

namespace Chinook.DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext pContext) : base(pContext)
        {

        }

        public IEnumerable<CustumerIdAddressQuery> GetCustumerIdAddress(int CustomerId)
        {
            return context.Database.SqlQuery<CustumerIdAddressQuery>("sp_CustomerAddress @CustomerId", new SqlParameter("@CustomerId", CustomerId)).ToList();
        }
    }
}
