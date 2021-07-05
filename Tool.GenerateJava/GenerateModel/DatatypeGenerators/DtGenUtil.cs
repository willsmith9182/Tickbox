using System;
using System.Collections.Generic;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel.DatatypeGenerators
{
    public static class DtGenUtil
    {
        internal static string GenNativeDeleteMethod(GenProperty prop)
        {
            if (!prop.CanWrite)
            {
                return null;
            }
            return String.Format("\tprivate final native void delete{0}() /*-{{ delete this.{0}; }}-*/;", prop.Name);
        }

        internal static string GenNativeGetIsNullMethod(GenProperty prop)
        {
            if (!prop.CanRead)
            {
                return null;
            }
            return String.Format("\tprivate final native boolean get{0}IsNull() /*-{{ return this.{0} == null; }}-*/;",
                prop.Name);
        }

        internal static string GenNativeSetIsNullMethod(GenProperty prop)
        {
            if (!prop.CanWrite)
            {
                return null;
            }
            return String.Format("\tprivate final native void set{0}IsNull() /*-{{ this.{0} = null; }}-*/;", prop.Name);
        }

        internal static string GenNativeGetMethod(GenProperty prop, string javaDatatype)
        {
            return GenNativeGetMethod(prop, javaDatatype, true);
        }

        internal static string GenNativeGetMethod(GenProperty prop, string javaDatatype, bool isPublic)
        {
            return GenNativeGetMethod(prop, javaDatatype, isPublic, String.Format("get{0}", prop.Name), isPublic);
        }

        internal static string GenNativeGetMethod(GenProperty prop, string javaDatatype, bool isPublic, bool overrides)
        {
            return GenNativeGetMethod(prop, javaDatatype, isPublic, String.Format("get{0}", prop.Name), overrides);
        }

        internal static string GenNativeGetMethod(GenProperty prop, string javaDatatype, bool isPublic,
            string javaMethodName)
        {
            return GenNativeGetMethod(prop, javaDatatype, isPublic, javaMethodName, isPublic);
        }

        internal static string GenNativeGetMethod(GenProperty prop, string javaDatatype, bool isPublic,
            string javaMethodName, bool overrides)
        {
            if (!prop.CanRead)
            {
                return null;
            }
            return String.Format("\t{2} final native {1} {3}() /*-{{ return this.{0} }}-*/;", prop.Name, javaDatatype,
                (overrides ? "@Override " : "") + (isPublic ? "public" : "private"), javaMethodName);
        }

        internal static string GenNativeSetMethod(GenProperty prop, string javaDatatype, GenClass genClass)
        {
            return GenNativeSetMethod(prop, javaDatatype, true, genClass);
        }

        internal static string GenNativeSetMethod(GenProperty prop, string javaDatatype, bool isPublic,
            GenClass genClass)
        {
            return GenNativeSetMethod(prop, javaDatatype, isPublic, String.Format("set{0}", prop.Name), genClass);
        }

        internal static string GenNativeSetMethod(GenProperty prop, string javaDatatype, bool isPublic,
            string javaMethodName, GenClass genClass)
        {
            if (!prop.CanWrite)
            {
                return null;
            }
            if (isPublic)
            {
                return
                    String.Format(
                        "\t@Override public final native {3} {2}({1} val) /*-{{ this.{0} = val; return this; }}-*/;",
                        prop.Name, javaDatatype, javaMethodName, genClass.Name);
            }
            return String.Format("\tprivate final native void {2}({1} val) /*-{{ this.{0} = val; }}-*/;", prop.Name,
                javaDatatype, javaMethodName);
        }

        internal static string GenInterfaceGetMethod(GenProperty prop, string javaDatatype)
        {
            return GenInterfaceGetMethod(prop, javaDatatype, String.Format("get{0}", prop.Name));
        }

        internal static string GenInterfaceGetMethod(GenProperty prop, string javaDatatype, string javaMethodName)
        {
            if (!prop.CanRead)
            {
                return null;
            }
            return String.Format("\t{0} {1}();", javaDatatype, javaMethodName);
        }

        internal static string GenInterfaceSetMethod(GenProperty prop, string javaDatatype, GenClass genClass)
        {
            return GenInterfaceSetMethod(prop, javaDatatype, String.Format("set{0}", prop.Name), genClass);
        }

        internal static string GenInterfaceSetMethod(GenProperty prop, string javaDatatype, string javaMethodName,
            GenClass genClass)
        {
            if (!prop.CanWrite)
            {
                return null;
            }
            return String.Format("\tI{2} {1}({0} val);", javaDatatype, javaMethodName, genClass.Name);
        }

        internal static string GenStubPrivateMember(GenProperty prop, string javaDatatype, string initialValue)
        {
            return String.Format("\tprivate {1} _{0} = {2};", prop.Name, javaDatatype, initialValue);
        }

        internal static string GenStubGetMethod(GenProperty prop, string javaDatatype)
        {
            return String.Format("\t{2}public {1} get{0}() {{ return this._{0}; }}", prop.Name, javaDatatype,
                prop.CanRead ? "@Override " : "");
        }

        internal static string GenStubSetMethod(GenProperty prop, string javaDatatype, GenClass genClass)
        {
            return String.Format("\t{3}public I{2} set{0}({1} val) {{ this._{0} = val; return this; }}", prop.Name,
                javaDatatype, genClass.Name, prop.CanWrite ? "@Override " : "");
        }

        internal static string GenSetCall(string methodToSet, string javaExpression)
        {
            return String.Format("\t\tresult.{0}({1});", methodToSet, javaExpression);
        }

        internal static string GenSetCall(GenProperty prop, string javaExpression)
        {
            return GenSetCall(String.Format("set{0}", prop.Name), javaExpression);
        }

        internal static IEnumerable<string> CalculateRelativeNamespace(string fullNamespace, string sourceNamespace)
        {
            var fns = fullNamespace.Split('.');
            var sns = sourceNamespace.Split('.');

            if (sns.Where((t, i) => fns[i] != t).Any())
            {
                throw new Exception(String.Format("namespace, {0}, doesn't belong to sourceNamespace, {1}",
                    fullNamespace, sourceNamespace));
            }

            return fns.Skip(sns.Length);
        }

        public static string ToJavaMemberName(string name)
        {
            if (name.Length < 2)
            {
                return name.ToLowerInvariant();
            }
            var newName = name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
            if (newName == "default")
            {
                return "defaul";
            }
            if (newName == "package")
            {
                return "pckage";
            }
            return newName;
        }
    }
}