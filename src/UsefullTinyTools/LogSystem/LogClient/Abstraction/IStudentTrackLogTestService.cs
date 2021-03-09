using LogClient.Domain.Entity;
using LogClient.DTO.Req;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogClient.Abstraction
{
    public interface IStudentTrackLogTestService
    {
        Task<bool> Add( StudentLogEditTestReq req );

        Task<bool> Edit( StudentLogEditTestReq req );

        Task<IEnumerable<StudentTrackLog>> List( StudentLogListTestReq req );

        Task<bool> Delete();
    }
}
