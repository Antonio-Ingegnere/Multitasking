using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multitasking.Data.Migration;

using Microsoft.Data.Sqlite;

namespace Multitasking.Data
{

    internal class DBMigration
    {
        private readonly SqliteConnection _connection;
        private IList<VersionMigration> _migrationFlow = new List<VersionMigration>();

        public DBMigration(SqliteConnection connection)
        {
            _migrationFlow.Add(new Version01Migration());
            _connection = connection;

            _connection.Open();
        }

        public void ExecuteMigration()
        {
            while (_migrationFlow.Any(item => !item.Executed))
            {
                var itemToExecute = _migrationFlow.Where(item => !item.Executed).MinBy(item => item.Version);

                if (itemToExecute != null)
                    ApplyVerionMigration(itemToExecute);
                else
                    break;
            }
        }

        private void ApplyVerionMigration(VersionMigration versionMigration)
        {
            if (_connection != null)
            {
                var command = _connection.CreateCommand();
                command.CommandText = versionMigration.SqlScript;
                command.ExecuteNonQuery();

                versionMigration.Executed = true;
            }
        }
    }
}
