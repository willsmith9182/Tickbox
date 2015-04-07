using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateModel
{
    class GenPackage
    {
        public GenPackage(string name)
        {
            Name = name;
        }

        public readonly string Name;
        public readonly List<GenPackage> Packages = new List<GenPackage>();
        public readonly List<string> Classes = new List<string>(); 
    }
}
