using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateWebApi
{
    partial class JavaClassTemplate
    {
        public string Package
        {
            set { package = value; }
        }

        public string ClassName
        {
            set { className = value; }
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