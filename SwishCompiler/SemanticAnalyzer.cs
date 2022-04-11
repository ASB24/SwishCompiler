using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    public static class SemanticAnalyzer
    {
        public static bool validSemantics(List<string> lines)
        {
            int contador = 1;
            Dictionary<string, int> cuentas = new Dictionary<string, int>();
                foreach (string line in lines)
                {
                    string[] right = line.Split('=')[1].Trim().Split(' ');
                    string[] left = line.Split('=')[0].Trim().Split(' ');


                //Evaluar la expresion de la derecha

                    //Chequear si variable existe
                    if (left.Length == 2)
                    {
                        Console.WriteLine("Definicion de variable en la linea: "+ contador);
                        contador++;   
                        string evalType = SymbolTable.getType(right[0]);
                        string type = left[0];
                        string name = left[1];
                        if ( SymbolTable.has(name) && SymbolTable.lookup(name) != "operator" && SymbolTable.lookup(name) != "reserved" && cuentas.ContainsKey(name) )
                        {
                            if(cuentas[name] == 1) Console.WriteLine("La variable " + name + " ya existe.");
                            return false;
                        }
                        else if (type != evalType)
                        {
                            Console.WriteLine("Tipo de dato invalido");
                            return false;
                        }
                        else
                        {
                            cuentas[name] = 1;
                        }

                    }
                    //Chequear una operacion
                    else if (left.Length == 1)
                    {
                    Console.WriteLine("Operacion en la linea: " + contador);
                    contador++;
                    if (right.Length > 1)
                        {
                        
                        string name = left[0];
                        string rightStart = right[0];
                        string rightFinish = right[right.Length-1];




                            if (!SymbolTable.has(name))
                            {
                                Console.WriteLine("La variable '"+ name +"' no ha sido declarada anteriormente");
                                return false;
                            }
                            else if(!SymbolTable.has(rightStart))
                            {
                                Console.WriteLine("La variable '"+rightStart + "' no ha sido declarada anteriormente");
                                return false;
                            }
                            else if(!SymbolTable.has(rightFinish))
                            {
                                Console.WriteLine("La variable '"+rightFinish + "' no ha sido declarada anteriormente");
                                return false;
                            }
                        }


                    }
            }
            return true;
        }
    }
}
