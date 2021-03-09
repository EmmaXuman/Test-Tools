using LogClient.Abstraction;
using LogClient.Domain.Entity;
using LogClient.DTO.Req;
using LogClient.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemLog.API.Controllers
{
    public class StudentTrackLogController : StudentControllerBase
    {
        private readonly IStudentTrackLogTestService _studentTrackService;
        public StudentTrackLogController( IStudentTrackLogTestService studentTrackService )
        {
            _studentTrackService = studentTrackService;
        }

        [HttpPost]
        public async Task<ActionResult<List<StudentTrackLog>>> List( StudentLogListTestReq req )
        {
            var list =await _studentTrackService.List(req);
            return list.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add( StudentLogEditTestReq req )
        {
            var res = await _studentTrackService.Add(req);
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Edit(StudentLogEditTestReq req)
        {
            var res = await _studentTrackService.Edit(req);
            return res;
        }

    }
}
