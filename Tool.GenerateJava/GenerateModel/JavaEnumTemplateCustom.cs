using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaEnumTemplate
    {


        public string Package
        {
            set { _packageField = value; }
        }

        public string EnumName
        {
            set { _enumNameField = value; }
        }

        public List<GenEnumItem> EnumValues
        {
            set { _enumValuesField = value; }
        }

        public bool HasDescriptions
        {
            set { _hasDescriptionsField = value; }
        }

    }
}
