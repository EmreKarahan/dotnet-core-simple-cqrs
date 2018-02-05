using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Simple.Cqrs.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskContext>
    {
        public TaskContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TaskContext>();
            var connectionString = configuration.GetConnectionString("TaskContext");
            builder.UseSqlServer(connectionString);
            return new TaskContext(builder.Options);
        }
    }
}
