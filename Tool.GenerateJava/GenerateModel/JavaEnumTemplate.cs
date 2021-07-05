using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Tool.GenerateJava.GenerateModel
{
    /// <summary>
    ///     Class to produce the template output
    /// </summary>
#line 1 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class JavaEnumTemplate : JavaEnumTemplateBase
    {
        /// <summary>
        ///     Access the package parameter of the template.
        /// </summary>
        private string package { get; set; }

        /// <summary>
        ///     Access the enumName parameter of the template.
        /// </summary>
        private string enumName { get; set; }

        /// <summary>
        ///     Access the enumValues parameter of the template.
        /// </summary>
        private List<GenEnumItem> enumValues { get; set; }

        /// <summary>
        ///     Access the hasDescriptions parameter of the template.
        /// </summary>
        private bool hasDescriptions { get; set; }

        /// <summary>
        ///     Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            Write("\r\n\t// this is a generated file from the \"Tool.GenerateJava\" project in .Net, plea" +
                  "se do not edit directly\r\n\r\npackage ");

#line 13 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(package));

#line default
#line hidden
            Write(";\r\n\r\n");

#line 15 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            if (hasDescriptions)
            {
#line default
#line hidden
                Write("\timport java.util.Arrays;\r\n\timport java.util.EnumSet;\r\n\r\n\timport com.google.gwt.u" +
                      "ser.client.ui.ListBox;\r\n\t");

#line 20 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            }

#line default
#line hidden
            Write("\r\n\r\n\r\nimport tickbox.web.shared.util.NullableEnum;\r\nimport com.google.gwt.user.c" +
                  "lient.Window;\r\n\r\npublic enum ");

#line 27 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(" {\r\n\t\r\n");

#line 29 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"

            //Google(101, "Google Adwords"),
            //Bing(102, "Bing Ads");
            var index = 0;
            foreach (var d in enumValues)
            {
#line default
#line hidden
                Write("\t");

#line 35 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(d.Name));

#line default
#line hidden
                Write("(");

#line 35 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(d.Value));

#line default
#line hidden

#line 35 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(
                    ToStringHelper.ToStringWithCulture(hasDescriptions
                        ? string.Format(",\"{0}\"", d.Description.Replace("\"", "\\\""))
                        : ""));

#line default
#line hidden
                Write(")");

#line 35 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(enumValues.Count - 1 == index ? ";" : ","));

#line default
#line hidden
                Write("\r\n\t");

#line 36 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"

                index++;
            }


#line default
#line hidden
            Write("\r\n\t\r\n    private final int mVal;\r\n\t");

#line 43 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            if (hasDescriptions)
            {
#line default
#line hidden
                Write("private final String mDescription;\r\n\t");

#line 44 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            }

#line default
#line hidden
            Write("\r\n    private ");

#line 46 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write("(int val");

#line 46 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            if (hasDescriptions)
            {
#line default
#line hidden
                Write(", String description");

#line 46 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            }

#line default
#line hidden
            Write(") {\r\n    \tmVal = val;\r\n    \t");

#line 48 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            if (hasDescriptions)
            {
#line default
#line hidden
                Write("mDescription = description;\r\n");

#line 49 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            }

#line default
#line hidden
            Write("    }\r\n    \r\n    public int getValue() {\r\n    \treturn mVal;\r\n    }\r\n\t\r\n");

#line 56 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            if (hasDescriptions)
            {
#line default
#line hidden
                Write("\tpublic String getDescription() {\r\n\t\treturn mDescription;\r\n\t}\r\n");

#line 60 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            }

#line default
#line hidden
            Write("\r\n\tpublic static ");

#line 62 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(" fromValue(int val) {\r\n\t\tfor (");

#line 63 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(" b : ");

#line 63 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(
                ".values()) {\r\n\t\t\tif (val == b.mVal) {\r\n\t\t\t\treturn b;\r\n\t\t\t}\r\n\t\t}\r\n\t\tWindow.alert(\"" +
                "Unknown ");

#line 68 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(": \" + String.valueOf(val));\r\n\t\treturn null;\r\n\t}\r\n\r\n\t\r\n\tpublic static NullableEnum" +
                  "<");

#line 73 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write("> fromValue(String valStr) {\r\n\t\tif (\"\".equals(valStr) || \"0\".equals(valStr)) {\r\n\t" +
                  "\t\treturn new NullableEnum<");

#line 75 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(">();\r\n\t\t}\r\n\t\tint val = Integer.parseInt(valStr);\r\n\t\tfor (");

#line 78 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(" b : ");

#line 78 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(".values()) {\r\n\t\t\tif (val == b.mVal) {\r\n\t\t\t\treturn new NullableEnum<");

#line 80 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(">(b);\r\n\t\t\t}\r\n\t\t}\r\n\t\tWindow.alert(\"Unknown ");

#line 83 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
            Write(": \" + String.valueOf(val));\r\n\t\treturn null;\r\n\t}\r\n\r\n\t");

#line 87 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            if (hasDescriptions)
            {
#line default
#line hidden
                Write("\tpublic static void fillDropdown(ListBox target){\r\n\t\tfillDropdown(target, new ");

#line 89 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
                Write("[0]);\r\n\t}\r\n\r\n\tpublic static void fillDropdown(ListBox target, ");

#line 92 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
                Write("[] ignore){\r\n\t\t\r\n\t\tEnumSet<");

#line 94 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
                Write("> toIgnore = EnumSet.copyOf(Arrays.asList(ignore));\t\t\r\n\t\ttarget.clear();\r\n\t\tfor(");

#line 96 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
                Write(" v : ");

#line 96 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(enumName));

#line default
#line hidden
                Write(
                    ".values()){\r\n\t\t\tif(!toIgnore.contains(v)){\t\t\t\t\r\n\t\t\t\ttarget.addItem(v.getDescripti" +
                    "on(), String.valueOf(v.getValue()));\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n\t");

#line 102 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaEnumTemplate.tt"
            }

#line default
#line hidden
            Write("\r\n\t\r\n}\r\n\r\n");
            return GenerationEnvironment.ToString();
        }

        /// <summary>
        ///     Initialize the template
        /// </summary>
        public virtual void Initialize()
        {
            if ((Errors.HasErrors == false))
            {
                var packageValueAcquired = false;
                if (Session.ContainsKey("package"))
                {
                    package = ((string) (Session["package"]));
                    packageValueAcquired = true;
                }
                if ((packageValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("package");
                    if ((data != null))
                    {
                        package = ((string) (data));
                    }
                }
                var enumNameValueAcquired = false;
                if (Session.ContainsKey("enumName"))
                {
                    enumName = ((string) (Session["enumName"]));
                    enumNameValueAcquired = true;
                }
                if ((enumNameValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("enumName");
                    if ((data != null))
                    {
                        enumName = ((string) (data));
                    }
                }
                var enumValuesValueAcquired = false;
                if (Session.ContainsKey("enumValues"))
                {
                    enumValues = ((List<GenEnumItem>) (Session["enumValues"]));
                    enumValuesValueAcquired = true;
                }
                if ((enumValuesValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("enumValues");
                    if ((data != null))
                    {
                        enumValues = ((List<GenEnumItem>) (data));
                    }
                }
                var hasDescriptionsValueAcquired = false;
                if (Session.ContainsKey("hasDescriptions"))
                {
                    hasDescriptions = ((bool) (Session["hasDescriptions"]));
                    hasDescriptionsValueAcquired = true;
                }
                if ((hasDescriptionsValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("hasDescriptions");
                    if ((data != null))
                    {
                        hasDescriptions = ((bool) (data));
                    }
                }
            }
        }
    }

#line default
#line hidden

    #region Base class

    /// <summary>
    ///     Base class for this transformation
    /// </summary>
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class JavaEnumTemplateBase
    {
        #region Fields

        private StringBuilder generationEnvironmentField;
        private CompilerErrorCollection errorsField;
        private List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;

        #endregion

        #region Properties

        /// <summary>
        ///     The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected StringBuilder GenerationEnvironment
        {
            get
            {
                if ((generationEnvironmentField == null))
                {
                    generationEnvironmentField = new StringBuilder();
                }
                return generationEnvironmentField;
            }
            set { generationEnvironmentField = value; }
        }

        /// <summary>
        ///     The error collection for the generation process
        /// </summary>
        public CompilerErrorCollection Errors
        {
            get
            {
                if ((errorsField == null))
                {
                    errorsField = new CompilerErrorCollection();
                }
                return errorsField;
            }
        }

        /// <summary>
        ///     A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private List<int> indentLengths
        {
            get
            {
                if ((indentLengthsField == null))
                {
                    indentLengthsField = new List<int>();
                }
                return indentLengthsField;
            }
        }

        /// <summary>
        ///     Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get { return currentIndentField; }
        }

        /// <summary>
        ///     Current transformation session
        /// </summary>
        public virtual IDictionary<string, object> Session { get; set; }

        #endregion

        #region Transform-time helpers

        /// <summary>
        ///     Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((GenerationEnvironment.Length == 0)
                 || endsWithNewline))
            {
                GenerationEnvironment.Append(currentIndentField);
                endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
            {
                endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((currentIndentField.Length == 0))
            {
                GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(Environment.NewLine, (Environment.NewLine + currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (endsWithNewline)
            {
                GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - currentIndentField.Length));
            }
            else
            {
                GenerationEnvironment.Append(textToAppend);
            }
        }

        /// <summary>
        ///     Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            Write(textToAppend);
            GenerationEnvironment.AppendLine();
            endsWithNewline = true;
        }

        /// <summary>
        ///     Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            Write(string.Format(CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        ///     Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        ///     Raise an error
        /// </summary>
        public void Error(string message)
        {
            var error = new CompilerError();
            error.ErrorText = message;
            Errors.Add(error);
        }

        /// <summary>
        ///     Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            var error = new CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            Errors.Add(error);
        }

        /// <summary>
        ///     Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new ArgumentNullException("indent");
            }
            currentIndentField = (currentIndentField + indent);
            indentLengths.Add(indent.Length);
        }

        /// <summary>
        ///     Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            var returnValue = "";
            if ((indentLengths.Count > 0))
            {
                var indentLength = indentLengths[(indentLengths.Count - 1)];
                indentLengths.RemoveAt((indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = currentIndentField.Substring((currentIndentField.Length - indentLength));
                    currentIndentField = currentIndentField.Remove((currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }

        /// <summary>
        ///     Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            indentLengths.Clear();
            currentIndentField = "";
        }

        #endregion

        #region ToString Helpers

        /// <summary>
        ///     Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private IFormatProvider formatProviderField = CultureInfo.InvariantCulture;

            /// <summary>
            ///     Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public IFormatProvider FormatProvider
            {
                get { return formatProviderField; }
                set
                {
                    if ((value != null))
                    {
                        formatProviderField = value;
                    }
                }
            }

            /// <summary>
            ///     This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new ArgumentNullException("objectToConvert");
                }
                var t = objectToConvert.GetType();
                var method = t.GetMethod("ToString", new[]
                {
                    typeof (IFormatProvider)
                });
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                return ((string) (method.Invoke(objectToConvert, new object[]
                {
                    formatProviderField
                })));
            }
        }

        private readonly ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();

        /// <summary>
        ///     Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get { return toStringHelperField; }
        }

        #endregion
    }

    #endregion
}