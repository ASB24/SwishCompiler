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

            List<string> lines = new List<string>();
            string line = " ";

            while (true)
            {
                line = Console.ReadLine();

                if (line == "EOF") break;
                else if (line == "") continue;

                lines.Add(line);
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

            if(!SynctaticAnalyzer.validSyntax(lines))
            {
                Console.WriteLine("Se encontraron errores de sintx porfavor verifique e intentelo nuevamente");
                return;

            }
            if(!SemanticAnalyzer.validSemantics(lines))
            {
                Console.WriteLine("Se encontraron errores semanticos porfavor verifique e intentelo nuevamente");
                return;
            }
            Console.WriteLine("El asunto ta bien");
            Console.ReadKey();
        }
    }
}
