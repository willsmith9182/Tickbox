using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateWebApi
{
    partial class JavaInterfaceTemplate
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
