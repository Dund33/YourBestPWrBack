using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace YourBestPWrBack.Factories
{
    public class MySqlConnectionFactory : SqlConnectionFactory
    { 


        public MySqlConnectionFactory(string connectionString) : base(connectionString)
        { }

        public override DbConnection Create()
            => new MySqlConnection(_connectionString);
        
    }
}
