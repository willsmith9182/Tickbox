using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
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

        public List<string> DefaultDataInitCodeField
        {
            set { defaultDataInitCode = value; }
        }

        public List<string> ConvertDates
        {
            set { convertDates = value; }
        }
    }
}