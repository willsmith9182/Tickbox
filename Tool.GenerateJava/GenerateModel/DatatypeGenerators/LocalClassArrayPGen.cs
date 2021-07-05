using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class LocalClassArrayPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public LocalClassArrayPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.Utils";
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
                                (_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())), _prop.PropType.GenericTypeArguments[0].Name);
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace(
                                (_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        "I" + _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenNativeGetMethod(_prop,
                    string.Format("JsArray<{0}>", _prop.PropType.GenericTypeArguments[0].Name), false,
                    string.Format("get{0}Raw", _prop.Name));
            yield return
                DtGenUtil.GenNativeSetMethod(_prop,
                    string.Format("JsArray<{0}>", _prop.PropType.GenericTypeArguments[0].Name), false,
                    string.Format("set{0}", _prop.Name), genClass);


            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\t@Override public final IJsArray<I{1}> get{0}() {{  return new JsArrayWrapper<{1}, I{1}>(get{0}Raw());  }}",
                        _prop.Name, _prop.PropType.GenericTypeArguments[0].Name);
            }
            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\t@Override public final {2} set{0}(Iterable<I{1}> list) {{ get{0}Raw().setLength(0); for(I{1} item : list) {{ get{0}Raw().push(({1})item); }} return this; }}",
                        _prop.Name, _prop.PropType.GenericTypeArguments[0].Name, genClass.Name);

                yield return
                    string.Format(
                        "\t@Override public final {2} set{0}(IJsArray<I{1}> list) {{ set{0}(JsArrayWrapper.<{1}, I{1}>unwrap(list)); return this; }}",
                        _prop.Name, _prop.PropType.GenericTypeArguments[0].Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return
                DtGenUtil.GenSetCall(_prop,
                    string.Format("Utils.<{0}>createArray()", _prop.PropType.GenericTypeArguments[0].Name));
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
                                (_prop.PropType.GenericTypeArguments[0].Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        "I" + _prop.PropType.GenericTypeArguments[0].Name);
            }
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenInterfaceGetMethod(_prop,
                    string.Format("IJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name));
            yield return
                DtGenUtil.GenInterfaceSetMethod(_prop,
                    string.Format("Iterable<I{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);
            yield return
                DtGenUtil.GenInterfaceSetMethod(_prop,
                    string.Format("IJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.stubs.StubJsArray";
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

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return
                DtGenUtil.GenStubPrivateMember(_prop,
                    string.Format("StubJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name),
                    string.Format("new StubJsArray<I{0}>()", _prop.PropType.GenericTypeArguments[0].Name));
            yield return
                DtGenUtil.GenStubGetMethod(_prop,
                    string.Format("StubJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name));
            //yield return DtGenUtil.GenStubSetMethod(_prop, string.Format("StubJsArray<I{0}>", _prop.PropType.GenericTypeArguments[0].Name), genClass);


            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\t@Override public I{1} set{0}(IJsArray<I{2}> val) {{ this._{0} = (StubJsArray<I{2}>)val; return this; }}",
                        _prop.Name, genClass.Name, _prop.PropType.GenericTypeArguments[0].Name);


                yield return
                    string.Format(
                        "\t@Override public I{1} set{0}(Iterable<I{2}> list) {{ _{0}.setLength(0); for(I{2} i : list) {{ _{0}.push(i); }} return this;  }}",
                        _prop.Name, genClass.Name, _prop.PropType.GenericTypeArguments[0].Name);
            }
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
            //		to.roles.set(JavaOnlyUtils.toList(JavaOnlyUtils.select(from.getRoles(), new Func<IApplicationWithRoles, ApplicationWithRolesTm>() { @Override public ApplicationWithRolesTm call(IApplicationWithRoles dto) { return ApplicationWithRolesTm.fromDto(dto); }})));

            yield return
                string.Format(
                    "\t\tto.{0}.set(JavaOnlyUtils.toList(JavaOnlyUtils.select(from.get{1}(), new Func<I{2}, {2}Tm>() {{ @Override public {2}Tm call(I{2} dto) {{ return {2}Tm.fromDto(dto); }}}})));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name, _prop.PropType.GenericTypeArguments[0].Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            //result.setRoles(JavaOnlyUtils.select(roles.get(), new Func<ApplicationWithRolesTm, IApplicationWithRoles>(){ @Override public IApplicationWithRoles call(ApplicationWithRolesTm val) { return val.toDto(); }}));
            yield return
                string.Format(
                    "\t\tresult.set{1}(JavaOnlyUtils.select({0}.get(), new Func<{2}Tm, I{2}>(){{ @Override public I{2} call({2}Tm val) {{ return val.toDto(); }}}}));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name, _prop.PropType.GenericTypeArguments[0].Name);
        }
    }
}