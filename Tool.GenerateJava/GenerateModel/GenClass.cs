using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    internal class GenClass
    {
        public GenClass()
        {
            Properties = new List<GenProperty>();
        }

        public string Name { get; set; }
        public List<GenProperty> Properties { get; set; }
        public List<string> RelativeDotNetNamespace { get; set; }
    }
}