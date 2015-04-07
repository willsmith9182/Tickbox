using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    class NullInt32PGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public NullInt32PGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList, string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableInteger";
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "int", false, string.Format("get{0}Raw", _prop.Name));
            yield return DtGenUtil.GenNativeSetMethod(_prop, "int", false, string.Format("set{0}Raw", _prop.Name), genClass);
            yield return DtGenUtil.GenNativeGetIsNullMethod(_prop);
            yield return DtGenUtil.GenNativeSetIsNullMethod(_prop);

            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\tpublic final NullableInteger get{0}() {{ return get{0}IsNull() ? NullableInteger.getNull() : new NullableInteger(get{0}Raw());  }}",
                        _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\tpublic final {1} set{0}(NullableInteger val) {{ if (val.isNull()) {{ set{0}IsNull(); }} else {{ set{0}Raw(val.getInt()); }} return this; }}",
                        _prop.Name, genClass.Name);
            }
          
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(string.Format("set{0}IsNull", _prop.Name), "");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableInteger";
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "NullableInteger");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "NullableInteger", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableInteger";
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "NullableInteger", "NullableInteger.getNull()");
            yield return DtGenUtil.GenStubGetMethod(_prop, "NullableInteger");
            yield return DtGenUtil.GenStubSetMethod(_prop, "NullableInteger", genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.integerProperty";
            yield return "org.tessell.model.properties.IntegerProperty";
            yield return "tickbox.web.shared.util.NullableInteger";
            //yield return "org.tessell.model.validation.rules.Range";
//            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\tpublic final IntegerProperty {0} = integerProperty(\"{0}\");", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return null;
//            yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
            //yield return string.Format("{0}.addRule(new Range(\"The number must be between 0 and 255\", 0, 255));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return string.Format("\t\tto.{0}.set(from.get{1}().getValueOrDefault(null));", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\t\tresult.set{1}({0}.get() == null ? NullableInteger.getNull() : new NullableInteger({0}.get()));", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}
