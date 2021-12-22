using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAP_NetCoreApp.Models.Queries
{
    public class BaseQuery
    {
        internal string _connectionString;

        public BaseQuery()
        {
            //_connectionString = Environment.GetEnvironmentVariable("VAP_Demo_ConnStr");
            _connectionString = "Server=JONNYJSC-DELL; Initial Catalog=VAP_NetCoreApp; User ID=sa; Password=admin123; Trusted_Connection=false";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public class BaseResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public int ObjectID { get; set; }
        }
    }
}
