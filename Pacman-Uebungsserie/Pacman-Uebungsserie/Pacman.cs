using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanUebungsserie
{
    class Pacman
    {
        /// <summary>
        /// So viele Pixel bewegt sich Pacman bei einem Tastendruck
        /// </summary>
        public int Step { get { return 5; } }

        /// <summary>
        /// Dieser Pfad beschreibt, wo das Bild liegt, das Pacman darstellt
        /// </summary>
        public string ImagePath { get { return "Ressources/Pacman.png"; } }

        /// <summary>
        /// So viele Pixel ist Pacman Breit und Hoch
        /// </summary>
        public int Size { get { return 40; } }

        /// <summary>
        /// Dies ist die aktuelle Position (in Pixeln) des Mittelpunktes von Pacman in X-Richtung
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Dies ist die aktuelle Position (in Pixeln) des Mittelpunktes von Pacman in Y-Richtung
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Dies ist die aktuelle Position der linken oberen Ecke von Pacman in X-Richtung
        /// </summary>
        public int LeftCornerX { get { return (int)(X - Size / 2); } }

        /// <summary>
        /// Dies ist die aktuelle Position der linken oberen Ecke von Pacman in Y-Richtung
        /// </summary>
        public int LeftCornerY { get { return (int)(Y - Size / 2); } }


        /// <summary>
        /// Erstellt eine neue Instanz von Pacman und legt Startwerte fest
        /// </summary>
        public Pacman()
        {
            // Festlegen der Startposition von Pacman
            X = 300;
            Y = 300;
        }

        /// <summary>
        /// Berechnet die neue Position von Pacman anhand eines Tastendrucks
        /// </summary>
        /// <param name="key">Die Taste die verarbeitet werden soll</param>
        public void MoveToNewPosition(Keys key)
        {
            // Pacman bewegt sich durch drücken der Pfeiltasten.
            switch (key)
            {
                case Keys.Down:
                    // Pacman darf nur nach unten gehen, wenn er nicht vom Spielfeld fällt!
                    if (Y + Step < 600 - Size / 2)
                    {
                        Y = Y + Step;
                    }
                    break;
                case Keys.Up:
                    // Pacman darf nur nach oben gehen, wenn er nicht vom Spielfeld fällt!
                    if (Y - Step > 0 + Size / 2)
                    {
                        Y = Y - Step;
                    }
                    break;
                case Keys.Left:
                    // Pacman darf nur nach links gehen, wenn er nicht vom Spielfeld fällt!
                    if (X - Step > 0 + Size / 2)
                    {
                        X = X - Step;
                    }
                    break;
                case Keys.Right:
                    // Pacman darf nur nach rechts gehen, wenn er nicht vom Spielfeld fällt!
                    if (X + Step < 600 - Size / 2)
                    {
                        X = X + Step;
                    }
                    break;
            }
        }
    }
}
