using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Factories
{
    public class SqLiteConnectionFactory : SqlConnectionFactory
    {
        public SqLiteConnectionFactory(string connectionString) : base(connectionString)
        { }

        public override DbConnection Create()
            => new SqliteConnection(_connectionString);
    }
}
