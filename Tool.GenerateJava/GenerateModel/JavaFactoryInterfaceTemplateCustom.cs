using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaFactoryInterfaceTemplate
    {
        public string Package
        {
            set { _packageField = value; }
        }

        public string EndPackageName
        {
            set { _endPackageNameField = value; }
        }

        public List<string> ClassNames
        {
            set { _classNamesField = value; }
        }

        public List<PackageName> SubPackageNames
        {
            set { _subPackageNamesField = value; }
        }
    }
}
