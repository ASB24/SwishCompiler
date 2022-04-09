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

                    string[] right = line.Split('=')[1].Split(' ');
                    string[] left = line.Split('=')[0].Split(' ');

                    //Evaluar la expresion de la derecha
                    string evaluatedType = evaluateExpressionType(right);


                    //Chequear si variable existe
                    if (left.Length == 2)
                    {

                        string type = left[0];
                        string name = left[1];

                        if (SymbolTable.has(name))
                        {
                            Console.WriteLine("La variable " + name + " ya existe.");
                            return false;
                        }
                        else if (type != evaluatedType)
                        {
                            Console.WriteLine("Tipo de dato invalido");
                            return false;
                        }

                        SymbolTable.add(name, evaluatedType);

                    }
                    else if (left.Length == 1)
                    {

                        string name = left[1];
                        string type = SymbolTable.lookup(name);

                        if (!SymbolTable.has(name))
                        {
                            Console.WriteLine("La variable no ha sido declarada anteriormente");
                            return false;
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
                    type = getType(left);
                    if ( type == getType(right))
                    {
                        
                    }
                }
            }
            return type;
        }

        public static string getType(string word)
        {
            if( Int32.TryParse(word,out int a))
            {
                return "numerical";
            }else if( Char.TryParse(word, out char c))
            {
                return "char";
            }else if( word[0] == '"' && word[word.Length-1] == '"')
            {
                return "chararray";
            }
            return null;
        }




    }
}
