using LogClient.Domain.Entity;
using LogClient.Domain.Repositories;
using LogClient.DTO.Data;
using LogClient.DTO.Req;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogClient.Infrastuncture
{
    public class StudentLogRepository : LogClientRepository<StudentTrackLog>, IStudentLogRepository
    {
        public StudentLogRepository( LogClientDBContext dbContext ) : base(dbContext)
        {
            //_dbContext = dbContext;
        }

        public Task<bool> Add( StudentLogEditDto req )
        {
            throw new System.NotImplementedException();
        }
    }
}
