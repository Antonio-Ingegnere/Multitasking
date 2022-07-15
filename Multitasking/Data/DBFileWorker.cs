using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitasking.Data
{
    internal class DBFileWorker
    {
        private readonly string _dbFileName = "storage.db";
        private readonly string _filePath;

        public DBFileWorker()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _dbFileName);
        }
        private bool IsFileExist()
        {
            try
            {
                return File.Exists(_filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateFile()
        {
            try
            {
                using (File.Create(_filePath)) ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Initialize()
        {
            if (!IsFileExist())
                CreateFile();
        }
    }
}
