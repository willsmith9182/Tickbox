using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaInterfaceTemplate
    {
        public string Package
        {
            set { _packageField = value; }
        }

        public string InterfaceName
        {
            set { _interfaceNameField = value; }
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
