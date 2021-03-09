using LogClient.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LogClient.Infrastuncture.Core
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entity;
        private readonly EfCoreDbContext _dbContext;
        private IDbConnection _connection;
        protected virtual DbSet<TEntity> Entity => _entity;
        public EfCoreRepository( EfCoreDbContext dbContext )
        {
            _dbContext = dbContext;
            _connection = _dbContext.Database.GetDbConnection();
            _entity = _dbContext.Set<TEntity>();
        }


        public virtual async Task<IEnumerable<TEntity>> GetListAsync( Expression<Func<TEntity, bool>> selector )
        {
            return await _entity.Where(selector).ToListAsync();
        }


        public virtual async Task<TEntity> AddAsync( TEntity item )
        {
            var result = await _entity.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetListByPageAsync( Expression<Func<TEntity, bool>> selector,int pageIndex, int pageSize, Expression<Func<TEntity, object>> orderBy, bool isDesc )
        {
            if (isDesc)
            {
                return await _entity.Where(selector).OrderByDescending(orderBy).Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).ToListAsync();
            }
            else
            {
                return await _entity.Where(selector).OrderBy(orderBy).Skip(pageSize * (pageIndex - 1)).Take(pageSize)
                    .ToListAsync();
            }
        }

        public virtual async Task<bool> UpdateAsync( TEntity model )
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<TEntity> GetAsync( Expression<Func<TEntity, bool>> selector )
        {
            return await _entity.FirstOrDefaultAsync(selector);
        }

    }
}
