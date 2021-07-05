using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaFactoryStubTemplate
    {
        public string Package
        {
            set { package = value; }
        }

        public string EndPackageName
        {
            set { endPackageName = value; }
        }

        public List<string> ClassNames
        {
            set { classNames = value; }
        }

        public List<PackageName> SubPackageNames
        {
            set { subPackageNames = value; }
        }
    }
}