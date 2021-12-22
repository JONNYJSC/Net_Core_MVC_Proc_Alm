using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAP_NetCoreApp.Models.Queries
{
    public class Roles : BaseQuery
    {
        public Roles() : base() { }

        public List<Role> GetAll()
        {
            using (var db = GetConnection())
            {
                return db.Query<Role>(@"select * from [Role]").ToList();
            }
        }

    }
}
