using LogClient.Domain.Repositories;
using LogClient.Infrastuncture.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.Infrastuncture
{
    public class LogClientRepository<TEntity> : EfCoreRepository<TEntity>, ILogClientRepository<TEntity> where TEntity : class
    {
        private readonly LogClientDBContext _dbContext;
        public LogClientRepository( LogClientDBContext dbContext ) : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
