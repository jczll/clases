using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataBase
    {
        public IDbConnection CreateConnection()
        {
            string cadenaConexion = "Data Source=.;" +
                                    "Initial Catalog=Chinook; " +
                                    "User ID=sa; Password=softpad01";
            return new SqlConnection(cadenaConexion);
        }
    }
}
