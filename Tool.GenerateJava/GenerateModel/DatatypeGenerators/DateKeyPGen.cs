using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    class DateKeyPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public DateKeyPGen(GenProperty prop)
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
            yield return DtGenUtil.GenNativeGetMethod(_prop, "int", false);
            yield return DtGenUtil.GenNativeSetMethod(_prop, "int", false, genClass);

            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";

            if (_prop.CanRead)
            {
                yield return
                    string.Format("\tpublic final Date get{0}() {{  return Utils.fromDateKey(get{1}());  }}",
                        nameWoKey, _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return
                    string.Format("\tpublic final {2} set{0}(Date d) {{ set{1}(Utils.toDateKey(d)); return this; }}",
                        nameWoKey, _prop.Name, genClass.Name);
            }

            if (_prop.DateTimeSisterProperty != null)
            {
                yield return DtGenUtil.GenNativeDeleteMethod(_prop.DateTimeSisterProperty);
            }

        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(_prop, "19700101");
        }

        public IEnumerable<string> GenerateConvertDates()
        {
            if (_prop.DateTimeSisterProperty != null && _prop.DateTimeSisterProperty.CanWrite)
            {
                yield return string.Format("delete{0}();", _prop.DateTimeSisterProperty.Name);
            }
        }
        public IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "java.util.Date";
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";

            if (_prop.CanRead)
            {
                yield return string.Format("\tDate get{0}();", nameWoKey);
            }
            if (_prop.CanWrite)
            {
                yield return string.Format("\tI{1} set{0}(Date d);", nameWoKey, genClass.Name);
            }
        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "java.util.Date";
            yield return "tickbox.web.shared.util.Utils";
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";


            yield return DtGenUtil.GenStubPrivateMember(_prop, "Date", "Utils.fromDateKey(19700101)");
            if (_prop.CanRead)
            {
                yield return string.Format("\t@Override public Date get{0}() {{ return _{1}; }}", nameWoKey, _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return string.Format("\t@Override public I{1} set{0}(Date d) {{ _{2} = d; return this; }}", nameWoKey, genClass.Name, _prop.Name);
            }
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage)
        {
            yield return "tickbox.web.shared.util.DateOnly";
            yield return "tickbox.web.shared.util.DateOnlyProperty";
            yield return "org.tessell.model.values.SetValue";
            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {

            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";
            yield return string.Format("\tpublic final DateOnlyProperty {0} = new DateOnlyProperty(new SetValue<DateOnly>(\"{0}\"));", DtGenUtil.ToJavaMemberName(nameWoKey));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";
            yield return string.Format("\t\t{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(nameWoKey));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";
            yield return string.Format("\t\tto.{0}.set(new DateOnly(from.get{1}()));", DtGenUtil.ToJavaMemberName(nameWoKey), nameWoKey);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";
            yield return string.Format("\t\tresult.set{1}(DateOnly.toDate({0}.get()));", DtGenUtil.ToJavaMemberName(nameWoKey), nameWoKey);
        }
    }
}
