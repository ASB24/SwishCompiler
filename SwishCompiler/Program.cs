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

            if (!SynctaticAnalyzer.validSyntax(lines))
            {
                Console.WriteLine("Se encontraron errores sintacticos porfavor verifique e intentelo nuevamente");
                Console.ReadKey();
                return;
            }
            if (!LexicAnalyzer.CreateTokens(lines))
            {
                Console.WriteLine("Se encontraron errores lexicos porfavor verifique e intentelo nuevamente");
                Console.ReadKey();
                return;
            }
            if (!SemanticAnalyzer.validSemantics(lines))
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
