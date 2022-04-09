using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    class Program
    {
        static void Main(string[] args)
        {

            List<HashSet<string>> lines = new List<HashSet<string>>();
            string line = " ";

            HashSet<string> temp = new HashSet<string>();

            while (true)
            {
                line = Console.ReadLine();

                if (line != null || line == "EOF") break;

                foreach(string variable in line.Split(' '))
                {
                    temp.Add(variable);
                }
                lines.Add(temp);
                temp.Clear();
            }
        }
    }
}
