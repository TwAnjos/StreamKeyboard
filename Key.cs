using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerMacroPRO.Class.Keyboard
{
    //Represents a key in keyboard
    public class Key
    {
        //Types of key pressing status
        public enum Status 
        {
            PRESSING,
            DOWN,
            UP,
            NOTHING
        }

        //Name of key
        private readonly string Name;

        //Hex address in keyboard
        private readonly int Address;

        //Is pressing
        private bool Press;

        //Key press type
        private Status _Status;

        //Getter Name
        public string GetName() 
        {
            return this.Name;
        }

        //Getter address
        public int GetAddress() 
        {
            return this.Address;
        }

        //Getter _Status
        public Status GetStatus() 
        {
            return this._Status;
        }

        //Update key status
        public void UpdateKeyStatus(int readValue) 
        {
            var status = readValue == -127 || readValue == -128;

            if (status)
            {
                if (!this.Press)
                    this._Status = Status.DOWN;
                else
                    this._Status = Status.PRESSING;
            }
            else 
            {
                if (this.Press)
                    this._Status = Status.UP;
                else
                    this._Status = Status.NOTHING;
            }
        }

        //Set keyboardReaded value of this key
        public void UpdateKeyPress(int readValue) 
        {
            this.Press = readValue == -127 || readValue == -128;
        }

        //Constructor
        public Key(string name, int address) 
        {
            if (name == null)
                throw new Exception("name or address of a key is null!");

            this.Name = name;
            this.Address = address;
            this._Status = Status.NOTHING;
        }
    }
}
