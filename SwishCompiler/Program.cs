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

            List<string[]> lines = new List<string[]>();
            string line = " ";

            while (true)
            {
                line = Console.ReadLine();

                if (line == "EOF") break;
                else if (line == "") continue;

                lines.Add(line.Split(' '));
            }

            /*
            for(int i = 0; i < lines.Count; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    Console.WriteLine(lines[i][j]);
                }
            }
            */

            Console.WriteLine(SynctaticAnalyzer.validSyntax(lines));
            Console.ReadKey();
        }
    }
}
