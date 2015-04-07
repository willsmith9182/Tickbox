using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaStubTemplate
    {
        public string Package
        {
            set { _packageField = value; }
        }

        public string ClassName
        {
            set { _classNameField = value; }
        }

        public List<string> Imports
        {
            set { _importsField = value; }
        }
        public List<string> JavaMethods
        {
            set { _javaMethodsField = value; }
        }

    }
}
