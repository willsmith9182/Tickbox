using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaInterfaceTemplate
    {
        public string Package
        {
            set { package = value; }
        }

        public string InterfaceName
        {
            set { interfaceName = value; }
        }

        public List<string> Imports
        {
            set { imports = value; }
        }

        public List<string> JavaMethods
        {
            set { javaMethods = value; }
        }
    }
}