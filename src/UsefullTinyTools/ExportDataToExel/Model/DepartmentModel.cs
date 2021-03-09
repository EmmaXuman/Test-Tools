using System;
using System.Collections.Generic;
using System.Text;

namespace ExportDataToExel.Model
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int ParentId { get; set; }

        public int UserNumber { get; set; }
    }
}
