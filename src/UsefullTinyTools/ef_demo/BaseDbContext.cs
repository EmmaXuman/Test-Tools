using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ef_demo
{
    public class BaseDbContext:DbContext
    {
        public DbSet<ModelA> ModelAs { get; set; }
        public DbSet<ModelB> ModelBs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }
}
