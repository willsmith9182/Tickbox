using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateWebApi
{
    partial class JavaFactoryTemplate
    {

        public string Package
        {
            set { _packageField = value; }
        }

        public List<ClassNamePair> ClassNames
        {
            set { _classNamesField = value; }
        }

    }
}
