using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace Multitasking.Data
{
    //Make it singleton?
    //TODO: Refactor for using with IoC
    internal class SqlBaseRepository
    {
        private readonly string _dbFileName = "storage.db";
        private readonly string _filePath;

        public SqlBaseRepository()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _dbFileName);
        }

        public SqliteConnection GetSqlConnection()
        {
            return new SqliteConnection("Data Source=" + _filePath);
        }
    }
}
