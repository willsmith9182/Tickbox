using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Tool.GenerateJava.GenerateModel.DatatypeGenerators;

namespace Tool.GenerateJava.GenerateModel
{
    static class ModelGenerator
    {

        public static void GenModel(string[] args)
        {
            var assemblyPath = args[1];
            var sourceNamespace = args[2];
            var destDtoSrcDirectory = args[3];
            var destDtoPackage = args[4];

            var destDtoDirectory = Path.Combine(destDtoSrcDirectory, PackageToDirectory(destDtoPackage));

            var classes = ReadClasses(assemblyPath, sourceNamespace)
                .ToList();

            RemoveDateTimePropertiesWithMatchingDateKeyProperty(classes);
            MakeIEnumerableReadOnly(classes);
            
            var enums = ReadEnums(assemblyPath, sourceNamespace)
                .ToList();


            DeleteDirectory(destDtoDirectory);

            foreach (var c in classes)
            {
                var genDatatypes = c.Properties
                    .Select(p => new
                    {
                        Generator = p.GetGenerator(sourceNamespace),
                        p.CanWrite
                    })
                    .ToList();

                var classTemplate = new JavaClassTemplate
                {
                    ClassName = c.Name,
                    Imports = genDatatypes
                        .SelectMany(p => p.Generator.GenerateImports(sourceNamespace, c.RelativeDotNetNamespace, destDtoPackage))
                        .Where(i => i != null)
                        .Distinct()
                        .ToList(),
                    JavaMethods = genDatatypes
                        .SelectMany(p => p.Generator.GeneratePropertyMethods(sourceNamespace, c))
                        .Where(p => p != null)
                        .ToList(),
                    DefaultDataInitCodeField = genDatatypes
                        .Where(p => p.CanWrite)
                        .SelectMany(p => p.Generator.GenerateInitCode(sourceNamespace))
                        .Where(p => p != null)
                        .ToList(),
                    ConvertDates = genDatatypes
                        .SelectMany(p => p.Generator.GenerateConvertDates())
                        .Where(p => p != null)
                        .ToList(),
                    Package =
                        destDtoPackage + string.Join("", c.RelativeDotNetNamespace.Select(s => "." + s)).ToLowerInvariant()
                };
                var javaClassContents = classTemplate.TransformText();
                WriteToFile(javaClassContents,
                    destDtoDirectory + string.Join("", c.RelativeDotNetNamespace.Select(s => "\\" + s)).ToLowerInvariant(),
                    string.Format("{0}.java", c.Name));


                var interfaceTemplate = new JavaInterfaceTemplate
                {
                    InterfaceName = "I" + c.Name,
                    Imports = genDatatypes
                        .SelectMany(p => p.Generator.GenerateInterfaceImports(sourceNamespace, c.RelativeDotNetNamespace, destDtoPackage))
                        .Where(i => i != null)
                        .Distinct()
                        .ToList(),
                    JavaMethods = genDatatypes
                        .SelectMany(p => p.Generator.GenerateInterfacePropertyMethods(sourceNamespace, c))
                        .Where(p => p != null)
                        .ToList(),
                    Package =
                        destDtoPackage + string.Join("", c.RelativeDotNetNamespace.Select(s => "." + s)).ToLowerInvariant()
                };

                var javaInterfaceContents = interfaceTemplate.TransformText();
                WriteToFile(javaInterfaceContents,
                    destDtoDirectory + string.Join("", c.RelativeDotNetNamespace.Select(s => "\\" + s)).ToLowerInvariant(),
                    string.Format("I{0}.java", c.Name));

            }

            foreach (var e in enums)
            {
                var classTemplate = new JavaEnumTemplate
                {
                    EnumName = e.Name,
                    Package =
                        destDtoPackage + string.Join("", e.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant(),
                    HasDescriptions = e.Values.Any(v => v.Description != null),
                    EnumValues = e.Values,
                };
                var javaContents = classTemplate.TransformText();

                WriteToFile(javaContents,
                    destDtoDirectory + string.Join("", e.RelativeNamespace.Select(s => "\\" + s)).ToLowerInvariant(),
                    string.Format("{0}.java", e.Name));
            }
        }
        
        private class PackageAndClasses
        {
            public readonly List<GenPackage> Packages = new List<GenPackage>();
            public readonly List<string> Classes = new List<string>(); 
        }

        private static PackageAndClasses ConvertToPackagesAndClasses(IEnumerable<GenClass> classes)
        {
            var result = new PackageAndClasses();
            foreach (var c in classes)
            {
                var packages = c.RelativeDotNetNamespace
                    .Select(n => n.ToLowerInvariant())
                    .ToList();
                if (packages.Any())
                {
                    var package = GetOrCreatePackage(result.Packages, packages);
                    package.Classes.Add(c.Name);
                }
                else
                {
                    result.Classes.Add(c.Name);
                }
            }

            return result;

        }

        private static GenPackage GetOrCreatePackage(List<GenPackage> dest, List<string> packages)
        {
            while (true)
            {
                if (!packages.Any())
                {
                    throw new Exception("There must be at least one package.");
                }
                var package = dest.FirstOrDefault(p => p.Name == packages.First());
                if (package == null)
                {
                    package = new GenPackage(packages.First());
                    dest.Add(package);
                }
                var subList = packages.Skip(1).ToList();
                if (!subList.Any()) return package;
                dest = package.Packages;
                packages = subList;
            }
        }

        internal static string PackageToDirectory(string package)
        {
            var folderNames = package.Split('.');
            return Path.Combine(folderNames);
        }


        private static IEnumerable<GenEnum> ReadEnums(string assemblyPath, string sourceNamespace)
        {
            var assemb = Assembly.LoadFile(assemblyPath);

            //            var test = (from t in assemb.GetTypes()
            //                where (t.Namespace ?? "").StartsWith(sourceNamespace)
            //                      && t.Name.StartsWith("<")
            //                select t)
            //                .ToList();

            return from t in assemb.GetTypes()
                   where (t.Namespace ?? "").StartsWith(sourceNamespace)
                         && !t.IsNested
                         && t.IsEnum
                         && Enum.GetValues(t).Length > 0
                   select new GenEnum
                   {
                       Name = t.Name,
                       Values = ConvertToGenEnum(Enum.GetValues(t), t)
                           .ToList(),
                       RelativeNamespace = DtGenUtil.CalculateRelativeNamespace(t.Namespace, sourceNamespace)
                           .ToList()
                   };
        }

        private static IEnumerable<GenEnumItem> ConvertToGenEnum(Array enumValues, Type enumType)
        {
            return from object val in enumValues
                   select new GenEnumItem
                   {
                       Description = GetDescription(val, enumType),
                       Name = val.ToString(),
                       Value = Convert.ToInt64(val)
                   };
        }

        public static string GetDescription(object val, Type enumType)
        {
            var memberInfo = enumType.GetMember(val.ToString())
                                                 .FirstOrDefault();

            if (memberInfo != null)
            {
                var attribute =
                        memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .Cast<DescriptionAttribute>()
                        .Select(a => a.Description)
                                  .FirstOrDefault();
                return attribute;
            }

            //return null;
            //or

            throw new NotImplementedException("There is no description for this enum");
        }

        public static void MakeIEnumerableReadOnly(List<GenClass> classes)
        {
            foreach (var c in classes)
            {
                foreach (var p in c.Properties)
                {
                    if (p.PropType.Name == "IEnumerable`1")
                    {
                        p.CanWrite = false;
                    }
                }
            }
        }

        public static void RemoveDateTimePropertiesWithMatchingDateKeyProperty(IEnumerable<GenClass> classes)
        {

            foreach (var c in classes)
            {
                foreach (var p in c.Properties
                    .Where(p => p.PropType == typeof(DateTime))
                    .ToList())
                {


                    var dtProp = c.Properties.FirstOrDefault(tp => tp.PropType == typeof(int)
                                                                   &&
                                                                   (tp.Name == p.Name + "Key" ||
                                                                    tp.Name == p.Name + "DateKey"));
                    if (dtProp != null)
                    {
                        c.Properties.Remove(p);
                        dtProp.DateTimeSisterProperty = p;
                    }
                }

                foreach (var p in c.Properties
                    .Where(p => p.PropType == typeof(DateTime?))
                    .ToList())
                {



                    var dtProp = c.Properties.FirstOrDefault(tp => tp.PropType == typeof(int?)
                                                                   &&
                                                                   (tp.Name == p.Name + "Key" ||
                                                                    tp.Name == p.Name + "DateKey"));
                    if (dtProp != null)
                    {
                        c.Properties.Remove(p);
                        dtProp.DateTimeSisterProperty = p;
                    }
                }
            }

        }

        public static void DeleteDirectory(string destDirectory)
        {
            var dirInfo = new DirectoryInfo(destDirectory);
            if (dirInfo.Exists)
            {
                foreach (var f in dirInfo.EnumerateFiles())
                {
                    f.Delete();
                }
                foreach (var d in dirInfo.EnumerateDirectories())
                {
                    d.Delete(true);
                }
            }
        }

        private static IEnumerable<GenClass> ReadClasses(string assemblyPath, string sourceNamespace)
        {
            var assemb = Assembly.LoadFile(assemblyPath);

            //            var test = (from t in assemb.GetTypes()
            //                where (t.Namespace ?? "").StartsWith(sourceNamespace)
            //                      && t.Name.StartsWith("<")
            //                select t)
            //                .ToList();

            return from t in assemb.GetTypes()
                   where (t.Namespace ?? "").StartsWith(sourceNamespace)
                         && !t.IsNested
                         && t.IsClass
                         && t.GetProperties().Any()
                   select new GenClass
                   {
                       Name = t.Name,
                       Properties = t.GetProperties()
                           .Select(p => new GenProperty
                           {
                               Name = p.Name,
                               PropType = p.PropertyType,
                               CanRead = p.CanRead,
                               CanWrite = p.CanWrite
                           })
                           .ToList(),
                       RelativeDotNetNamespace = DtGenUtil.CalculateRelativeNamespace(t.Namespace, sourceNamespace)
                           .ToList()
                   };
        }


        public static void WriteToFile(string javaContents, string destDirectory, string fileName)
        {
            var fileInfo = new FileInfo(Path.Combine(destDirectory, fileName));
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
            using (var s = fileInfo.CreateText())
            {
                s.Write(javaContents);
            }
        }
    }
}
