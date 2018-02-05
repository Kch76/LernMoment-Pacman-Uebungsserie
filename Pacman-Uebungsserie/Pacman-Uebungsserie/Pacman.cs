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
        /// So groß ist die Bewegung, die Pacman bei einem Tastendruck macht
        /// </summary>
        public int Step { get { return 10; } }

        /// <summary>
        /// Dieser Pfad beschreibt, wo das Bild liegt, das Pacman darstellt
        /// </summary>
        public string ImagePath { get { return "Ressources/Pacman.png"; } }

        /// <summary>
        /// So groß ist acman
        /// </summary>
        public int Size { get { return 40; } }

        /// <summary>
        /// Dies ist die Position von Pacman in X-Richtung
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Dies ist die Position von Pacman in Y-Richtung
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Dies ist die Position der linken oberen Ecke von Pacman in X-Richtung
        /// </summary>
        public int LeftCornerX { get { return (int)(X - Size / 2); } }

        /// <summary>
        /// Dies ist die Position der linken oberen Ecke von Pacman in Y-Richtung
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
        /// Verarbeitet Tasteneingaben
        /// </summary>
        /// <param name="key">Die Taste die verarbeitet werden soll</param>
        public void ProcessKey(Keys key)
        {
            // bei einem Tastendruck der Pfeiltasten soll eine Bewegung durchgeführt werden.
            switch (key)
            {
                case Keys.Down:
                    // damit Pacman nicht aus dem Spielfeld läuft, begrenzen wir den Aktionsradius
                    if (Y + Step < 600 - Size / 2)
                    {
                        Y = Y + Step;
                    }
                    break;
                case Keys.Up:
                    if (Y - Step > 0 + Size / 2)
                    {
                        Y = Y - Step;
                    }
                    break;
                case Keys.Left:
                    if (X - Step > 0 + Size / 2)
                    {
                        X = X - Step;
                    }
                    break;
                case Keys.Right:
                    if (X + Step < 600 - Size / 2)
                    {
                        X = X + Step;
                    }
                    break;
            }
        }
    }
}
