using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Tool.GenerateJava.GenerateModel;
using Tool.GenerateJava.GenerateModel.DatatypeGenerators;

namespace Tool.GenerateJava.GenerateWebApi
{
    static class WebApiGenerator
    {
        public static void GenGwt(string[] args)
        {
            var assemblyPath = args[1];
            var sourceNamespace = args[2];
            var destDirectory = args[3];
            var destPackage = args[4];
            var sourceModelNamespace = args[5];
            var destModelPackage = args[6];


//            System.Diagnostics.Debugger.Break();

            var classes = ReadClasses(assemblyPath, sourceNamespace, sourceModelNamespace)
                .ToList();

//            var paramClasses =
//                classes
//                    .SelectMany(c => c.Methods.Select(m => m.Parameter))
//                    .Where(c => c != null)
//                    .ToList();



            ModelGenerator.DeleteDirectory(destDirectory);

            classes.ForEach(c => GenerateClassFile(c, destDirectory, destPackage, sourceModelNamespace, destModelPackage));

            GenerateFactoryClass(destDirectory, destPackage, classes);
        }

        private static void GenerateFactoryClass(string destDirectory, string destPackage, List<GenWebClass> classes)
        {
            var factoryTemplate = new JavaFactoryTemplate
            {
                Package = destPackage,
                ClassNames = classes.Select(c => new ClassNamePair(ToJavaClassName(c.Name))).ToList()
            };


            var factoryContents = factoryTemplate.TransformText();
            ModelGenerator.WriteToFile(factoryContents,
                destDirectory,
                "RemoteFactory.java");
        }

        private static void GenerateClassFile(GenWebClass clas, string destDirectory, string destPackage, string sourceModelNamespace, string destModelPackage)
        {
            var implImports = new List<string>();
            var interfaceImports = new List<string>();
            var interfaceMethods = new List<string>();


            var package = destPackage + string.Join("", clas.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant();
            var className = ToJavaClassName(clas.Name);

            var classTemplate = new JavaClassTemplate
            {
                Package = package,
                ClassName = className,
                JavaMethods = clas.Methods
                    .Select(m => GenerateMethod(m, clas.Name, sourceModelNamespace, destModelPackage, implImports, interfaceMethods, interfaceImports))
                    .ToList()
            };

            classTemplate.Imports = implImports.Distinct().OrderBy(i => i).ToList();

            var classContents = classTemplate.TransformText();
            ModelGenerator.WriteToFile(classContents,
                destDirectory + string.Join("", clas.RelativeNamespace.Select(s => "\\" + s)).ToLowerInvariant(),
                string.Format("{0}.java", ToJavaClassName(clas.Name)));


            var interfaceTemplate = new JavaInterfaceTemplate
            {
                Package = package,
                ClassName = className,
                Imports = interfaceImports.Distinct().OrderBy(i => i).ToList(),
                JavaMethods = interfaceMethods
            };


            var interfaceContents = interfaceTemplate.TransformText();
            ModelGenerator.WriteToFile(interfaceContents,
                destDirectory + string.Join("", clas.RelativeNamespace.Select(s => "\\" + s)).ToLowerInvariant(),
                string.Format("I{0}.java", ToJavaClassName(clas.Name)));
        }

        private static string GenerateMethod(GenWebMethod method, string className, string sourceModelNamespace, string destModelPackage, List<string> imports, List<string> interfaceMethods, List<string> interfaceImports)
        {
            /*
             * 0 = method name
             * 1 = C# method name in quotes
             * 2 = parameter class name
             * 3 = return class name
             * 4 = converter method
             */

            imports.Add("tickbox.web.shared.util.RemoteService");
            imports.Add("com.google.gwt.http.client.Request");
            interfaceImports.Add("com.google.gwt.http.client.Request");

            const string voidReturnedNoParam = @"
    @Override
    public Request {0}(IRequestVoid req){{
	    return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(), req);
	}}";
            const string voidReturnedNoParamInterface = @"
    public Request {0}(IRequestVoid req);";
            const string voidReturnedObjectParam = @"
    @Override
	public Request {0}(I{2} params, IRequestVoid req){{
		return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(({2})params), req);
	}}";
            const string voidReturnedObjectParamInterface = @"
	public Request {0}(I{2} params, IRequestVoid req);";
            const string objectReturnedNoParam = @"
    @Override
	public Request {0}(final IRequest<I{3}> req){{
		return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(), new ReqConverter<I{3}>(req){{
			@Override
			public I{3} convert(String val){{
				return {3}.asObject(val);
			}}
		}});
	}}";
            const string objectReturnedNoParamInterface = @"
	public Request {0}(final IRequest<I{3}> req);";
            const string listReturnedNoParam = @"
    @Override
	public Request {0}(final IRequest<IJsArray<I{3}>> req){{
		return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(), new ReqConverter<IJsArray<I{3}>>(req){{
			@Override
			public IJsArray<I{3}> convert(String val){{
				return new JsArrayWrapper<{3}, I{3}>({3}.asArray(val));
			}}
		}});
	}}";
            const string listReturnedNoParamInterface = @"
	public Request {0}(final IRequest<IJsArray<I{3}>> req);";
            const string objectReturnedObjectParam = @"
    @Override
	public Request {0}(I{2} params, final IRequest<I{3}> req){{
		return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(({2})params), new ReqConverter<I{3}>(req){{
			@Override
			public I{3} convert(String val){{
				return {3}.asObject(val);
			}}
		}});
	}}";
            const string objectReturnedObjectParamInterface = @"
	public Request {0}(I{2} params, final IRequest<I{3}> req);";
            const string listReturnedObjectParam = @"
    @Override
	public Request {0}(I{2} params, final IRequest<IJsArray<I{3}>> req){{
		return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(({2})params), new ReqConverter<IJsArray<I{3}>>(req){{
			@Override
			public IJsArray<I{3}> convert(String val){{
				return new JsArrayWrapper<{3}, I{3}>({3}.asArray(val));
			}}
		}});
	}}";
            const string listReturnedObjectParamInterface = @"
	public Request {0}(I{2} params, final IRequest<IJsArray<I{3}>> req);";
            const string valueReturnedNoParam = @"
    @Override
	public Request {0}(final IRequest<{3}> req){{
		return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(), new ReqConverter<{3}>(req){{
			@Override
			public {3} convert(String val){{
				return {4}(val);
			}}
		}});
	}}";
            const string valueReturnedNoParamInterface = @"
	public Request {0}(final IRequest<{3}> req);";
            const string valueReturnedObjectParam = @"
    @Override
	public Request {0}(I{2} params, final IRequest<{3}> req){{
		return RemoteService.RemoteRequest(UrlPrefix + {1}, new JSONObject(({2})params), new ReqConverter<{3}>(req){{
			@Override
			public {3} convert(String val){{
				return {4}(val);
			}}
		}});
	}}";
            const string valueReturnedObjectParamInterface = @"
	public Request {0}(I{2} params, final IRequest<{3}> req);";

            string template;
            string interfaceTemplate;

//            var useGenericReturnName = false;
            string converterMethod = null;

            var genericInstanceReturnType = method.Return == null ? null : method.Return.DataType as GenericInstanceType;

            if (method.Return == null)
            {
                imports.Add("tickbox.web.shared.util.IRequestVoid");
                imports.Add("com.google.gwt.json.client.JSONObject");
                if (method.Parameter != null)
                {
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + "." + method.Parameter.Name);
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                    interfaceImports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                }
                interfaceImports.Add("tickbox.web.shared.util.IRequestVoid");
                template = method.Parameter == null ? voidReturnedNoParam : voidReturnedObjectParam;
                interfaceTemplate = method.Parameter == null ? voidReturnedNoParamInterface : voidReturnedObjectParamInterface;
            }
            else if (genericInstanceReturnType != null &&
                ((genericInstanceReturnType.Name == "IEnumerable`1"
                      && genericInstanceReturnType.GenericArguments.Count == 1
                      &&
                      (genericInstanceReturnType.GenericArguments[0].Namespace ?? "").StartsWith(sourceModelNamespace)
                      && !genericInstanceReturnType.GenericArguments[0].IsValueType)
                     || (genericInstanceReturnType.Name == "List`1"
                         && genericInstanceReturnType.Namespace == "System.Collections.Generic"
                         && genericInstanceReturnType.GenericArguments.Count == 1
                         &&
                         (genericInstanceReturnType.GenericArguments[0].Namespace ?? "").StartsWith(
                             sourceModelNamespace)
                         && !genericInstanceReturnType.GenericArguments[0].IsValueType)))
            {

                imports.Add("tickbox.web.shared.util.IRequest");
                imports.Add("tickbox.web.shared.util.IJsArray");
                imports.Add("tickbox.web.shared.util.JsArrayWrapper");
                imports.Add("tickbox.web.shared.util.ReqConverter");
                imports.Add("com.google.gwt.json.client.JSONObject");
                imports.Add(destModelPackage + string.Join("", method.Return.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + "." + method.Return.Name);
                imports.Add(destModelPackage + string.Join("", method.Return.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Return.Name);
                if (method.Parameter != null)
                {
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + "." + method.Parameter.Name);
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                    interfaceImports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                }

                interfaceImports.Add("tickbox.web.shared.util.IRequest");
                interfaceImports.Add("tickbox.web.shared.util.IJsArray");
                interfaceImports.Add(destModelPackage + string.Join("", method.Return.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Return.Name);


                template = method.Parameter == null ? listReturnedNoParam : listReturnedObjectParam;
                interfaceTemplate = method.Parameter == null ? listReturnedNoParamInterface : listReturnedObjectParamInterface;
                //                useGenericReturnName = true;
            }
            else if (method.Return.RelativeNamespace == null)
            {
                // these are primitive JSON return types like int/string/DateTime, etc
                imports.Add("tickbox.web.shared.util.IRequest");
                imports.Add("tickbox.web.shared.util.ReqConverter");
                imports.Add("com.google.gwt.json.client.JSONObject"); 
                if (method.Parameter != null)
                {
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + "." + method.Parameter.Name);
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                    interfaceImports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                }

                if (method.Return.DataType.FullName == "System.String")
                {
                    imports.Add("tickbox.web.shared.util.DString");
                    converterMethod = "DString.toString";
                }
                else if (method.Return.DataType.FullName == "System.Boolean")
                {
                    imports.Add("tickbox.web.shared.util.DBoolean");
                    converterMethod = "DBoolean.toBoolean";
                }
                interfaceImports.Add("tickbox.web.shared.util.IRequest");

                template = method.Parameter == null ? valueReturnedNoParam : valueReturnedObjectParam;
                interfaceTemplate = method.Parameter == null ? valueReturnedNoParamInterface : valueReturnedObjectParamInterface;
            }
            else
            {
                imports.Add("tickbox.web.shared.util.IRequest");
                imports.Add("tickbox.web.shared.util.ReqConverter");
                imports.Add("com.google.gwt.json.client.JSONObject");
                imports.Add(destModelPackage + string.Join("", method.Return.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + "." + method.Return.Name);
                imports.Add(destModelPackage + string.Join("", method.Return.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Return.Name);
                if (method.Parameter != null)
                {
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + "." + method.Parameter.Name);
                    imports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                    interfaceImports.Add(destModelPackage + string.Join("", method.Parameter.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Parameter.Name);
                }
                interfaceImports.Add("tickbox.web.shared.util.IRequest");
                interfaceImports.Add(destModelPackage + string.Join("", method.Return.RelativeNamespace.Select(s => "." + s)).ToLowerInvariant() + ".I" + method.Return.Name);

                template = method.Parameter == null ? objectReturnedNoParam : objectReturnedObjectParam;
                interfaceTemplate = method.Parameter == null ? objectReturnedNoParamInterface : objectReturnedObjectParamInterface;
            }

            interfaceMethods.Add(string.Format(interfaceTemplate,
                ToJavaMethodName(method.Name),
                string.Format("\"{0}\"", method.Name),
                method.Parameter == null ? null : method.Parameter.Name,
                method.Return == null ? null : method.Return.Name,
                converterMethod));

            return string.Format(template, 
                ToJavaMethodName(method.Name), 
                string.Format("\"{0}\"", method.Name),
                method.Parameter == null ? null : method.Parameter.Name,
                method.Return == null ? null : method.Return.Name,
                converterMethod);
        }

        private static string ToJavaMethodName(string name)
        {
            return name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
        }

        private static string ToJavaClassName(string className)
        {
            if (className.EndsWith("Controller"))
            {
                className = className.Substring(0, className.Length - "Controller".Length);
            }
            return className;
        }


        private static IEnumerable<TypeDefinition> GetTypes(string fileName)
        {
            var module = ModuleDefinition.ReadModule(fileName);
            return module.Types.Where(type => type.IsPublic);
        }

        private static IEnumerable<GenWebClass> ReadClasses(string assemblyPath, string sourceNamespace, string sourceModelNamespace)
        {
            //var types = GetTypes(assemblyPath);

            //            var test = (from t in assemb.GetTypes()
            //                where (t.Namespace ?? "").StartsWith(sourceNamespace)
            //                      && t.Name.StartsWith("<")
            //                select t)
            //                .ToList();


            return from t in GetTypes(assemblyPath)
                where (t.Namespace ?? "").StartsWith(sourceNamespace)
                      && !t.IsNested
                      && t.IsClass
                      && t.GetMethods().Any(m => m.CustomAttributes.Any(a => a.AttributeType.FullName == "System.Web.Http.HttpPostAttribute")
                                                 && m.Parameters.Count <= 1)
                      && t.BaseType.FullName == "System.Web.Http.ApiController"
                select new GenWebClass
                {
                    Name = t.Name,
                    Methods = t.GetMethods().Where(m => m.CustomAttributes.Any(a => a.AttributeType.FullName == "System.Web.Http.HttpPostAttribute")
                                                 && m.Parameters.Count <= 1)
                        .Select(m => new GenWebMethod
                        {
                            Name = m.Name,
                            Parameter = m.Parameters
                                .Select(c =>
                                    c.ParameterType is GenericInstanceType
                                    ? new WebGenParam
                                    {
                                        Name = (c.ParameterType as GenericInstanceType).GenericArguments.First().Name,
                                        RelativeNamespace = DtGenUtil.CalculateRelativeNamespace((c.ParameterType as GenericInstanceType).GenericArguments.First().Namespace, sourceModelNamespace)
                                            .ToList(),
                                        DataType = c.ParameterType
                                    }
                                    : new WebGenParam
                                {
                                    Name = c.ParameterType.Name,
                                    RelativeNamespace = DtGenUtil.CalculateRelativeNamespace(c.ParameterType.Namespace, sourceModelNamespace)
                                        .ToList(),
                                    DataType = c.ParameterType
                                })
                                .SingleOrDefault(),
                            Return = CalculateReturnType(sourceModelNamespace, m.MethodReturnType == null ? null : m.MethodReturnType.ReturnType)
                                
                        })
                        .ToList(),
                    RelativeNamespace = DtGenUtil.CalculateRelativeNamespace(t.Namespace, sourceNamespace)
                        .ToList()
                };
        }

        private static WebGenParam CalculateReturnType(string sourceModelNamespace, TypeReference returnType)
        {
            return returnType == null || returnType.FullName == "System.Void" || returnType.FullName == "System.Threading.Tasks.Task" 
                ? null
                : returnType.Namespace == "System" //|| returnType.Namespace.StartsWith("System.")
                    ? new WebGenParam
                    {
                        Name = returnType.Name,
                        RelativeNamespace = null,
                        DataType = returnType
                    }
                    : returnType.Name == "Task`1" && returnType is GenericInstanceType
                        ? CalculateReturnType(sourceModelNamespace, (returnType as GenericInstanceType).GenericArguments.First()) 
                        : (returnType.Name == "List`1" || returnType.Name == "IEnumerable`1") && returnType is GenericInstanceType
                        ? new WebGenParam
                        {
                            Name = (returnType as GenericInstanceType).GenericArguments.First().Name,
                            RelativeNamespace = DtGenUtil.CalculateRelativeNamespace((returnType as GenericInstanceType).GenericArguments.First().Namespace, sourceModelNamespace)
                                .ToList(),
                            DataType = returnType
                        }
                        : new WebGenParam
                    {
                        Name = returnType.Name,
                        RelativeNamespace = DtGenUtil.CalculateRelativeNamespace(returnType.Namespace, sourceModelNamespace)
                            .ToList(),
                        DataType = returnType
                    };
        }
    }
}
