using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.Infrastuncture.Core
{
    public class EfCoreDbContext:DbContext
    {
        public EfCoreDbContext()
        { }

        public EfCoreDbContext( DbContextOptions options )
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
