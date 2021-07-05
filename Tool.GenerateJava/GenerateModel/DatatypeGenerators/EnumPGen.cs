using System;
using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class EnumPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public EnumPGen(GenProperty prop)
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
            }
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "int", false, string.Format("get{0}Raw", _prop.Name));
            yield return
                DtGenUtil.GenNativeSetMethod(_prop, "int", false, string.Format("set{0}Raw", _prop.Name), genClass);

            if (_prop.CanRead)
            {
                yield return
                    string.Format("\tpublic final {1} get{0}() {{ return {1}.fromValue(get{0}Raw()); }}", _prop.Name,
                        _prop.PropType.Name);
            }

            if (_prop.CanWrite)
            {
                yield return
                    string.Format("\tpublic final {2} set{0}({1} val) {{ set{0}Raw(val.getValue()); return this; }}",
                        _prop.Name,
                        _prop.PropType.Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            var val = Convert.ChangeType(Enum.GetValues(_prop.PropType).GetValue(0),
                Enum.GetUnderlyingType(Enum.GetValues(_prop.PropType).GetValue(0).GetType()));
            yield return DtGenUtil.GenSetCall(string.Format("set{0}Raw", _prop.Name), string.Format("{0}", val));
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            return new List<string>();
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
                        _prop.PropType.Name);
            }
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, _prop.PropType.Name);
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, _prop.PropType.Name, genClass);
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
                        _prop.PropType.Name);
            }
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            var val = Convert.ChangeType(Enum.GetValues(_prop.PropType).GetValue(0),
                Enum.GetUnderlyingType(Enum.GetValues(_prop.PropType).GetValue(0).GetType()));

            yield return
                DtGenUtil.GenStubPrivateMember(_prop, _prop.PropType.Name,
                    string.Format("{0}.fromValue({1})", _prop.PropType.Name, val));
            yield return DtGenUtil.GenStubGetMethod(_prop, _prop.PropType.Name);
            yield return DtGenUtil.GenStubSetMethod(_prop, _prop.PropType.Name, genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return "static org.tessell.model.properties.NewProperty.enumProperty";
            yield return "org.tessell.model.properties.EnumProperty";
            yield return "org.tessell.model.validation.rules.Required";
            yield return
                string.Format("{0}.{1}",
                    dtoPackage +
                    string.Join("",
                        DtGenUtil.CalculateRelativeNamespace((_prop.PropType.Namespace ?? ""), sourceNamespace)
                            .Select(n => "." + n.ToLowerInvariant())), _prop.PropType.Name);
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format("\tpublic final EnumProperty<{1}> {0} = enumProperty(\"{0}\");",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.PropType.Name);
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass,
            List<string> constructorParams)
        {
            yield return
                string.Format("\t\t{0}.addRule(new Required(\"required field\"));",
                    DtGenUtil.ToJavaMemberName(_prop.Name));
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