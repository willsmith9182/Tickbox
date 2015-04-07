using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateModel
{
    public class PackageName
    {
        public PackageName(string lowerCase)
        {
            LowerCase = lowerCase;
            MixCase = lowerCase.Substring(0, 1).ToUpperInvariant() + lowerCase.Substring(1);
        }

        public readonly string LowerCase;

        public readonly string MixCase;
    }
}
