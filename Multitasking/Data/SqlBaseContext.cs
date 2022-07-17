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
    internal class SqlBaseContext : IDisposable
    {
        private const string _dbFileName = "storage.db";
        private readonly string _filePath;
        private readonly SqliteConnection _sqliConnection;
        private bool disposedValue;

        public SqlBaseContext() : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _dbFileName))
        {
        }

        public SqlBaseContext(string filePath)
        {
            _filePath = filePath;
            _sqliConnection = new SqliteConnection("Data Source=" + _filePath);
        }

        public SqliteConnection GetSqlConnection()
        {
            if (_sqliConnection.State != System.Data.ConnectionState.Open)
                _sqliConnection.Open();

            return _sqliConnection;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _sqliConnection?.Close();
                    _sqliConnection?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SqlBaseContext()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
