using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace YourBestPWrBack.Factories
{
    public abstract class SqlConnectionFactory
    {
        protected readonly string _connectionString;
        protected SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public abstract DbConnection Create();
    }
}
