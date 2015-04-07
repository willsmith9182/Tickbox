using System.Collections.Generic;

namespace Tool.GenerateJava.GenerateModel
{
    interface IDatatypeGenerator
    {
        IEnumerable<string> GenerateImports(string sourceNamespace, List<string> myNamespaceList, string destPackage);
        IEnumerable<string> GeneratePropertyMethods(string sourceNamespace, GenClass genClass);
        IEnumerable<string> GenerateInitCode(string sourceNamespace);
        IEnumerable<string> GenerateConvertDates();
//        IEnumerable<string> GenerateConvertDatesObjects(string sourceNamespace);
//        IEnumerable<string> GenerateConvertDatesObjectLists(string sourceNamespace);


        IEnumerable<string> GenerateInterfaceImports(string sourceNamespace, List<string> relativeNamespace, string destPackage);
        IEnumerable<string> GenerateInterfacePropertyMethods(string sourceNamespace, GenClass genClass);

        IEnumerable<string> GenerateStubImports(string sourceNamespace, List<string> relativeNamespace, string destPackage);
        IEnumerable<string> GenerateStubPropertyMethods(string sourceNamespace, GenClass genClass);

        IEnumerable<string> GenerateTModelImports(string sourceNamespace, List<string> relativeNamespace, string dtoPackage, string destTModelPackage);
        IEnumerable<string> GenerateTModelProperties(string sourceNamespace, GenClass genClass);
        IEnumerable<string> GenerateTModelConstructorStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams);
        IEnumerable<string> GenerateTModelFromDtoStatements(string sourceNamespace, GenClass genClass, List<string> constructorParams);
        IEnumerable<string> GenerateTModelToDtoStatements(string sourceNamespace, GenClass genClass);
    }
}
