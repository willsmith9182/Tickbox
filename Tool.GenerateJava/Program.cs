using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Tool.GenerateJava.GenerateModel;
using Tool.GenerateJava.GenerateWebApi;

namespace Tool.GenerateJava
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                args = args.Length > 0
                    ? args
                    : new[]
                    {
                        "-GenModel",
                        @"D:\Lat Projects\WL_Main\Latitude.WhiteLabel.Models\bin\Release\Latitude.WhiteLabel.Models.dll",
                        "Latitude.WhiteLabel.Models",
                        @"D:\Lat Projects\WL_Main\Latitude.WhiteLabel.Models\obj\Debug\Temp",
                        "tickbox.web.shared.dto",
                        @"D:\Lat Projects\WL_Main\Latitude.WhiteLabel.Models\obj\Debug\TessellTemp",
                        "latitude.gwt.tessellshared.tmodel",
                    };
//                    : new[]
//                    {
//                        "-GenWebApi",
//                        @"D:\Lat Projects\WL_SEO4SME\Latitude.SeoPortal.Ui\war\bin\Latitude.SeoPortal.Ui.dll",
//                        "Latitude.SeoPortal.Ui.Controllers",
//                        @"D:\Lat Projects\WL_SEO4SME\\latitude.seoportal.ui\src\latitude\seoportal\ui\client\remotelogic",
//                        "latitude.seoportal.ui.client.remotelogic",
//                        "Latitude.WhiteLabel.Models",
//                        "tickbox.web.shared.dto"
//                    };


                if (args[0] == "-GenModel")
                {
                    ModelGenerator.GenModel(args);
                }
                else if (args[0] == "-GenWebApi")
                {
                    WebApiGenerator.GenGwt(args);
                }
                else
                {
                    throw new Exception("Unknown generation type: " + args[0]);
                }
            }
            catch (ReflectionTypeLoadException rtle)
            {
                Console.WriteLine(rtle.Message);
                foreach (var e in rtle.LoaderExceptions)
                {
                    Console.WriteLine(e.Message);
                }
                //Console.ReadLine();
                throw;
            }
            catch (Exception e)
            {
//                Debugger.Break();
                Console.WriteLine(e.Message);
                //Console.ReadLine();
                throw;
            }
        }

    }
}
