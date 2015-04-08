using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    class DateTimePGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public DateTimePGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList, string destPackage)
        {
            yield return "tickbox.web.shared.util.Utils";
            yield return "java.util.Date";
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "String", false, "get" + _prop.Name + "Str");
            yield return DtGenUtil.GenNativeSetMethod(_prop, "String", false, "set" + _prop.Name + "Str", genClass);

            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\tpublic final Date get{0}() {{  return Utils.parseLosslessDateTime(get{0}Str()).getDate();  }}",
                        _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\tpublic final {1} set{0}(Date d) {{ set{0}Str(Utils.formatLosslessDateTime(d)); return this; }}",
                        _prop.Name, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(_prop, "new Date()");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            yield return string.Format("set{0}Str(Utils.formatLosslessDateTime(Utils.parseDtoDateTime(get{0}Str())));", _prop.Name);
        }
        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "java.util.Date";
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenInterfaceGetMethod(_prop, "Date");
            yield return DtGenUtil.GenInterfaceSetMethod(_prop, "Date", genClass);
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "java.util.Date";
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenStubPrivateMember(_prop, "Date", "new Date()");
            yield return DtGenUtil.GenStubGetMethod(_prop, "Date");
            yield return DtGenUtil.GenStubSetMethod(_prop, "Date", genClass);
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage)
        {
            yield return "tickbox.web.shared.util.DateTime";
            yield return "latitude.gwt.tessellshared.client.tessell.DateTimeProperty";
            yield return "org.tessell.model.values.SetValue";
            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\tpublic final DateTimeProperty {0} = new DateTimeProperty(new SetValue<DateTime>(\"{0}\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return string.Format("\t\t{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return string.Format("\t\tto.{0}.set(new DateTime(from.get{1}()));", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            yield return string.Format("\t\tresult.set{1}(DateTime.toDate({0}.get()));", DtGenUtil.ToJavaMemberName(_prop.Name), _prop.Name);
        }
    }
}
