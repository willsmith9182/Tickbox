using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class LongPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public LongPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList,
            string destPackage)
        {
            return new List<string>();
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\t// long datatype shouldn't be used for data transfer since javascript doesn't support them. Property: {0}",
                    _prop.Name);
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return
                string.Format(
                    "\t// long datatype shouldn't be used for data transfer since javascript doesn't support them. Property: {0}",
                    _prop.Name);
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\t// long datatype shouldn't be used for data transfer since javascript doesn't support them. Property: {0}",
                    _prop.Name);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\t// long datatype shouldn't be used for data transfer since javascript doesn't support them. Property: {0}",
                    _prop.Name);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return null;
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\t// long datatype shouldn't be used for data transfer since javascript doesn't support them. Property: {0}",
                    _prop.Name);
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return null;
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return
                string.Format(
                    "\t// long datatype shouldn't be used for data transfer since javascript doesn't support them. Property: {0}",
                    _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\t// long datatype shouldn't be used for data transfer since javascript doesn't support them. Property: {0}",
                    _prop.Name);
        }
    }
}