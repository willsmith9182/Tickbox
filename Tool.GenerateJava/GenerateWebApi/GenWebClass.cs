using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateWebApi
{
    class GenWebClass
    {
        public GenWebClass()
        {
            Methods = new List<GenWebMethod>();
        }

        public string Name { get; set; }
        public List<GenWebMethod> Methods { get; set; }
        public List<string> RelativeNamespace { get; set; }
    }
}
