using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macro
{
    //Functions macro administrator
    public class Macro
    {
        //Functions activated by keys
        private List<Function> functions;

        //getter functions
        public Function[] GetFunctions() 
        {
            return this.functions.ToArray();
        }

        //Verific if function exist
        private bool FunctionExist(string name) 
        {
            return (functions.Any(i => i.GetName() == name));
        }

        //Add a new function if this dont exist
        public bool Add(Function newFunction) 
        {
            if (FunctionExist(newFunction.GetName()))
                return false;
            
            functions.Add(newFunction);

            return true;
        }

        //Remove a function
        public bool Remove(string name) 
        {
            if (!FunctionExist(name))
                return false;
           
            functions.Remove(functions.First(i => i.GetName() == name));

            return true;
        }

        //Enter in loop of all functions
        private void Run() 
        {
            Keyboard.Keyboard interceptClass = new Keyboard.Keyboard((keys) => 
            {
                foreach (var item in functions)
                    item.Check(keys);
            });
        }

        public Macro() 
        {
            this.functions = new List<Function>();
            Run();
        }
    }
}