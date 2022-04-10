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
                foreach (string line in lines)
                {

                    string[] right = line.Split('=')[1].Trim().Split(' ');
                    string[] left = line.Split('=')[0].Trim().Split(' ');




                //Evaluar la expresion de la derecha

                    //Chequear si variable existe
                    if (left.Length == 2)
                    {
                        string evalType = getType(right[0]);
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
                        if(right.Length > 1)
                        {
                        
                        string name = left[0];
                        string rightStart = right[0];
                        string rightFinish = right[right.Length-1];




                            if (!SymbolTable.has(name))
                            {
                                Console.WriteLine("La variable "+ name +" no ha sido declarada anteriormente");
                                return false;
                            }
                            else if(!SymbolTable.has(rightStart))
                            {
                                Console.WriteLine("La variable "+rightStart + " no ha sido declarada anteriormente");
                                return false;
                            }
                            else if(!SymbolTable.has(rightFinish))
                            {
                                Console.WriteLine("La variable "+rightFinish + " no ha sido declarada anteriormente");
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

                    if ( getType(left) == getType(right))
                    {
                        type = getType(left);
                    }
                }
            }
            return type;
        }

        public static string getType(string word)
        {
                if (Int32.TryParse(word, out int a))
                {
                    return "numerical";
                }
                else if (Char.TryParse(word, out char c))
                {
                    return "char";
                }
                else if (word[0] == '"' && word[word.Length - 1] == '"')
                {
                    return "chararray";
                }
                else
                {
                    return null;
                }
        }
    }
}
