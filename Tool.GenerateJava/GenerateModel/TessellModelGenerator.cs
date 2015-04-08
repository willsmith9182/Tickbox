using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tool.GenerateJava.GenerateModel
{
    static class TessellModelGenerator
    {

        public static void Run(string destTModelPackage, string destTModelSrcDirectory, List<GenClass> classes, string destDtoPackage, string sourceNamespace)
        {

            var destTModelDirectory = Path.Combine(destTModelSrcDirectory, ModelGenerator.PackageToDirectory(destTModelPackage));

            var destTModelDir = new DirectoryInfo(destTModelDirectory);
            if (!destTModelDir.Exists)
            {
                destTModelDir.Create();
            }
            var existingFiles = FindAllFiles(destTModelDir)
                .ToDictionary(f => f.FullName);

            foreach (var c in classes)
            {
                var destFile = destTModelDir.FullName + string.Join("", c.RelativeDotNetNamespace.Select(n => "\\" + n.ToLowerInvariant())) + "\\" + c.Name + "Tm.java";
                var existingFile = existingFiles.GetOrDefault(destFile);

                GenerateClass(destFile, existingFile, c, destTModelPackage, destDtoPackage, sourceNamespace);

                if (existingFile != null)
                {
                    existingFiles.Remove(destFile);
                }

            }

            foreach (var f in existingFiles)
            {
                f.Value.Delete();
            }

        }

        private static void GenerateClass(string destFile, FileInfo existingFile, GenClass genClass, string destTModelPackage, string destDtoPackage, string sourceNamespace)
        {


            var customCode = new List<string>();
            var customImports = new List<string>();

            if (existingFile != null)
            {
                using (var s = existingFile.OpenRead())
                using (var r = new StreamReader(s))
                {
                    string line;

                    while ((line = r.ReadLine()) != null)
                    {
                        if (line.Contains("//*** Start Custom imports ***"))
                        {
                            customImports.Add(
                                line.Substring(line.IndexOf("//*** Start Custom imports ***") +
                                               "//*** Start Custom imports ***".Length));
                            break;
                        }
                    }


                    while ((line = r.ReadLine()) != null)
                    {
                        if (line.Contains("//*** End Custom imports ***"))
                        {
                            customImports.Add(line.Substring(0, line.IndexOf(("//*** End Custom imports ***"))));
                            break;
                        }
                        customImports.Add(line);
                    }

                    while ((line = r.ReadLine()) != null)
                    {
                        if (line.Contains("//*** Start Custom code block ***"))
                        {
                            customCode.Add(
                                line.Substring(line.IndexOf("//*** Start Custom code block ***") +
                                               "//*** Start Custom code block ***".Length));
                            break;
                        }
                    }


                    while ((line = r.ReadLine()) != null)
                    {
                        if (line.Contains("//*** End Custom code block ***"))
                        {
                            customCode.Add(line.Substring(0, line.IndexOf(("//*** End Custom code block ***"))));
                            break;
                        }
                        customCode.Add(line);
                    }
                }
            }
            else
            {
                existingFile = new FileInfo(destFile);
                if (!existingFile.Directory.Exists)
                {
                    existingFile.Directory.Create();
                }




            }


            if (customCode.All(string.IsNullOrWhiteSpace))
            {

                customCode = new[]
                {
                    "\tprivate void init() {", 
                    "\t}"
                }.ToList();
            }

            CleanCustomCode(customCode);
            CleanCustomCode(customImports);


//            customCode = customCode
//                .Select(l => l.Trim())
//                .Where(l => !string.IsNullOrWhiteSpace(l))
//                .ToList();


            var constructorParams = new List<string>();
            var fromDtoConstructorParams = new List<string>();

            var template = new JavaTModelClassTemplate
            {
                ClassName = genClass.Name,
                Imports =
                    genClass.Properties.SelectMany(
                        p =>
                            p.GetGenerator(sourceNamespace)
                                .GenerateTModelImports(sourceNamespace, genClass.RelativeDotNetNamespace,
                                    destDtoPackage, destTModelPackage)).Where(i => i != null).Distinct().ToList(),
                Package =
                    destTModelPackage +
                    string.Join("", genClass.RelativeDotNetNamespace.Select(s => "." + s)).ToLowerInvariant(),
                DtoPackage = destDtoPackage +
                    string.Join("", genClass.RelativeDotNetNamespace.Select(s => "." + s)).ToLowerInvariant(),
                RelFactoryNamespace = string.Join("", genClass.RelativeDotNetNamespace.Select(s => "." + s + "()")).ToLowerInvariant(),
                Properties =
                    genClass.Properties.SelectMany(
                        p => p.GetGenerator(sourceNamespace).GenerateTModelProperties(sourceNamespace, genClass))
                        .Where(i => i != null)
                        .Distinct()
                        .ToList(),
                CustomCode = customCode,
                CustomImports = customImports,
                ConstructorCode =
                    genClass.Properties.SelectMany(
                        p => p.GetGenerator(sourceNamespace).GenerateTModelConstructorStatements(sourceNamespace, genClass, constructorParams))
                        .Where(i => i != null)
                        .Distinct()
                        .ToList(),
                FromDtoSetStmts =
                    genClass.Properties.SelectMany(
                        p => p.GetGenerator(sourceNamespace).GenerateTModelFromDtoStatements(sourceNamespace, genClass, fromDtoConstructorParams))
                        .Where(i => i != null)
                        .Distinct()
                        .ToList(),
                ToDtoSetStmts =
                    genClass.Properties.Where(p => p.CanWrite).SelectMany(
                        p => p.GetGenerator(sourceNamespace).GenerateTModelToDtoStatements(sourceNamespace, genClass))
                        .Where(i => i != null)
                        .Distinct()
                        .ToList(),
            };

            template.ConstructorParams = string.Join(",", constructorParams);
            template.FromDtoConstrArgs = string.Join(",", fromDtoConstructorParams);

            var javaClassContents = template.TransformText();
            using (var destStream = existingFile.OpenWrite())
            {
                destStream.SetLength(0);
                using (var writer = new StreamWriter(destStream))
                {
                    writer.Write(javaClassContents);
                }
            }




        }

        private static void CleanCustomCode(List<string> customCode)
        {
            while (customCode.Any() && string.IsNullOrWhiteSpace(customCode.First()))
            {
                customCode.RemoveAt(0);
            }


            while (customCode.Any() && string.IsNullOrWhiteSpace(customCode.Last()))
            {
                customCode.RemoveAt(customCode.Count - 1);
            }

            customCode.Insert(0, "");
            customCode.Add("");
        }


        internal static T GetOrDefault<T, TK>(this IDictionary<TK, T> src, TK key)
        {
            T val;
            return src.TryGetValue(key, out val) ? val : default(T);
        }

        private static IEnumerable<FileInfo> FindAllFiles(DirectoryInfo directory)
        {
            foreach (var file in directory.EnumerateFiles())
            {
                yield return file;
            }


            foreach (var f in directory.EnumerateDirectories().SelectMany(FindAllFiles))
            {
                yield return f;
            }
        }
    }
}
