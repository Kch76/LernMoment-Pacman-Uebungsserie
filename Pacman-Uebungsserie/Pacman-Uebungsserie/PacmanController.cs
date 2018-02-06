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
            // Solange der PacmanController lebt wollen wir Zugriff auf den übergebenen CsharpCanvas
            // haben. Darum wird eine Referenz im entsprechenden Attribut gespeichert.
            canvas = _canvas;
            
            // definieren was passieren soll, wenn der CsharpCanvas seinen Inhalt neu zeichnen
            // will. Hier wird die Methode als EventHandler an das Draw-Event gehängt.
            canvas.Draw += DrawPacmanAtItsCurrentPosition;

            // Der CsharpCanvas wird als Spiel initialisiert (mit Punkte & Levelanzeige)
            // wenn das Spielfeld 30 mal pro Sekunde gezeichnet wird, sollte ein flüssiges
            // spielen möglich sein.
            canvas.InitGame(30);

            // erstelle einen Pacman
            pacman = new Pacman();
        }
               
        /// <summary>
        /// Draw Eventhandler, hier wird gezeichnet
        /// </summary>
        private void DrawPacmanAtItsCurrentPosition()
        {
            // nur wenn eine Taste gedrückt wurde, wird Pacman bewegt!
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
