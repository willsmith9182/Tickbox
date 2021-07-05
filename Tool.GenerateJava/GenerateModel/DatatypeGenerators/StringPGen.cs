using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class StringPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public StringPGen(GenProperty prop)
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
            yield return DtGenUtil.GenNativeGetMethod(_prop, "String");
            yield return DtGenUtil.GenNativeSetMethod(_prop, "String", genClass);
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(_prop, "null");
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
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "String");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "String", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "String", "\"\"");
            yield return DtGenUtil.GenStubGetMethod(_prop, "String");
            yield return DtGenUtil.GenStubSetMethod(_prop, "String", genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.stringProperty";
            yield return "org.tessell.model.properties.StringProperty";
            //yield return "org.tessell.model.validation.rules.Range";
            //            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\tpublic final StringProperty {0} = stringProperty(\"{0}\");",
                    DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return null;
            //            yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
            //yield return string.Format("{0}.addRule(new Range(\"The number must be between 0 and 255\", 0, 255));", DtGenUtil.ToJavaMemberName(_prop.Name));
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