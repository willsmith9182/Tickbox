using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    class GenEnum
    {
        public GenEnum()
        {
            Values = new List<GenEnumItem>();
        }

        public string Name { get; set; }
        public List<GenEnumItem> Values { get; set; }
        public List<string> RelativeNamespace { get; set; }
    }
}
