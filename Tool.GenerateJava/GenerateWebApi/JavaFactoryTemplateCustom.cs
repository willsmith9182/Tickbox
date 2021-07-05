using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateWebApi
{
    partial class JavaFactoryTemplate
    {
        public string Package
        {
            set { package = value; }
        }

        public List<ClassNamePair> ClassNames
        {
            set { classNames = value; }
        }
    }
}