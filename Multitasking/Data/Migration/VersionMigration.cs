namespace Multitasking.Data.Migration
{
    internal abstract class VersionMigration
    {
        public VersionMigration(int version, string sqlScript)
        {
            Version = version;
            SqlScript = sqlScript;
            Executed = false;
        }

        public int Version { get; }
        public string SqlScript { get; }
        public bool Executed { get; set; }
    }
}
