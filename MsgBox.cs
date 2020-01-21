using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class MsgBox
    {
        public static void Show(string title, string text) 
        {
            new MsgBox(title, text);
        }

        public MsgBox(string title, string text) 
        {
            System.Windows.Forms.MessageBox.Show(text, title, System.Windows.Forms.MessageBoxButtons.OK);
        }
    }
}
