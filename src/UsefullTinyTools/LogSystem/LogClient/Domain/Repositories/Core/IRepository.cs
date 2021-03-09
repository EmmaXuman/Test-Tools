using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogClient.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync( Expression<Func<T, bool>> selector );
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<T> AddAsync( T item );
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListByPageAsync( Expression<Func<T, bool>> selector, int pageIndex, int pageSize, Expression<Func<T, object>> orderBy, bool isDesc );
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        Task<T> GetAsync( Expression<Func<T, bool>> selector );
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync( T model );


    }
}
