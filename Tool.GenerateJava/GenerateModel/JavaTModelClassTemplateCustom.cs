using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    partial class JavaTModelClassTemplate
    {
        public string Package
        {
            set { package = value; }
        }

        public string DtoPackage
        {
            set { dtoPackage = value; }
        }

        public string ClassName
        {
            set { className = value; }
        }

        public List<string> Imports
        {
            set { imports = value; }
        }

        public List<string> Properties
        {
            set { properties = value; }
        }

        public List<string> CustomCode
        {
            set { customCode = value; }
        }

        public List<string> CustomImports
        {
            set { customImports = value; }
        }

        public List<string> ConstructorCode
        {
            set { constructorCode = value; }
        }

        public string ConstructorParams
        {
            set { constructorParams = value; }
        }

        public string FromDtoConstrArgs
        {
            set { fromDtoConstrArgs = value; }
        }

        public List<string> FromDtoSetStmts
        {
            set { fromDtoSetStmts = value; }
        }

        public List<string> ToDtoSetStmts
        {
            set { toDtoSetStmts = value; }
        }

        public string RelFactoryNamespace
        {
            set { relFactoryNamespace = value; }
        }
    }
}