using Lernmoment.CsharpCanvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanUebungsserie
{
    class PacmanController
    {
        CsharpCanvas canvas;

        /// <summary>
        /// Erstellt eine neue Instanz des Pacmancontrollers
        /// </summary>
        /// <param name="_canvas">Canvas in den gezeichnet werden soll</param>
        public PacmanController(CsharpCanvas _canvas)
        {
            // den canvas an die lokale Variable übergeben
            canvas = _canvas;
            
            // draw Event des Canvas abonieren und einen Eventhandler definieren
            canvas.Draw += Canvas_Draw;

            // der Canvas muss noch initalisiert werden.
            // wir wollen ein Spiel erstellen und dieses mit 30 Frames pro Sekunde abspielen
            canvas.InitGame(5);
        }
               
        /// <summary>
        /// Draw Eventhandler, hier wird gezeichnet
        /// </summary>
        private void Canvas_Draw()
        {
        }
    }
}
