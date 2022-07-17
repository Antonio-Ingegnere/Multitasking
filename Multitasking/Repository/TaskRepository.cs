using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multitasking.Data;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Multitasking.Repository
{
    internal class TaskRepository
    {
        private readonly SqlBaseContext _context;

        public TaskRepository(SqlBaseContext context)
        {
            _context = context;
        }

        public void SaveTask(Task task)
        {
            //_context.GetSqlConnection().Execute()
        }
    }
}
