using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.MySQL
{
    public class TestableDataContext : DataContext
    {
        public TestableDataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }


}
