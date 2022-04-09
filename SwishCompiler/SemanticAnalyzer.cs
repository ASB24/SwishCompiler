using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    public static class SemanticAnalyzer
    {
        public static bool validSemantics(List<string[]> lines)
        {
            try
            {
                string[] expression;
                foreach (string[] line in lines)
                {
                    int index = Array.IndexOf(line,"=");
                    expression =  new string[line.Length-index];
                    Array.Copy(line,index+1,expression,0,expression.Length);
                    for(int j = 0; j< expression.Length;j++)
                    {
                        Console.WriteLine(expression[j]);
                    }
                    return true;
                    for (int i = 0; i < line.Length - 1; i++)
                    {



                        return false;







                        //if (SymbolTable.isReserved(line[0]))
                        //{
                        //   //Significa que es una declaracion de variable
                        //   if(!SymbolTable.has(line[1]))
                        //    {
                        //        try
                        //        {


                        //        }catch 
                        //    }



                        //}













                    }



            }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }






    }
}
