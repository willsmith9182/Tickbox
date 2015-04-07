using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaClassTemplate
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
        public List<string> DefaultDataInitCodeField
        {
            set { _defaultDataInitCodeField = value; }
        }
        public List<string> ConvertDates
        {
            set { _convertDatesField = value; }
        }



    }
}
