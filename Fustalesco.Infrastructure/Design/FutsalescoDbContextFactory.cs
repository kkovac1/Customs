using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fustalesco.Infrastructure.Design
{
    public class FutsalescoDbContextFactory : IDesignTimeDbContextFactory<FutsalescoDbContext>
    {

        public FutsalescoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FutsalescoDbContext>();

            //var connectionString = "Data Source=(local)\\;Initial Catalog;Integrated Security=True";
            var connectionString = "Server=(local);Database=Fustalesco;Integrated Security=True";
            optionsBuilder.UseSqlServer(connectionString, options => {});

            return new FutsalescoDbContext(optionsBuilder.Options);
        }
    }
}
