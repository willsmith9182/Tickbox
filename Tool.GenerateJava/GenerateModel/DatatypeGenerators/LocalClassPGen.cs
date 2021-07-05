using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class LocalClassPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public LocalClassPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList,
            string destPackage)
        {
            var myNamespace = sourceNamespace + string.Join("", myNamespaceList.Select(n => "." + n));

            if ((_prop.PropType.Namespace ?? "") != myNamespace)
            {
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace((_prop.PropType.Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        _prop.PropType.Name);
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace((_prop.PropType.Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        "I" + _prop.PropType.Name);
            }
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, _prop.PropType.Name);
            yield return
                DtGenUtil.GenNativeSetMethod(_prop, _prop.PropType.Name, false, string.Format("set{0}Raw", _prop.Name),
                    genClass);

            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\t@Override public final {2} set{0}(I{1} val) {{ set{0}Raw(({1})val); return this; }}",
                        _prop.Name, _prop.PropType.Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(_prop, "null");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            yield return string.Format("if (get{0}() != null) {{ get{0}().convertDates(); }}", _prop.Name);
        }

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            var myNamespace = sourceNamespace + string.Join("", relativeNamespace.Select(n => "." + n));

            if ((_prop.PropType.Namespace ?? "") != myNamespace)
            {
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace((_prop.PropType.Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        "I" + _prop.PropType.Name);
            }
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "I" + _prop.PropType.Name);
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "I" + _prop.PropType.Name, genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            var myNamespace = sourceNamespace + string.Join("", relativeNamespace.Select(n => "." + n));

            if ((_prop.PropType.Namespace ?? "") != myNamespace)
            {
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace((_prop.PropType.Namespace ?? ""),
                                sourceNamespace).Select(n => "." + n.ToLowerInvariant())),
                        "Stub" + _prop.PropType.Name);
                yield return
                    string.Format("{0}.{1}",
                        destPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace((_prop.PropType.Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())),
                        "I" + _prop.PropType.Name);
            }
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "Stub" + _prop.PropType.Name, "null");
            yield return DtGenUtil.GenStubGetMethod(_prop, "Stub" + _prop.PropType.Name);


            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\t@Override public I{1} set{0}(I{2} val) {{ this._{0} = (Stub{2}) val; return this; }}",
                        _prop.Name, genClass.Name, _prop.PropType.Name);
            }
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            var myNamespace = sourceNamespace + string.Join("", relativeNamespace.Select(n => "." + n));

            if ((_prop.PropType.Namespace ?? "") != myNamespace)
            {
                yield return
                    string.Format("{0}.{1}Tm",
                        destTModelPackage +
                        string.Join("",
                            DtGenUtil.CalculateRelativeNamespace((_prop.PropType.Namespace ?? ""), sourceNamespace)
                                .Select(n => "." + n.ToLowerInvariant())), _prop.PropType.Name);
            }
//            yield return "static org.tessell.model.properties.NewProperty.enumProperty";
//            yield return "org.tessell.model.properties.EnumProperty";
//            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\tpublic final {1}Tm {0};", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.PropType.Name);
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return string.Format("\t\tthis.{0} = {0};", DtGenUtil.ToJavaMemberName(_prop.Name));
            constructorParams.Add(string.Format("{0}Tm {1}", _prop.PropType.Name, DtGenUtil.ToJavaMemberName(_prop.Name)));
//            yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            constructorParams.Add(string.Format("{1}Tm.fromDto(dto.get{0}())", _prop.Name, _prop.PropType.Name));

            yield return
                string.Format("\t\tto.{0}.setFrom(from.get{1}());", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\t\tif ({0} != null) {{ result.set{1}({0}.toDto()); }}",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}