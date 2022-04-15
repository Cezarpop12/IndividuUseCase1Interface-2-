using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQLSERVER
{
    public class DatabaseConfig
    {
        public class Rootobject
        {
            public Databaseconfig DatabaseConfig { get; set; }
        }

        public class Databaseconfig
        {
            public string ConnectionString { get; set; }
        }
    }
}
