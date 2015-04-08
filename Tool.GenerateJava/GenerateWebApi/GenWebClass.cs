using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateWebApi
{
    internal class GenWebClass
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