using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Keyboard;

namespace Macro
{
    //Function to apply in key
    public class Function
    {
        //Name of function
        private readonly string Name;

        //This function run when all activations keys is pressing,down or up..
        private readonly Action Runnable;

        //If all item1 == item2 in this list, Runnable is execute
        private (string keyName, Key.Status status)[] ActivationKeys;

        //Check activation keys for run this functions
        public void Check(Key[] keys)
        {
            bool run = true;

            foreach (var tuple in ActivationKeys)
            {
                var inKeyboard = keys.FirstOrDefault(i => i.GetName() == tuple.keyName);

                if (inKeyboard != null)
                {
                    if (inKeyboard.GetStatus() != tuple.status)
                        run = false;
                }
                else
                    run = false;
            }

            if (run)
                Run();
        }

        //Getter Name
        public string GetName()
        {
            return this.Name;
        }

        //Run function
        private void Run()
        {
            try
            {
                Runnable();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error mensage: " + e.Message, "Program key function result in error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Constructor
        public Function(string name, (string key, Key.Status status)[] activationKeys, Action runnable)
        {
            if (name == null || runnable == null)
                throw new Exception("Function creation, name or runnable is null!");

            this.Name = name;
            this.Runnable = runnable;
            this.ActivationKeys = activationKeys;
        }
    }
}