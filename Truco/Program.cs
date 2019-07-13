using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;


namespace Truco
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Game g = new Game("Fernando",'A',"Urbina",'B');
             Console.WriteLine("antes");
             Console.WriteLine(g.SimulacionPlay2());
             Console.WriteLine("despues");
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form1());
             */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            var thread = new Thread(ThreadStart);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
            */
            Form M1 = new Form0();
            Application.Run(M1);
        }

        private static void ThreadStart()
        {
            Form M2 = new Form0();
            Application.Run(M2); // <-- other form started on its own UI thread
        }
    }

}
