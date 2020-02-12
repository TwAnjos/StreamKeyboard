using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Keyboard
{
    //Read keyboard keys
    public class Keyboard
    {
        //Keyboard update keys status time in ms
        private int UpdateTime = 50;

        //Keys of a keyboard instance
        private List<Key> Keys;

        //This function run when keyboard read all keys status
        private readonly Action<Key[]> InternalHook;

        //Getter UpdateTime
        public int GetUpateTime()
        {
            return this.UpdateTime;
        }

        //Setter UpdateTime
        public void SetUpdateTime(int value)
        {
            if (value < 0)
                throw new Exception("Update time is less than zero!");

            this.UpdateTime = value;
        }

        //Getter keys
        public Key[] GetKeys()
        {
            return this.Keys.ToArray();
        }

        //Get only keys with not pressed/down/up status
        public Key[] GetPressedKeys() 
        {
            return Keys.Where(k => k.GetStatus() != Key.Status.NOTHING).ToArray();
        }

        //Insert keys values
        private void InitKeys()
        {
            this.Keys = new List<Key>();
            var names = Enum.GetNames(typeof(System.Windows.Forms.Keys));
            var values = Enum.GetValues(typeof(System.Windows.Forms.Keys)).Cast<int>().ToList();

            for (int i = 0; i < names.Length; i++)
                this.Keys.Add(new Key(names[i], values[i]));
        }

        //Create and run a thread to update keys status
        private void InitThread()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(UpdateTime);

                    foreach (var key in Keys)
                        key.UpdateKeyStatus(Native.WindowsImports.GetKeyState(key.GetAddress()));

                    InternalHook(GetKeys());

                    foreach (var key in Keys)
                        key.UpdateKeyPress();
                }
            });
        }

        public Keyboard(Action<Key[]> internalHook)
        {
            if (internalHook == null)
                throw new Exception("Keyboard hook function is null!");

            this.InternalHook = internalHook;
            InitKeys();
            InitThread();
        }
    }
}