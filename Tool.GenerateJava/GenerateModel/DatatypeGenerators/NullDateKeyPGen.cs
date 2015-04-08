using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    class NullDateKeyPGen : IDatatypeGenerator
    {
        private readonly GenProperty _prop;

        public NullDateKeyPGen(GenProperty prop)
        {
            _prop = prop;
        }

        public IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList, string destPackage)
        {
            yield return "tickbox.web.shared.util.Utils";
            yield return "tickbox.web.shared.util.NullableDate";
        }

        public IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            yield return DtGenUtil.GenNativeGetMethod(_prop, "int", false, string.Format("get{0}Raw", _prop.Name));
            yield return DtGenUtil.GenNativeSetMethod(_prop, "int", false, string.Format("set{0}Raw", _prop.Name), genClass);
            yield return DtGenUtil.GenNativeGetIsNullMethod(_prop);
            yield return DtGenUtil.GenNativeSetIsNullMethod(_prop);

            var nameWoKey = _prop.Name.Substring(0, _prop.Name.Length - 3);
            if (_prop.CanRead)
            {
                yield return
                    string.Format(
                        "\tpublic final NullableDate get{0}() {{  return get{1}IsNull() ? new NullableDate() : new NullableDate(Utils.fromDateKey(get{1}Raw()));  }}",
                        nameWoKey, _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return
                    string.Format(
                        "\tpublic final {2} set{0}(NullableDate val) {{ if (val.isNull()) {{ set{1}IsNull(); }} else {{ set{1}Raw(Utils.toDateKey(val.getDate())); }} return this; }}",
                        nameWoKey, _prop.Name, genClass.Name);
            }

            if (_prop.DateTimeSisterProperty != null)
            {
                yield return DtGenUtil.GenNativeDeleteMethod(_prop.DateTimeSisterProperty);
            }

        }

        public IEnumerable<string> GenerateInitCode(string sourceNamespace)
        {
            yield return DtGenUtil.GenSetCall(string.Format("set{0}IsNull", _prop.Name), "");
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
            yield return "tickbox.web.shared.util.NullableDate";
        }

        public IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass)
        {
            var nameWoKey = _prop.Name.Substring(0, _prop.Name.Length - 3);

            if (_prop.CanRead)
            {
                yield return string.Format("\tNullableDate get{0}();", nameWoKey);
            }
            if (_prop.CanWrite)
            {
                yield return string.Format("\tI{1} set{0}(NullableDate val);", nameWoKey, genClass.Name);
            }

        }

        public IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage)
        {
            yield return "tickbox.web.shared.util.NullableDate";
        }

        public IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";


            yield return DtGenUtil.GenStubPrivateMember(_prop, "NullableDate", "new NullableDate()");
            if (_prop.CanRead)
            {
                yield return string.Format("\t@Override public NullableDate get{0}() {{ return _{1}; }}", nameWoKey, _prop.Name);
            }
            if (_prop.CanWrite)
            {
                yield return string.Format("\t@Override public I{1} set{0}(NullableDate d) {{ _{2} = d; return this; }}", nameWoKey, genClass.Name, _prop.Name);
            }
        }

        public IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage)
        {
            yield return "tickbox.web.shared.util.DateOnly";
            yield return "latitude.gwt.tessellshared.client.tessell.DateOnlyProperty";
            yield return "org.tessell.model.values.SetValue";
            yield return "tickbox.web.shared.util.NullableDate";
//            yield return "org.tessell.model.validation.rules.Required";
        }

        public IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass)
        {

            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";

            yield return string.Format("\tpublic final DateOnlyProperty {0} = new DateOnlyProperty(new SetValue<DateOnly>(\"{0}\"));", DtGenUtil.ToJavaMemberName(nameWoKey));
        }

        public IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            yield return null;
//            yield return string.Format("{0}.addRule(new Required(\"required field\"));", DtGenUtil.ToJavaMemberName(_prop.Name));
        }

        public IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";
            yield return string.Format("\t\tto.{0}.set(from.get{1}().isNull() ? null : new DateOnly(from.get{1}().getDate()));", DtGenUtil.ToJavaMemberName(nameWoKey), nameWoKey);
        }

        public IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass)
        {
            var nameWoKey = _prop.Name.Length > 3 ? _prop.Name.Substring(0, _prop.Name.Length - 3) : "";
            yield return string.Format("\t\tresult.set{1}({0}.get() == null ? null : new NullableDate(DateOnly.toDate({0}.get())));", DtGenUtil.ToJavaMemberName(nameWoKey), nameWoKey);
        }
    }
}
