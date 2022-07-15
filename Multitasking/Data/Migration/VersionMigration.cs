namespace Multitasking.Data.Migration
{
    internal abstract class VersionMigration
    {
        private readonly string _sqlScript;
        private readonly int _version;

        public VersionMigration(int version, string sqlScript)
        {
            _version = version;
            _sqlScript = sqlScript;
            Executed = false;
        }

        public int Version { get { return _version; } }
        public string SqlScript { get { return _sqlScript; } }
        public bool Executed { get; set; }
    }
}
