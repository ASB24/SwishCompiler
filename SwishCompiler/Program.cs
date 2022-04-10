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
                Console.WriteLine("Se encontraron errores de sintax porfavor verifique e intentelo nuevamente");
                Console.ReadKey();
                return;

            }
            else if(!SemanticAnalyzer.validSemantics(lines))
            {
                Console.WriteLine("Se encontraron errores semanticos porfavor verifique e intentelo nuevamente");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("No se detectaron errores, el programa ha terminado con exito");
                Console.ReadKey();
            }

        }
    }
}
