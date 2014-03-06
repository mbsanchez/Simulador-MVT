using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TinyMachine.ast;
using TinyMachine.parser;
using TinyMachine.util;
using TinyMachine.semantical;

namespace TinyMachine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
