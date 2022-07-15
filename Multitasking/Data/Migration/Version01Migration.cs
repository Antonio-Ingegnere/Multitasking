using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multitasking.Data.Scripts;

namespace Multitasking.Data.Migration
{
    internal class Version01Migration : VersionMigration
    {
        public Version01Migration() : base(1, SQLScripts.Version01)
        {
        }
    }
}
