using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class NullEnumPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public NullEnumPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableEnum";
            var myNamespace = sourceNamespace + string.Join("", myNamespaceList.Select(n => "." + n));

            if ((_prop.PropType.GenericTypeArguments[0].Namespace ?? "") != myNamespace)
            {
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace(
                                (_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "int", false, string.Format("get{0}Raw", _prop.Name));
            yield return
                DtGenUtil.GenNativeSetMethod(_prop, "int", false, string.Format("set{0}Raw", _prop.Name), genClass);
            yield return DtGenUtil.GenNativeGetIsNullMethod(_prop);
            yield return DtGenUtil.GenNativeSetIsNullMethod(_prop);

            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\tpublic final NullableEnum<{1}> get{0}() {{ return get{0}IsNull() ? new NullableEnum<{1}>() : new NullableEnum<{1}>({1}.fromValue(get{0}Raw()));  }}",
                        _prop.Name, _prop.PropType.GenericTypeArguments[0].Name);
            }

            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\tpublic final {2} set{0}(NullableEnum<{1}> val) {{ if (val.isNull()) {{ set{0}IsNull(); }} else {{ set{0}Raw(val.getValue().getValue()); }} return this; }}",
                        _prop.Name, _prop.PropType.GenericTypeArguments[0].Name, genClass.Name);
                yield return
                    string.Format("\tpublic final {2} set{0}({1} val) {{ set{0}Raw(val.getValue()); return this; }}",
                        _prop.Name, _prop.PropType.GenericTypeArguments[0].Name, genClass.Name);
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

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableEnum";
            var myNamespace = sourceNamespace + string.Join("", relativeNamespace.Select(n => "." + n));

            if ((_prop.PropType.GenericTypeArguments[0].Namespace ?? "") != myNamespace)
            {
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace(
                                (_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenInterfaceGetMethod(_prop,
                    string.Format("NullableEnum<{0}>", _prop.PropType.GenericTypeArguments[0].Name));
            yield return
                DtGenUtil.GenInterfaceSetMethod(_prop,
                    string.Format("NullableEnum<{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableEnum";

            var myNamespace = sourceNamespace + string.Join("", relativeNamespace.Select(n => "." + n));


            if ((_prop.PropType.GenericTypeArguments[0].Namespace ?? "") != myNamespace)
            {
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace(
                                (_prop.PropType.GenericTypeArguments[0].Namespace ?? ""),
                                sourceNamespace).Select(n => "." + n.ToLowerInvariant())),
                        _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenStubPrivateMember(_prop,
                    string.Format("NullableEnum<{0}>", _prop.PropType.GenericTypeArguments[0].Name),
                    string.Format("new NullableEnum<{0}>()", _prop.PropType.GenericTypeArguments[0].Name));
            yield return
                DtGenUtil.GenStubGetMethod(_prop,
                    string.Format("NullableEnum<{0}>", _prop.PropType.GenericTypeArguments[0].Name));
            yield return
                DtGenUtil.GenStubSetMethod(_prop,
                    string.Format("NullableEnum<{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.enumProperty";
            yield return "org.tessell.model.properties.EnumProperty";
            yield return "tickbox.web.shared.util.NullableEnum";
//            yield return "org.tessell.model.validation.rules.Required";
            yield return
                string.Format("{0}.{1}",
                    dtoPackage +
                    string.Join("",
                        DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""),
                            sourceNamespace).Select(n => "." + n.ToLowerInvariant())),
                    _prop.PropType.GenericTypeArguments[0].Name);
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\tpublic final EnumProperty<{1}> {0} = enumProperty(\"{0}\");",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.PropType.GenericTypeArguments[0].Name);
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return null;
//            yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return
                string.Format("\t\tto.{0}.set(from.get{1}().getValueOrDefault(null));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\t\tresult.set{1}({0}.get() == null ? NullableEnum.<{2}>getNull() : new NullableEnum<{2}>({0}.get()));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name, _prop.PropType.GenericTypeArguments[0].Name);
        }
    }
}