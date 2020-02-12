using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Native;

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
                ("NumPad0", Keyboard.Key.Status.PRESSING),
                ("NumPad1", Keyboard.Key.Status.DOWN),
            }, () =>
            {
                Windows.VolUp();
            });

            var func2 = new Macro.Function("Sound down", new (string key, Keyboard.Key.Status status)[]
            {
                ("NumPad0", Keyboard.Key.Status.PRESSING),
                ("NumPad2", Keyboard.Key.Status.DOWN),
            }, () =>
            {
                Windows.VolDown();
            });

            Program.App.Add(func);
            Program.App.Add(func2);
        }
    }
}
