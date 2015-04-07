using System;
using Tool.GenerateJava.GenerateModel.DatatypeGenerators;

namespace Tool.GenerateJava.GenerateModel
{
    class GenProperty
    {
        public string Name { get; set; }
        public Type PropType { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public GenProperty DateTimeSisterProperty { get; set; }
        public IDatatypeGenerator GetGenerator(string sourceNamespace)
        {
            return DatatypeGeneratorFactory.Get(this, sourceNamespace);
        }
    }
}
