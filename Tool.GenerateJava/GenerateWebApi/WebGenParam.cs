using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace Tool.GenerateJava.GenerateWebApi
{
    class WebGenParam
    {
        public string Name { get; set; }
        public List<string> RelativeNamespace { get; set; }
        public TypeReference DataType { get; set; }
    }
}
