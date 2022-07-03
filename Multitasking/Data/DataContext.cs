//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Multitasking.Models;

namespace Multitasking.Data
{
    //internal class DataContext: DbContext
    //{
    //    public DbSet<Todo> Tasks { get; set; }

    //    public string DbPath { get; set; }

    //    public DataContext()
    //    {
    //        var folder = Environment.SpecialFolder.LocalApplicationData;
    //        var path = Environment.GetFolderPath(folder);
    //        DbPath = System.IO.Path.Join(path, "storage.db");
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        base.OnConfiguring(optionsBuilder);

    //        optionsBuilder.UseSqlite($"DataSource={DbPath}");
    //    }
    //}
}
