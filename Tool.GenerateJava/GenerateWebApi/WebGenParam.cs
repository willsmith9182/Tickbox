using System.Collections.Generic;
using Mono.Cecil;

namespace Tool.GenerateJava.GenerateWebApi
{
    internal class WebGenParam
    {
        public string Name { get; set; }
        public List<string> RelativeNamespace { get; set; }
        public TypeReference DataType { get; set; }
    }
}