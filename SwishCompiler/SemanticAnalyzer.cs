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
            int contador = 0;
                foreach (string line in lines)
                {
                    string[] right = line.Split('=')[1].Trim().Split(' ');
                    string[] left = line.Split('=')[0].Trim().Split(' ');


                //Evaluar la expresion de la derecha

                    //Chequear si variable existe
                    if (left.Length == 2)
                    {
                        contador++;   
                        Console.WriteLine("Declaracion de variable en la linea "+contador);
                        string evalType = SymbolTable.getType(right[0]);
                        string type = left[0];
                        string name = left[1];
                        if (SymbolTable.has(name))
                        {
                            Console.WriteLine("La variable " + name + " ya existe.");
                            return false;
                        }
                        else if (type != evalType)
                        {
                            Console.WriteLine("Tipo de dato invalido");
                            return false;
                        }
                        else
                        {
                        SymbolTable.add(name, evalType);
                        }

                    }
                    //Chequear una operacion
                    else if (left.Length == 1)
                    {
                    contador++;
                    Console.WriteLine("Operacion matematica en la linea " + contador);
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

        public static string evaluateExpressionType(string[] expression)
        {
            int i;
            string left;
            string right;

            string type = "";

            foreach(string word in expression)
            {
                if (SymbolTable.isOperator(word))
                {
                    //Saca el valor de la derecha e izquierda de operador
                    i = Array.IndexOf(expression, word);
                    left = expression[i - 1];
                    right = expression[i + 1];
                    
                    //Saca valor de variable
                    if (SymbolTable.has(left))
                    {
                        left = SymbolTable.lookup(left);
                    }
                    if (SymbolTable.has(right))
                    {
                        left = SymbolTable.lookup(right);
                    }

                    //Revisa si son del mismo tipo

                    if (SymbolTable.getType(left) == SymbolTable.getType(right))
                    {
                        type = SymbolTable.getType(left);
                    }
                }
            }
            return type;
        }
    }
}
