using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    class NullBooleanPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public NullBooleanPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList, string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableBoolean";
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "boolean", false, string.Format("get{0}Raw", _prop.Name));
            yield return DtGenUtil.GenNativeSetMethod(_prop, "boolean", false, string.Format("set{0}Raw", _prop.Name), genClass);
            yield return DtGenUtil.GenNativeGetIsNullMethod(_prop);
            yield return DtGenUtil.GenNativeSetIsNullMethod(_prop);
            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\tpublic final NullableBoolean get{0}() {{ return get{0}IsNull() ? NullableBoolean.getNull() : new NullableBoolean(get{0}Raw());  }}",
                        _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\tpublic final {1} set{0}(NullableBoolean val) {{ if (val.isNull()) {{ set{0}IsNull(); }} else {{ set{0}Raw(val.getValue()); }} return this; }}",
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
            yield return "tickbox.web.shared.util.NullableBoolean";
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "NullableBoolean");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "NullableBoolean", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableBoolean";
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "NullableBoolean", "NullableBoolean.getNull()");
            yield return DtGenUtil.GenStubGetMethod(_prop, "NullableBoolean");
            yield return DtGenUtil.GenStubSetMethod(_prop, "NullableBoolean", genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.booleanProperty";
            yield return "org.tessell.model.properties.BooleanProperty";
            yield return "tickbox.web.shared.util.NullableBoolean";
//            yield return "org.tessell.model.validation.rules.Required";

        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\tpublic final BooleanProperty {0} = booleanProperty(\"{0}\", false);", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return null;
//            yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return string.Format("\t\tto.{0}.set(from.get{1}().getValueOrDefault(null));", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\t\tresult.set{1}({0}.get() == null ? NullableBoolean.getNull() : new NullableBoolean({0}.get()));", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}
