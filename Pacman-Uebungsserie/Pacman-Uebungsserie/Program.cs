using Lernmoment.CsharpCanvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanUebungsserie
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // eine neue Instanz von CsharpCanvas anlegen
            CsharpCanvas canvas = new CsharpCanvas();

            // eine neue Instanz des Pacmancontrollers anlegen und den canvas übergeben
            PacmanController controller = new PacmanController(canvas);

            // canvas starten
            canvas.Setup();
        }
    }
}
