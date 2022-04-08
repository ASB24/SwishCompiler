using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    static class SymbolTable
    {
        
        private static List<string> symbols = new List<string>() { "numerical", "chararray", "char", "floating"};
        
        /// <summary>
        /// Adds a rule to the symbol table.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns>Returns true if the symbol was added, otherwise false.</returns>
        public static bool add(string rule)
        {
            if (!symbols.Contains(rule))
            {
                symbols.Add(rule);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the rule from the symbol table.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if the symbol was successfully removed, otherwise false.</returns>
        public static bool remove(string key)
        {
            return symbols.Remove(key);
        }

        /// <summary>
        /// Returns a string showing the requested rule.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns a string of the found rule, otherwise it return null.</returns>
        public static string get(string key)
        {
            if(symbols.Contains(key))
                return symbols[symbols.IndexOf(key)];
            else return null;
        }

        /// <summary>
        /// Shows if the rules exists in the symbol table
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if the rule exists, otherwise false.</returns>
        public static bool has(string key)
        {
            return symbols.Contains(key);
        }
    }
}
