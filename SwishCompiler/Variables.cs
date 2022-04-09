using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwishCompiler
{
    public class Variables
    {
        private List<Variable> variables = new List<Variable>();
        private int scope;

        public Variables()
        {
            scope = 0;
            variables = new List<Variable>();
        }


        



        public void increaseScope(){ scope++; }

        public void decreaseScope() { scope--; }

        public int getScope(){ return scope; }

        public void AddVariable(string name, string value){
            variables.Add( new Variable(name, value, scope) );
        }
    }
}
