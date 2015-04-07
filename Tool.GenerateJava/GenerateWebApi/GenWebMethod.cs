using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.GenerateJava.GenerateModel;

namespace Tool.GenerateJava.GenerateWebApi
{
    class GenWebMethod
    {
        public string Name { get; set; }
        public WebGenParam Parameter { get; set; }
        public WebGenParam Return { get; set; }
    }
}
