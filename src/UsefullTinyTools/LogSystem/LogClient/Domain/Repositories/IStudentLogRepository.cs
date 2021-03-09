using LogClient.Domain.Entity;
using LogClient.DTO.Data;
using LogClient.DTO.Req;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogClient.Domain.Repositories
{
    public interface IStudentLogRepository : ILogClientRepository<StudentTrackLog>
    {
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<bool> Add( StudentLogEditDto req );
    }
}
