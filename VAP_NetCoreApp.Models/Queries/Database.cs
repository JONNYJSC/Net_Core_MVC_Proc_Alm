using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAP_NetCoreApp.Models.Queries
{
    public class Database
    {
        public Users Users { get; set; }
        public Roles Roles { get; set; }

        public Database()
        {
            Users = new Users();
            Roles = new Roles();
        }
    }
}
