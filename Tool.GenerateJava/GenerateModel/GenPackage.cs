using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    internal class GenPackage
    {
        public readonly List<string> Classes = new List<string>();
        public readonly string Name;
        public readonly List<GenPackage> Packages = new List<GenPackage>();

        public GenPackage(string name)
        {
            Name = name;
        }
    }
}