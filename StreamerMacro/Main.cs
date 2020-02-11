using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamerMacro
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            var func = new Macro.Function("Sound up", new (string key, Keyboard.Key.Status status)[] 
            {
                ("A", Keyboard.Key.Status.PRESSING),
                ("B", Keyboard.Key.Status.DOWN),
            }, () => 
            {
               
            });

            Program.App.Add(func);
        }
    }
}
