using System;
using System.Collections.Generic;
using System.Text;

namespace ef_demo
{
    public class ModelA
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModelB> ModelBs { get; } = new List<ModelB>();
    }
}
