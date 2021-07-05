using System;
using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class EnumerableLocalClassPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public EnumerableLocalClassPGen(GenProperty prop)
        {
            if (prop.CanWrite)
            {
                throw new ArgumentException("IEnumerable interface is readonly. CanWrite must be false.", "prop");
            }
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.IJsArray";
            yield return "tickbox.web.shared.util.JsArrayWrapper";

            var myNamespace = sourceNamespace + string.Join("", myNamespaceList.Select(n => "." + n));

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


                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace(
                                (_prop.PropType.GenericTypeArguments[0].Namespace ?? ""),
                                sourceNamespace).Select(n => "." + n.ToLowerInvariant())),
                        "I" + _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenNativeGetMethod(_prop,
                    string.Format("JsArray<{0}>", _prop.PropType.GenericTypeArguments[0].Name), false,
                    string.Format("get{0}Raw", _prop.Name));

            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\t@Override public final IJsArray<I{1}> get{0}() {{  return new JsArrayWrapper<{1}, I{1}>(get{0}Raw());  }}",
                        _prop.Name, _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            return new List<string>();
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            yield return
                string.Format("for({1} o : new JsIterable<{1}>(get{0}Raw())) {{ o.convertDates(); }}", _prop.Name,
                    _prop.PropType.GenericTypeArguments[0].Name);
        }

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.IJsArray";

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
                        "I" + _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenInterfaceGetMethod(_prop,
                    string.Format("IJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name));
//            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "int", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.stubs.StubJsArray";

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
                        "I" + _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenStubPrivateMember(_prop,
                    string.Format("StubJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name),
                    string.Format("new StubJsArray<I{0}>()", _prop.PropType.GenericTypeArguments[0].Name));
            yield return
                DtGenUtil.GenStubGetMethod(_prop,
                    string.Format("StubJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name));
            yield return
                DtGenUtil.GenStubSetMethod(_prop,
                    string.Format("StubJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.listProperty";
            yield return "org.tessell.model.properties.ListProperty";
            yield return "tickbox.web.shared.util.JavaOnlyUtils";
            yield return "tickbox.web.shared.util.Func";

//            yield return "org.tessell.model.validation.rules.Required";
            yield return
                string.Format("{0}.{1}",
                    dtoPackage +
                    string.Join("",
                        DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""),
                            sourceNamespace).Select(n => "." + n.ToLowerInvariant())),
                    "I" + _prop.PropType.GenericTypeArguments[0].Name);
            yield return
                string.Format("{0}.{1}",
                    destTModelPackage +
                    string.Join("",
                        DtGenUtil.CalculateRelativeNamespace((_prop.PropType.GenericTypeArguments[0].Namespace ?? ""),
                            sourceNamespace).Select(n => "." + n.ToLowerInvariant())),
                    _prop.PropType.GenericTypeArguments[0].Name + "Tm");
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\tpublic final ListProperty<{1}Tm> {0} = listProperty(\"{0}\");",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.PropType.GenericTypeArguments[0].Name);
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
                string.Format(
                    "\t\tto.{0}.set(JavaOnlyUtils.toList(JavaOnlyUtils.select(from.get{1}(), new Func<I{2}, {2}Tm>() {{ @Override public {2}Tm call(I{2} dto) {{ return {2}Tm.fromDto(dto); }}}})));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name, _prop.PropType.GenericTypeArguments[0].Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return null;
            //yield return string.Format("\t\tresult.set{1}({0}.get());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}