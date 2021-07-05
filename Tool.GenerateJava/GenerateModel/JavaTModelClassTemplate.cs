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
#line 1 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class JavaTModelClassTemplate : JavaTModelClassTemplateBase
    {
        /// <summary>
        ///     Access the package parameter of the template.
        /// </summary>
        private string package { get; set; }

        /// <summary>
        ///     Access the className parameter of the template.
        /// </summary>
        private string className { get; set; }

        /// <summary>
        ///     Access the dtoPackage parameter of the template.
        /// </summary>
        private string dtoPackage { get; set; }

        /// <summary>
        ///     Access the imports parameter of the template.
        /// </summary>
        private List<String> imports { get; set; }

        /// <summary>
        ///     Access the properties parameter of the template.
        /// </summary>
        private List<String> properties { get; set; }

        /// <summary>
        ///     Access the customCode parameter of the template.
        /// </summary>
        private List<String> customCode { get; set; }

        /// <summary>
        ///     Access the customImports parameter of the template.
        /// </summary>
        private List<String> customImports { get; set; }

        /// <summary>
        ///     Access the constructorCode parameter of the template.
        /// </summary>
        private List<String> constructorCode { get; set; }

        /// <summary>
        ///     Access the constructorParams parameter of the template.
        /// </summary>
        private string constructorParams { get; set; }

        /// <summary>
        ///     Access the fromDtoConstrArgs parameter of the template.
        /// </summary>
        private string fromDtoConstrArgs { get; set; }

        /// <summary>
        ///     Access the fromDtoSetStmts parameter of the template.
        /// </summary>
        private List<String> fromDtoSetStmts { get; set; }

        /// <summary>
        ///     Access the toDtoSetStmts parameter of the template.
        /// </summary>
        private List<String> toDtoSetStmts { get; set; }

        /// <summary>
        ///     Access the relFactoryNamespace parameter of the template.
        /// </summary>
        private string relFactoryNamespace { get; set; }

        /// <summary>
        ///     Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            Write("\r\n\r\n\t// this is a generated file from the \"Tool.GenerateJava\" project in .Net, pl" +
                  "ease do not edit directly\r\n\r\npackage ");

#line 23 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(package));

#line default
#line hidden
            Write(";\r\n\r\n//*** Start Custom imports ***\r\n");

#line 26 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"

            foreach (var cc in customImports)
            {
#line default
#line hidden

#line 28 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(cc));

#line default
#line hidden
                Write("\r\n");

#line 29 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            }


#line default
#line hidden
            Write("//*** End Custom imports ***\r\n\r\nimport ");

#line 33 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(dtoPackage));

#line default
#line hidden
            Write(".I");

#line 33 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write(";\r\nimport tickbox.web.shared.util.ObjFactory;\r\n");

#line 35 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"

            foreach (var import in imports)
            {
#line default
#line hidden
                Write("import ");

#line 37 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(import));

#line default
#line hidden
                Write(";\r\n");

#line 38 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            }


#line default
#line hidden
            Write("\r\n\r\n\r\n\r\npublic class ");

#line 45 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("Tm {\r\n\r\n//*** Start Custom code block ***\r\n");

#line 48 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"

            foreach (var cc in customCode)
            {
#line default
#line hidden

#line 50 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(cc));

#line default
#line hidden
                Write("\r\n");

#line 51 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            }


#line default
#line hidden
            Write("//*** End Custom code block ***\r\n\r\n\r\n\tpublic ");

#line 56 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("Tm(");

#line 56 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(constructorParams));

#line default
#line hidden
            Write(") {\r\n");

#line 57 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"

            foreach (var cc in constructorCode)
            {
#line default
#line hidden

#line 59 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(cc));

#line default
#line hidden
                Write("\r\n");

#line 60 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            }


#line default
#line hidden
            Write("\r\n\t\tinit();\r\n\t}\r\n\t\r\n\r\n\r\n");

#line 69 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"

            foreach (var p in properties)
            {
#line default
#line hidden

#line 71 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(p));

#line default
#line hidden
                Write("\r\n");

#line 72 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            }


#line default
#line hidden
            Write("\r\n\r\n\r\n\tpublic void setFrom(I");

#line 78 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write(" dto) {\r\n\t\tif (dto == null) {\r\n\t\t\tdto = ObjFactory.dto()");

#line 80 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(relFactoryNamespace));

#line default
#line hidden
            Write(".newI");

#line 80 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("();\r\n\t\t}\r\n\t\t\r\n\r\n\t\tcopy(dto, this);\r\n\t}\r\n\t\r\n\tpublic static void copy(I");

#line 87 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write(" from, ");

#line 87 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("Tm to) {\t\r\n");

#line 88 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"

            foreach (var p in fromDtoSetStmts)
            {
#line default
#line hidden

#line 90 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(p));

#line default
#line hidden
                Write("\r\n");

#line 91 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            }


#line default
#line hidden
            Write("\t}\r\n\t\r\n\r\n\tpublic static ");

#line 97 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("Tm fromDto(I");

#line 97 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write(" dto) {\r\n\t\tif (dto == null) {\r\n\t\t\treturn null;\r\n\t\t}\r\n\t\t");

#line 101 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("Tm result = new ");

#line 101 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("Tm(");

#line 101 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(fromDtoConstrArgs));

#line default
#line hidden
            Write(");\r\n\t\t\r\n\t\tcopy(dto, result);\r\n\t\t\r\n\t\treturn result;\r\n\t}\r\n\t\r\n\tpublic I");

#line 108 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write(" toDto() {\r\n\t\tI");

#line 109 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write(" result = ObjFactory.dto()");

#line 109 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(relFactoryNamespace));

#line default
#line hidden
            Write(".newI");

#line 109 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            Write(ToStringHelper.ToStringWithCulture(className));

#line default
#line hidden
            Write("();\r\n\t\t\r\n");

#line 111 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"

            foreach (var p in toDtoSetStmts)
            {
#line default
#line hidden

#line 113 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
                Write(ToStringHelper.ToStringWithCulture(p));

#line default
#line hidden
                Write("\r\n");

#line 114 "D:\Lat Projects\WL_Main\Tool.GenerateJava\GenerateModel\JavaTModelClassTemplate.tt"
            }


#line default
#line hidden
            Write("\t\t\r\n\t\treturn result;\r\n\t}\r\n\r\n}\r\n");
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
                var classNameValueAcquired = false;
                if (Session.ContainsKey("className"))
                {
                    className = ((string) (Session["className"]));
                    classNameValueAcquired = true;
                }
                if ((classNameValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("className");
                    if ((data != null))
                    {
                        className = ((string) (data));
                    }
                }
                var dtoPackageValueAcquired = false;
                if (Session.ContainsKey("dtoPackage"))
                {
                    dtoPackage = ((string) (Session["dtoPackage"]));
                    dtoPackageValueAcquired = true;
                }
                if ((dtoPackageValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("dtoPackage");
                    if ((data != null))
                    {
                        dtoPackage = ((string) (data));
                    }
                }
                var importsValueAcquired = false;
                if (Session.ContainsKey("imports"))
                {
                    imports = ((List<String>) (Session["imports"]));
                    importsValueAcquired = true;
                }
                if ((importsValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("imports");
                    if ((data != null))
                    {
                        imports = ((List<String>) (data));
                    }
                }
                var propertiesValueAcquired = false;
                if (Session.ContainsKey("properties"))
                {
                    properties = ((List<String>) (Session["properties"]));
                    propertiesValueAcquired = true;
                }
                if ((propertiesValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("properties");
                    if ((data != null))
                    {
                        properties = ((List<String>) (data));
                    }
                }
                var customCodeValueAcquired = false;
                if (Session.ContainsKey("customCode"))
                {
                    customCode = ((List<String>) (Session["customCode"]));
                    customCodeValueAcquired = true;
                }
                if ((customCodeValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("customCode");
                    if ((data != null))
                    {
                        customCode = ((List<String>) (data));
                    }
                }
                var customImportsValueAcquired = false;
                if (Session.ContainsKey("customImports"))
                {
                    customImports = ((List<String>) (Session["customImports"]));
                    customImportsValueAcquired = true;
                }
                if ((customImportsValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("customImports");
                    if ((data != null))
                    {
                        customImports = ((List<String>) (data));
                    }
                }
                var constructorCodeValueAcquired = false;
                if (Session.ContainsKey("constructorCode"))
                {
                    constructorCode = ((List<String>) (Session["constructorCode"]));
                    constructorCodeValueAcquired = true;
                }
                if ((constructorCodeValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("constructorCode");
                    if ((data != null))
                    {
                        constructorCode = ((List<String>) (data));
                    }
                }
                var constructorParamsValueAcquired = false;
                if (Session.ContainsKey("constructorParams"))
                {
                    constructorParams = ((string) (Session["constructorParams"]));
                    constructorParamsValueAcquired = true;
                }
                if ((constructorParamsValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("constructorParams");
                    if ((data != null))
                    {
                        constructorParams = ((string) (data));
                    }
                }
                var fromDtoConstrArgsValueAcquired = false;
                if (Session.ContainsKey("fromDtoConstrArgs"))
                {
                    fromDtoConstrArgs = ((string) (Session["fromDtoConstrArgs"]));
                    fromDtoConstrArgsValueAcquired = true;
                }
                if ((fromDtoConstrArgsValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("fromDtoConstrArgs");
                    if ((data != null))
                    {
                        fromDtoConstrArgs = ((string) (data));
                    }
                }
                var fromDtoSetStmtsValueAcquired = false;
                if (Session.ContainsKey("fromDtoSetStmts"))
                {
                    fromDtoSetStmts = ((List<String>) (Session["fromDtoSetStmts"]));
                    fromDtoSetStmtsValueAcquired = true;
                }
                if ((fromDtoSetStmtsValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("fromDtoSetStmts");
                    if ((data != null))
                    {
                        fromDtoSetStmts = ((List<String>) (data));
                    }
                }
                var toDtoSetStmtsValueAcquired = false;
                if (Session.ContainsKey("toDtoSetStmts"))
                {
                    toDtoSetStmts = ((List<String>) (Session["toDtoSetStmts"]));
                    toDtoSetStmtsValueAcquired = true;
                }
                if ((toDtoSetStmtsValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("toDtoSetStmts");
                    if ((data != null))
                    {
                        toDtoSetStmts = ((List<String>) (data));
                    }
                }
                var relFactoryNamespaceValueAcquired = false;
                if (Session.ContainsKey("relFactoryNamespace"))
                {
                    relFactoryNamespace = ((string) (Session["relFactoryNamespace"]));
                    relFactoryNamespaceValueAcquired = true;
                }
                if ((relFactoryNamespaceValueAcquired == false))
                {
                    var data = CallContext.LogicalGetData("relFactoryNamespace");
                    if ((data != null))
                    {
                        relFactoryNamespace = ((string) (data));
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
    public class JavaTModelClassTemplateBase
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