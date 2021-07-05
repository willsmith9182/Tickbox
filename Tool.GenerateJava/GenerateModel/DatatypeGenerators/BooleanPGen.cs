using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class BooleanPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public BooleanPGen(GenProperty prop)
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
            yield return DtGenUtil.GenNativeGetMethod(_prop, "boolean");
            yield return DtGenUtil.GenNativeSetMethod(_prop, "boolean", genClass);
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(_prop, "false");
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
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "boolean");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "boolean", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "boolean", "false");
            yield return DtGenUtil.GenStubGetMethod(_prop, "boolean");
            yield return DtGenUtil.GenStubSetMethod(_prop, "boolean", genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.booleanProperty";
            yield return "org.tessell.model.properties.BooleanProperty";
            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\tpublic final BooleanProperty {0} = booleanProperty(\"{0}\", false);",
                    DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return
                string.Format("\t\t{0}.addRule(new Required(\"required field\"));",
                    DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return
                string.Format("\t\tto.{0}.set(from.get{1}());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\t\tresult.set{1}({0}.get());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}