using Multitasking.Data.Migration;

using Microsoft.Data.Sqlite;
using Dapper;

namespace Multitasking.Data
{
    internal class DbMigration
    {
        private readonly SqliteConnection _connection;
        private readonly IList<VersionMigration> _migrationFlow = new List<VersionMigration>();

        public DbMigration(SqliteConnection connection)
        {
            _migrationFlow.Add(new Version01Migration());
            _connection = connection;

            _connection.Open();
        }

        private bool IsMigrationRequired()
        {
            var countVersionNumberTables =
                _connection.ExecuteScalar<int>("SELECT count(name) FROM sqlite_master WHERE type='table' AND name='Version'");

            if (countVersionNumberTables <= 0)
                return true;


            var existingAppVersionNumber = _connection.ExecuteScalar<int>("SELECT VersionNumber FROM Version ORDER by VersionNumber LIMIT 1");

            var newVersion = _migrationFlow.Max(item => item.Version);

            return newVersion > existingAppVersionNumber;
        }

        public void UpdateDbIfNeeded()
        {
            if (IsMigrationRequired())
            {
                ExecuteMigration();
            }
        }

        private void ExecuteMigration()
        {
            int? lastAppliedVersion = null;

            while (_migrationFlow.Any(item => !item.Executed))
            {
                var itemToExecute = _migrationFlow.Where(item => !item.Executed).MinBy(item => item.Version);

                if (itemToExecute != null)
                {
                    ApplyVersionMigration(itemToExecute);
                    lastAppliedVersion = itemToExecute.Version;
                }
                else
                    break;
            }

            if (lastAppliedVersion.HasValue)
                SetMigrationVersion(lastAppliedVersion.Value);
        }

        private void ApplyVersionMigration(VersionMigration versionMigration)
        {
            if (_connection != null)
            {
                _connection.Execute(versionMigration.SqlScript);

                versionMigration.Executed = true;
            }
        }

        private void SetMigrationVersion(int versionNumber)
        {
            //Clearing version number
            _connection.Execute("DELETE FROM Version");

            //Set proper version number
            _connection.Execute($"INSERT INTO Version(VersionNumber) VALUES({versionNumber})");

        }
    }
}
