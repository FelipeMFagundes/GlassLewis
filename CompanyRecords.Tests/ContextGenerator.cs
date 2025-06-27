using CompanyRecords.API.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRecords.Tests
{
    public static class ContextGenerator
    {
        public static AppDbContext Generate()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CompanyRecordsTestDb");
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // Optional: Set query tracking behavior if needed
            options.EnableSensitiveDataLogging();
            var context = new AppDbContext(options.Options);
            context.Database.EnsureCreated(); // Ensure the database is created
            return context;
        }



    }
}
