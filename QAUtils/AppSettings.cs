using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAUtils
{
    public class AppSettings
    {
        public string Url { get; set; }
        public Test Test { get; set; }
    }

    public class Test
    {
        public Key1 Key1 { get; set; }

    }

    public class Key1
    {
        public string NestedKey { get; set; }

    }
}
