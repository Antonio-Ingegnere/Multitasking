using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Multitasking.Data
{
    //Make it singleton?
    //TODO: Refactor for using with IoC
    internal class SqlBaseContext : IDisposable
    {
        private const string DbFileName = "storage.db";
        private readonly string _filePath;
        private readonly SqliteConnection _sqlConnection;
        private bool _disposedValue;

        public SqlBaseContext() : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName))
        {
        }

        public SqlBaseContext(string filePath)
        {
            _filePath = filePath;
            _sqlConnection = new SqliteConnection("Data Source=" + _filePath);
        }

        private SqliteConnection GetSqlConnection()
        {
            if (_sqlConnection.State != System.Data.ConnectionState.Open)
                _sqlConnection.Open();

            return _sqlConnection;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _sqlConnection?.Close();
                    _sqlConnection?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
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

        #region Wrapping connection methonds

        public T ExecuteScalar<T>(string sqlQuery)
        {
            return _sqlConnection.ExecuteScalar<T>(sqlQuery);
        }

        public int Execute(string sqlQuery)
        {
            return _sqlConnection.Execute(sqlQuery);
        }

        #endregion
    }
}
