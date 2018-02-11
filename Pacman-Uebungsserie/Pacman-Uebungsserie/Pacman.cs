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
        /// Gibt den Winkel an, in welche Richtung Pacman läuft
        /// </summary>
        public int Angle { get; private set; }

        /// <summary>
        /// Gibt an, wie schnell sich PAcman bewegt
        /// </summary>
        public int Speed { get; private set; }

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
            Speed = 5;
        }

        /// <summary>
        /// Verarbeitet Tastendrücke unbd ändert entsprechend die Richtung
        /// </summary>
        /// <param name="key">´Betätigte Taste</param>
        public void ProcessKey(Keys key)
        {
            // Passt den Winkel entsprechend der gedrückte Taste an
            switch (key)
            {
                case Keys.Down:
                    Angle = 90;
                    break;
                case Keys.Up:
                    Angle = 270;
                    break;
                case Keys.Left:
                    Angle = 180;
                    break;
                case Keys.Right:
                    Angle = 0;
                    break;
            }
        }

        /// <summary>
        /// Frame zähler zur Geschwindigkeitskontrolle
        /// </summary>
        private int frames = 0;

        /// <summary>
        /// Ein Schritt von PAcman wird verarbeitet
        /// </summary>
        public void ProcessPackmanStep()
        {
            // Pacman wird nur bewegt, wenn eine Bewegung an der Reihe ist
            if (frames == 0)
            {
                // Position von Pacman wird entsprechend des Winkels verändert
                switch (Angle)
                {
                    case 90:
                        Y = Y + Step;
                        break;
                    case 270:
                        Y = Y - Step;
                        break;
                    case 180:
                        X = X - Step;
                        break;
                    case 0:
                        X = X + Step;
                        break;
                }

                // Packman kann un von einem Rand zum nächste springen, solange dort keine Wand ist
                // siehe dazu Kollisionskontrolle
                if (X >= 600 || Y >= 600)
                {
                    if (Y >= 600)
                        Y = 5;
                    if (X >= 600)
                        X = 5;
                }
                else
                {
                    if (Y <= 0)
                        Y = 595;
                    if (X <= 0)
                        X = 595;
                }
                
                // in diesem Frame wurde bewegt, deshalb wird frames um 1 erhöht.
                frames++;
            }
            else
            {
                // Um die Geschwindigkeit zu begrenzen wird nur in manchen Frames eine Bewegung durchgeführt.
                // Wie viele Frames keine Bewegung durchgeführt wird, wird mit dem Wert von Speed definiert.
                // So viele Frames wie in Speed definiert ist, wird keine Bewegung durchgeführt.
                frames++;
                if (frames == Speed)
                { frames = 0; }
            }
        }
    }
}
