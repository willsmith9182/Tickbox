using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    class EnumArrayPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public EnumArrayPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList, string destPackage)
        {
            yield return "com.google.gwt.core.client.JsArrayInteger";
            yield return "java.util.ArrayList";
            yield return "tickbox.web.shared.util.JsArrayIntegerIterable";
            yield return "tickbox.web.shared.util.Utils";

            var myNamespace = sourceNamespace + string.Join("", myNamespaceList.Select(n => "." + n));

            if ((_prop.PropType.GenericTypeArguments[0].Namespace ?? "") != myNamespace)
            {
                yield return string.Format("{0}.{1}", destPackage + string.Join("", DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace).Select(n => "." + n.ToLowerInvariant())), _prop.PropType.GenericTypeArguments[0].Name);
            }


            if (_prop.CanWrite)
            {
                yield return "tickbox.web.shared.util.JsArrayIntegerWrapper";
                yield return "tickbox.web.shared.util.JavaOnlyUtils";
                yield return "tickbox.web.shared.util.Func";
                yield return "java.util.List";
            }
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "JsArrayInteger", false, string.Format("get{0}Raw", _prop.Name));
            yield return DtGenUtil.GenNativeSetMethod(_prop, "JsArrayInteger", false, string.Format("set{0}Raw", _prop.Name), genClass);

            if (_prop.CanRead)
            {
                yield return string.Format("\tpublic final List<{0}> get{1}() {{ " +
"\t\tArrayList<{0}> r = new ArrayList<{0}>(); " +
"\t\tfor(int i : new JsArrayIntegerIterable(get{1}Raw())) {{ " +
"\t\t\tr.add({0}.fromValue(i)); " +
"\t\t}} " +
"\t\treturn r; " +
"\t}}", _prop.PropType.GenericTypeArguments[0].Name, _prop.Name);
            }

            if (_prop.CanWrite)
            {
                yield return string.Format("\tpublic final {2} set{1}(Iterable<{0}> val) {{ set{1}Raw(JsArrayIntegerWrapper.from(JavaOnlyUtils.select(val, new Func<{0}, Integer>() {{ @Override public Integer call({0} val) {{ return val.getValue(); }}}})));	return this; }}", _prop.PropType.GenericTypeArguments[0].Name, _prop.Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(string.Format("set{0}Raw", _prop.Name), "Utils.createIntArray()");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            return new List<string>();
        }
        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            var myNamespace = sourceNamespace + string.Join("", relativeNamespace.Select(n => "." + n));

            if ((_prop.PropType.GenericTypeArguments[0].Namespace ?? "") != myNamespace)
            {
                yield return string.Format("{0}.{1}", destPackage + string.Join("", DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace).Select(n => "." + n.ToLowerInvariant())), _prop.PropType.GenericTypeArguments[0].Name);
            }


            if (_prop.CanRead)
            {
                yield return "java.util.List";
            }
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            if (_prop.CanRead)
            {
                yield return DtGenUtil.GenInterfaceGetMethod(_prop, string.Format("List<{0}>", _prop.PropType.GenericTypeArguments[0].Name));
            }
            if (_prop.CanWrite)
            {
                yield return DtGenUtil.GenInterfaceSetMethod(_prop, string.Format("Iterable<{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);
            }
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "java.util.ArrayList";
            var myNamespace = sourceNamespace + string.Join("", relativeNamespace.Select(n => "." + n));

            if ((_prop.PropType.GenericTypeArguments[0].Namespace ?? "") != myNamespace)
            {
                yield return string.Format("{0}.{1}", destPackage + string.Join("", DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace).Select(n => "." + n.ToLowerInvariant())), _prop.PropType.GenericTypeArguments[0].Name);
            }

            if (_prop.CanRead)
            {
                yield return "java.util.List";
            }

            if (_prop.CanRead)
            {
                yield return "tickbox.web.shared.util.JavaOnlyUtils";
            }
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, string.Format("List<{0}>", _prop.PropType.GenericTypeArguments[0].Name), string.Format("new ArrayList<{0}>()", _prop.PropType.GenericTypeArguments[0].Name));
            yield return DtGenUtil.GenStubGetMethod(_prop, string.Format("List<{0}>", _prop.PropType.GenericTypeArguments[0].Name));
            //yield return DtGenUtil.GenStubSetMethod(_prop, string.Format("ArrayList<{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);
            yield return string.Format("\t@Override public I{2} set{0}(Iterable<{1}> val) {{ this._{0} = JavaOnlyUtils.toList(val); return this; }}", _prop.Name, _prop.PropType.GenericTypeArguments[0].Name, genClass.Name);

        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.listProperty";
            yield return "org.tessell.model.properties.ListProperty";
//            yield return "org.tessell.model.validation.rules.Required";
            yield return string.Format("{0}.{1}", dtoPackage + string.Join("", DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace).Select(n => "." + n.ToLowerInvariant())), _prop.PropType.GenericTypeArguments[0].Name);

        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\tpublic final ListProperty<{1}> {0} = listProperty(\"{0}\");", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.PropType.GenericTypeArguments[0].Name);
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return null;
            //yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return string.Format("\t\tto.{0}.set(from.get{1}());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\t\tresult.set{1}({0}.get());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}
