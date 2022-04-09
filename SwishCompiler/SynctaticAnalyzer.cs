using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    public static class SynctaticAnalyzer
    {
        public static bool validSyntax(List<string[]> lines)
        {
            foreach(string[] line in lines)
            {
                for(int i = 0; i < line.Length-1; i++)
                {
                    try
                    {
                        if (line[i].Length > 1 && SymbolTable.existsReserved(line[i]))
                        {
                            Console.WriteLine("Un espacio por palabra/operador, " + line[i]);
                            return false;
                        }
                        else if (SymbolTable.isReserved(line[i]) && i != 0 && line[2] != "=")
                        {
                            Console.WriteLine("Mal asignacion en linea " + (i+1).ToString());
                            return false;
                        }else if (i == 0)
                        {
                            continue;
                        }
                        else if (line[i] == "=" && (!SymbolTable.isVariable(line[i - 1]) || !SymbolTable.isVariable(line[i + 1])))
                        {
                            Console.WriteLine("Ta usando el igual mal en " + (i + 1).ToString());
                            return false;
                        }
                        else if (SymbolTable.isOperator(line[i]) && (!SymbolTable.isVariable(line[i - 1]) || !SymbolTable.isVariable(line[i + 1])))
                        {
                            Console.WriteLine("Nota operando el asunto " + line[i]);
                            return false;
                        }
                        else if (
                                SymbolTable.isVariable(line[i]) &&
                                ( !SymbolTable.isOperator(line[i - 1]) && !SymbolTable.isOperator(line[i + 1]) ) &&
                                ( line[i-1] != "=" && line[i + 1] != "=" ) &&
                                !SymbolTable.isReserved(line[i - 1])
                            )
                        {
                            Console.WriteLine("No se ta operando en la variable " + line[i]);
                            return false;
                        }
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Te saliste de lo lao");
                        return false;
                    }
                    
                }
            }
            return true;
        }
    }
}
