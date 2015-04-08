using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaEnumTemplate
    {
        public string Package
        {
            set { package = value; }
        }

        public string EnumName
        {
            set { enumName = value; }
        }

        public List<GenEnumItem> EnumValues
        {
            set { enumValues = value; }
        }

        public bool HasDescriptions
        {
            set { hasDescriptions = value; }
        }
    }
}