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
#line 1 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class JavaFactoryInterfaceTemplate : JavaFactoryInterfaceTemplateBase
    {
        /// <summary>
        ///     Access the package parameter of the template.
        /// </summary>
        private string package { get; set; }

        /// <summary>
        ///     Access the endPackageName parameter of the template.
        /// </summary>
        private string endPackageName { get; set; }

        /// <summary>
        ///     Access the classNames parameter of the template.
        /// </summary>
        private List<String> classNames { get; set; }

        /// <summary>
        ///     Access the subPackageNames parameter of the template.
        /// </summary>
        private List<PackageName> subPackageNames { get; set; }

        /// <summary>
        ///     Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            Write("\r\n\t// this is a generated file from the \"Tool.GenerateJava\" project in .Net, plea" +
                  "se do not edit directly\r\n\r\npackage ");

#line 13 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(package));

#line default
#line hidden
            Write(";\r\n\r\n");

#line 15 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            foreach (var p in subPackageNames)
            {
#line default
#line hidden
                Write("import ");

#line 16 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(package));

#line default
#line hidden
                Write(".");

#line 16 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(p.LowerCase));

#line default
#line hidden
                Write(".I");

#line 16 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(p.MixCase));

#line default
#line hidden
                Write("ObjFactory;\r\n");

#line 17 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            }

#line default
#line hidden
            Write("\r\n\r\npublic interface I");

#line 20 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(endPackageName));

#line default
#line hidden
            Write("ObjFactory {\r\n");

#line 21 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            foreach (var c in classNames)
            {
#line default
#line hidden
                Write("\tI");

#line 22 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(c));

#line default
#line hidden
                Write(" newI");

#line 22 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(c));

#line default
#line hidden
                Write("();\r\n");

#line 23 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            }

#line default
#line hidden
            Write("\r\n");

#line 25 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            foreach (var p in subPackageNames)
            {
#line default
#line hidden
                Write("\t\r\n\tI");

#line 26 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(p.MixCase));

#line default
#line hidden
                Write("ObjFactory ");

#line 26 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(p.LowerCase));

#line default
#line hidden
                Write("();\r\n");

#line 27 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaFactoryInterfaceTemplate.tt"
            }

#line default
#line hidden
            Write("\t\r\n}\r\n");
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
                var endPackageNameValueAcquired = false;
                if (Session.ContainsKey("endPackageName"))
                {
                    endPackageName = ((string) (Session["endPackageName"]));
                    endPackageNameValueAcquired = true;
                }
                if ((endPackageNameValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("endPackageName");
                    if ((data != null))
                    {
                        endPackageName = ((string) (data));
                    }
                }
                var classNamesValueAcquired = false;
                if (Session.ContainsKey("classNames"))
                {
                    classNames = ((List<String>) (Session["classNames"]));
                    classNamesValueAcquired = true;
                }
                if ((classNamesValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("classNames");
                    if ((data != null))
                    {
                        classNames = ((List<String>) (data));
                    }
                }
                var subPackageNamesValueAcquired = false;
                if (Session.ContainsKey("subPackageNames"))
                {
                    subPackageNames = ((List<PackageName>) (Session["subPackageNames"]));
                    subPackageNamesValueAcquired = true;
                }
                if ((subPackageNamesValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("subPackageNames");
                    if ((data != null))
                    {
                        subPackageNames = ((List<PackageName>) (data));
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
    public class JavaFactoryInterfaceTemplateBase
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