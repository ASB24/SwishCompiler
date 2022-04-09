using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    static class SymbolTable
    {

        private static string[] reserved = { "numerical", "chararray", "char", "floating" };
        private static string[] operators = { "+", "-", "<", ">"};
        private static Dictionary<string, string> symbols = new Dictionary<string, string>();
        
        /// <summary>
        /// Adds a rule to the symbol table.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns>Returns true if the symbol was added, otherwise false.</returns>
        public static bool add(string symbol, string value)
        {
            if (!symbols.ContainsKey(symbol))
            {
                symbols.Add(symbol, value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the rule from the symbol table.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>True if the symbol was successfully removed, otherwise false.</returns>
        /// 
        public static bool remove(string key)
        {
            return symbols.Remove(key);
        }

        /// <summary>
        /// Returns a string showing the requested rule.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns a string of the found rule, otherwise it return null.</returns>
        public static string lookup(string key)
        {
            if (symbols.ContainsKey(key))
            {
                return symbols[key];
            }
            return null;
        }

        /// <summary>
        /// Updates the value of the indicated symbol in the symbol table.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void update(string key, string value)
        {
            symbols[key] = value;
        }

        /// <summary>
        /// Shows if the rules exists in the symbol table
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if the rule exists, otherwise false.</returns>
        public static bool has(string key)
        {
            return symbols.ContainsKey(key);
        }

        /// <summary>
        /// Returns whether the word is a reserved keyword or not.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool isReserved(string word)
        {
            return reserved.Contains(word);
        }

        /// <summary>
        /// Returns whether the word is in the list of reserved keywords
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool existsReserved(string word)
        {
            for(int i = 0; i < reserved.Length; i++)
            {
                if (isOperator(word[i].ToString())) return true;
            }
            return false;
        }

        /// <summary>
        /// Returns whether the word is an operator or not.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool isOperator(string word)
        {
            return operators.Contains(word) || word == "=";
        }

        public static bool isVariable(string word)
        {
            return !isReserved(word) && !isOperator(word);
        }
    }
}
