using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    internal class Rule
    {
        public string type;
        public string name;
        public string value;

        public Rule(string name, string type, string value)
        {
            this.name = name;
            this.type = type;
            this.value = value;
        }
    }
}
