using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    internal class NullDateTimePGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public NullDateTimePGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.Utils";
            yield return "tickbox.web.shared.util.NullableDate";
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "String", false, "get" + _prop.Name + "Str");
            yield return DtGenUtil.GenNativeSetMethod(_prop, "String", false, "set" + _prop.Name + "Str", genClass);

            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\tpublic final NullableDate get{0}() {{ return Utils.parseLosslessDateTime(get{0}Str());  }}",
                        _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\tpublic final {1} set{0}(NullableDate val) {{ set{0}Str(Utils.formatLosslessDateTime(val)); return this; }}",
                        _prop.Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall("set" + _prop.Name + "Str", "null");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            yield return
                string.Format("set{0}Str(Utils.formatLosslessDateTime(Utils.parseDtoDateTime(get{0}Str())));",
                    _prop.Name);
        }

        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableDate";
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "NullableDate");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "NullableDate", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace,
            string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableDate";
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "NullableDate", "new NullableDate()");
            yield return DtGenUtil.GenStubGetMethod(_prop, "NullableDate");
            yield return DtGenUtil.GenStubSetMethod(_prop, "NullableDate", genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace,
            string dtoPackage, string destTModelPackage)
        {
            yield return "tickbox.web.shared.util.DateTime";
            yield return "latitude.gwt.tessellshared.client.tessell.DateTimeProperty";
            yield return "org.tessell.model.values.SetValue";
            yield return "tickbox.web.shared.util.NullableDate";
            //            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\tpublic final DateTimeProperty {0} = new DateTimeProperty(new SetValue<DateTime>(\"{0}\"));",
                    DtGenUtil.ToJavaMemberName(_prop.Name));
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
                string.Format("\t\tto.{0}.set(from.get{1}().isNull() ? null : new DateTime(from.get{1}().getDate()));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return
                string.Format(
                    "\t\tresult.set{1}({0}.get() == null ? null : new NullableDate(DateTime.toDate({0}.get())));",
                    DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}