using System;
using System.Collections.Generic;
using System.Text;

namespace ef_demo
{
    public class ModelB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelAId { get; set; }
        public ModelA ModelA { get; set; }
    }
}
