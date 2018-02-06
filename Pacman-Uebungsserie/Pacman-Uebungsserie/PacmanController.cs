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

        // Dies ist der Pacman, mit dem wir spielen wollen
        Pacman pacman;

        /// <summary>
        /// Erstellt eine neue Instanz des Pacmancontrollers
        /// </summary>
        /// <param name="_canvas">Canvas in den gezeichnet werden soll</param>
        public PacmanController(CsharpCanvas _canvas)
        {
            // den CsharpCanvas an die lokale Variable übergeben
            canvas = _canvas;
            
            // draw Event des CsharpCanvas abonieren und einen Eventhandler definieren
            canvas.Draw += DrawPacmanAtItsCurrentPosition;

            // der CsharpCanvas muss noch initalisiert werden.
            // wir wollen ein Spiel erstellen und dieses mit 30 Frames pro Sekunde abspielen
            canvas.InitGame(30);

            // erstelle einen Pacman
            pacman = new Pacman();
        }
               
        /// <summary>
        /// Draw Eventhandler, hier wird gezeichnet
        /// </summary>
        private void DrawPacmanAtItsCurrentPosition()
        {
            // überprüfen, ob eine Taste gedrückt wurde
            if (canvas.LastPressedKey != System.Windows.Forms.Keys.None)
            {
                // Verabeiten des Tastendrucks in Pacman
                pacman.MoveToNewPosition(canvas.LastPressedKey);
                // Taste als verarbeitet melden
                canvas.KeyHandled();
            }

            // Zeichne Pacman auf den CsharpCanvas
            canvas.AddPicture(pacman.ImagePath, pacman.LeftCornerX, pacman.LeftCornerY, pacman.Size, pacman.Size, 0);
        }
    }
}
