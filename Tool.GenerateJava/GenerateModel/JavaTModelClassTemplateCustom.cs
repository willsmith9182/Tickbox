using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaTModelClassTemplate
    {

        public string Package
        {
            set { _packageField = value; }
        }
        public string DtoPackage
        {
            set { _dtoPackageField = value; }
        }

        public string ClassName
        {
            set { _classNameField = value; }
        }

        public List<string> Imports
        {
            set { _importsField = value; }
        }

        public List<string> Properties
        {
            set { _propertiesField = value; }
        }

        public List<string> CustomCode
        {
            set { _customCodeField = value; }
        }

        public List<string> CustomImports
        {
            set { _customImportsField = value; }
        }

        public List<string> ConstructorCode
        {
            set { _constructorCodeField = value; }
        }

        public string ConstructorParams
        {
            set { _constructorParamsField = value; }
        }

        public string FromDtoConstrArgs
        {
            set { _fromDtoConstrArgsField = value; }
        }

        public List<string> FromDtoSetStmts
        {
            set { _fromDtoSetStmtsField = value; }
        }

        public List<string> ToDtoSetStmts
        {
            set { _toDtoSetStmtsField = value; }
        }

        public string RelFactoryNamespace
        {
            set { _relFactoryNamespaceField = value; }
        }
    }
}
