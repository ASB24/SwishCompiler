using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    public static class SynctaticAnalyzer
    {

        /// <summary>
        /// Checks for syntax errores in a single sentence
        /// </summary>
        /// <param name="declarations"></param>
        /// <returns>Returns true if the sentence has a valid syntax, otherwise false.</returns>
        public static bool validSyntax(string declarations)
        {
            string[] sentencias = declarations.Split(' ');
            if(SymbolTable.get(sentencias[0]) != null)
            {
                return true;
            }
            return false;
        }
    }
}
