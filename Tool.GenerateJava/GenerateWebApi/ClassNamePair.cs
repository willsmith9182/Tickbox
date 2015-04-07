using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateWebApi
{
    public class ClassNamePair
    {
        public ClassNamePair(string pascalCaseName)
        {

            PascalCaseName = pascalCaseName;
            CamelCaseName = pascalCaseName.Substring(0, 1).ToLowerInvariant() + pascalCaseName.Substring(1);
        }

        public readonly string CamelCaseName;
        public readonly string PascalCaseName;
    }
}
