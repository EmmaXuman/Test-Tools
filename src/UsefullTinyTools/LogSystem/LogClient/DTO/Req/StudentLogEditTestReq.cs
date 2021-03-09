using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.DTO.Req
{
    public class StudentLogEditTestReq
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 学员Id
        /// </summary>
        public int UserInfoId { get; set; }
        /// <summary>
        /// 操作人类型
        /// </summary>
        public byte OperatorType { get; set; }
        /// <summary>
        /// 操作人id
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 操作类型枚举
        /// </summary>
        public int OperationType { get; set; }
        /// <summary>
        /// 操作枚举名称
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }

    }
}
