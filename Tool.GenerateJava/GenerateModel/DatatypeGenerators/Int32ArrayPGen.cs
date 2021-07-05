using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class Int32ArrayPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public Int32ArrayPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList,
            string destPackage)
        {
            yield return "com.google.gwt.core.client.JsArrayInteger";
            yield return "tickbox.web.shared.util.IJsArrayInteger";
            yield return "tickbox.web.shared.util.JsArrayIntegerWrapper";
            yield return "tickbox.web.shared.util.Utils";
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenNativeGetMethod(_prop, "JsArrayInteger", false, string.Format("get{0}Raw", _prop.Name));
            yield return DtGenUtil.GenNativeSetMethod(_prop, "JsArrayInteger", false, genClass);


            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\t@Override public final IJsArrayInteger get{0}() {{  return new JsArrayIntegerWrapper(get{0}Raw());  }}",
                        _prop.Name);
            }

            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\t@Override public final {1} set{0}(Iterable<Integer> list) {{ get{0}Raw().setLength(0); for(int i : list) {{ get{0}Raw().push(i); }} return this;  }}",
                        _prop.Name, genClass.Name);

                yield return
                    string.Format(
                        "\t@Override public final {1} set{0}(IJsArrayInteger list) {{ set{0}(JsArrayIntegerWrapper.unwrap(list)); return this; }}",
                        _prop.Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(_prop, "Utils.createIntArray()");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.IJsArrayInteger";
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "IJsArrayInteger");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "Iterable<Integer>", genClass);
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "IJsArrayInteger", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.stubs.StubJsArrayInteger";
            if (_prop.CanWrite)
            {
                yield return "tickbox.web.shared.util.IJsArrayInteger";
            }
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "StubJsArrayInteger", "new StubJsArrayInteger()");
            yield return DtGenUtil.GenStubGetMethod(_prop, "StubJsArrayInteger");


            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\t@Override public I{1} set{0}(IJsArrayInteger val) {{ this._{0} = (StubJsArrayInteger)val; return this; }}",
                        _prop.Name, genClass.Name);
                yield return
                    string.Format(
                        "\t@Override public I{1} set{0}(Iterable<Integer> list) {{ _{0}.setLength(0); for(int i : list) {{ _{0}.push(i); }} return this;  }}",
                        _prop.Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.listProperty";
            yield return "org.tessell.model.properties.ListProperty";
            yield return "tickbox.web.shared.util.JavaOnlyUtils";
            //            yield return "org.tessell.model.validation.rules.Required";
            //yield return string.Format("{0}.{1}", dtoPackage + string.Join("", DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace).Select(n => "." + n.ToLowerInvariant())), _prop.PropType.GenericTypeArguments[0].Name);
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\tpublic final ListProperty<Integer> {0} = listProperty(\"{0}\");",
                    DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return null;
            //yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return
                string.Format("\t\tto.{0}.set(JavaOnlyUtils.toList(from.get{1}()));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\t\tresult.set{1}({0}.get());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}