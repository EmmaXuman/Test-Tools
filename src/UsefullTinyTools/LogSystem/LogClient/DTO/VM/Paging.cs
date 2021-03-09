using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.DTO.VM
{
    public class Paging<T>
    {
        /// <summary>
        /// 总行数.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 返回数据集
        /// </summary>
        public IEnumerable<T> DataList { get; set; }

    }
}
