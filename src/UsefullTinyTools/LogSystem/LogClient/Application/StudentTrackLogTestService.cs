using LogClient.Abstraction;
using LogClient.Domain.Entity;
using LogClient.Domain.Repositories;
using LogClient.DTO.Req;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogClient.Application
{
    public class StudentTrackLogTestService : IStudentTrackLogTestService
    {
        private readonly IStudentLogRepository _logClientRepository;

        public StudentTrackLogTestService(IStudentLogRepository logClientRepository)
        {
            _logClientRepository = logClientRepository;
        }
        public async Task<bool> Add( StudentLogEditTestReq req )
        {
            var obj = new StudentTrackLog()
            {
                Id = req.Id,
                Summary = req.Summary,
                OperationName = req.OperationName,
                OperationTime = DateTime.Now,
                OperationType = req.OperationType,
                OperatorId = req.OperatorId,
                OperatorType = req.OperatorType,
                UserInfoId = 1373054
            };
            try
            {
                var result = await _logClientRepository.AddAsync(obj);

                return result != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Edit( StudentLogEditTestReq req )
        {
            var curObj = await _logClientRepository.GetAsync(x => x.Id == req.Id);
            if (curObj == null)
            {
                return false;
            }
            curObj.Summary = req.Summary;
            curObj.OperationName = req.OperationName;
            curObj.OperationTime = DateTime.Now;
            curObj.OperationType = req.OperationType;
            curObj.OperatorId = req.OperatorId;
            curObj.OperatorType = req.OperatorType;
            curObj.UserInfoId = 1373054;

            try
            {
                var result = await _logClientRepository.UpdateAsync(curObj);

                return result ;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IEnumerable<StudentTrackLog>> List(StudentLogListTestReq req)
        {
            var result = await _logClientRepository.GetListAsync(x => 1 == 1);
            return result;
        }
    }
}
