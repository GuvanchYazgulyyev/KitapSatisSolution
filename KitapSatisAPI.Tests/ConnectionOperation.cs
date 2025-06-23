using KitapSatisAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatisAPI.Tests
{
    public static class ConnectionOperation
    {
        public static KitapDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<KitapDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            var context = new KitapDbContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

    }
}
