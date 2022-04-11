using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SwishCompiler
{
    public static class LexicAnalyzer
    {
        public static bool CreateTokens(List<string> lines) 
        {
            string[] line;
            foreach (string linea in lines) {
                line = linea.Split(' ');
                foreach (string simbolo in line) {
                    if (!SymbolTable.has(simbolo))
                    {
                        if (SymbolTable.isOperator(simbolo))
                        {
                            SymbolTable.add(simbolo, "Operator");
                        }
                        else if (SymbolTable.isReserved(simbolo))
                        {
                            SymbolTable.add(simbolo, "palabra reservada");
                        }
                        else
                        {
                            SymbolTable.add(simbolo, SymbolTable.getType(simbolo));
                        }
                    }
                }
            }
            SymbolTable.printsymbols();
            return true;
        }
    }
}
