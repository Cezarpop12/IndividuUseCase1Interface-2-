using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DALMSSQLSERVER
{
    public class Database : DatabaseConfig
    {
        private string data = File.ReadAllText(@"C:\Users\mrcha\OneDrive - Office 365 Fontys\Documents\IndividuUseCase1Interface (2)\DalMemoryStore\Ww.json");
        private Rootobject? root;
        public SqlConnection connection;

        public void OpenConnection()
        {
            root = JsonSerializer.Deserialize<Rootobject>(data);
            if (root != null)
            {
                connection = new SqlConnection(root.DatabaseConfig.ConnectionString);
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}

