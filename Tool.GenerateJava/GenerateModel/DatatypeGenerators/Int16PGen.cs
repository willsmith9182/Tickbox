using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    class Int16PGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public Int16PGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList, string destPackage)
        {
            return new List<string>();
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "short");
            yield return DtGenUtil.GenNativeSetMethod(_prop, "short", genClass);
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(_prop, "(short)0");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "short");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "short", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {

            return new List<string>();
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {

            yield return DtGenUtil.GenStubPrivateMember(_prop, "short", "(short)0");
            yield return DtGenUtil.GenStubGetMethod(_prop, "short");
            yield return DtGenUtil.GenStubSetMethod(_prop, "short", genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.integerProperty";
            yield return "org.tessell.model.properties.IntegerProperty";
            yield return "org.tessell.model.validation.rules.Range";
            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\tpublic final IntegerProperty {0} = integerProperty(\"{0}\");", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return string.Format("\t\t{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
            yield return string.Format("\t\t{0}.addRule(new Range(\"The number must be between -32,768 and 32,767\", -32768, 32767));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return string.Format("\t\tto.{0}.set((int)from.get{1}());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\t\tresult.set{1}((short){0}.get().intValue());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}
