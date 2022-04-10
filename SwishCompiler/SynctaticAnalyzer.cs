using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    public static class SynctaticAnalyzer
    {
        public static bool validSyntax(List<string> lines)
        {
            string[] line;
            int lineNum;

            foreach(string linea in lines)
            {
                line = linea.Split(' ');
                for(int i = 0; i < line.Length-1; i++)
                {
                    try
                    {
                        lineNum = lines.IndexOf(linea);
                        if (SymbolTable.isReserved(line[i]) && i != 0 && line[2] != "=")
                        {
                            Console.WriteLine("Mal asignacion en palabra " + line[i] + " en la linea " + lineNum);
                            return false;
                        }
                        else if (i == 0)
                        {
                            continue;
                        }
                        else if (line[i] == "=" && (!SymbolTable.isVariable(line[i - 1]) || !SymbolTable.isVariable(line[i + 1])))
                        {
                            Console.WriteLine("Ta usando el igual mal en linea " + lineNum);
                            return false;
                        }
                        else if (SymbolTable.isOperator(line[i]) && (!SymbolTable.isVariable(line[i - 1]) || !SymbolTable.isVariable(line[i + 1])))
                        {
                            Console.WriteLine("Nota operando el asunto " + line[i] + " en la linea " + lineNum);
                            return false;
                        }
                        else if (
                                SymbolTable.isVariable(line[i]) &&
                                ( !SymbolTable.isOperator(line[i - 1]) && !SymbolTable.isOperator(line[i + 1]) ) &&
                                ( line[i-1] != "=" && line[i + 1] != "=" ) &&
                                !SymbolTable.isReserved(line[i - 1])
                            )
                        {
                            Console.WriteLine("No se ta operando en la variable " + line[i] + " en la linea " + lineNum);
                            return false;
                        }

                        foreach(char c in line[i])
                        {
                            if (SymbolTable.isOperator(c.ToString()) || c == '=')
                            {
                                Console.WriteLine("Los operadores y el igual deben estar separados de las variables, en la linea " + lineNum);
                                return false;
                            }
                        }
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Hubo un error de indice");
                        return false;
                    }
                    
                }
            }
            return true;
        }
    }
}
