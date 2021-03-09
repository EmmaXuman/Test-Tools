using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.Domain.Repositories
{
    public interface ILogClientRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
