using System;

namespace PacmanUebungsserie
{
    abstract class AbstractFigure
    {
        /// <summary>
        /// So viele Pixel bewegt sich Pacman bei einem Tastendruck
        /// </summary>
        public int Step { get { return 5; } }

        /// <summary>
        /// Dieser Pfad beschreibt, wo das Bild liegt, das Pacman darstellt
        /// </summary>
        public string ImagePath
        {
            get;
            // wir müssen Imagepath jetzt in jeder abgeleiteten Klasse setzten
            // um den Parameter erreichen zu können muss die Gültigkeit auf protected geändert werden
            // protected entspricht in etwa private, nur das abgeleitete Klassen ebenfalls zugriff darauf haben
            protected set;
        }

        /// <summary>
        /// So viele Pixel ist Pacman Breit und Hoch
        /// </summary>
        public int Size { get { return 40; } }

        /// <summary>
        /// Gibt den Winkel an, in welche Richtung Pacman läuft
        /// </summary>
        public int Angle { get; protected set; }

        /// <summary>
        /// Gibt an, wie schnell sich PAcman bewegt
        /// </summary>
        public int Speed { get; protected set; }

        /// <summary>
        /// Dies ist die aktuelle Position (in Pixeln) des Mittelpunktes von Pacman in X-Richtung
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// Dies ist die aktuelle Position (in Pixeln) des Mittelpunktes von Pacman in Y-Richtung
        /// </summary>
        public int Y { get; protected set; }

        /// <summary>
        /// Dies ist die aktuelle Position der linken oberen Ecke von Pacman in X-Richtung
        /// </summary>
        public int LeftCornerX { get { return (int)(X - Size / 2); } }

        /// <summary>
        /// Dies ist die aktuelle Position der linken oberen Ecke von Pacman in Y-Richtung
        /// </summary>
        public int LeftCornerY { get { return (int)(Y - Size / 2); } }

        /// <summary>
        /// Frame zähler zur Geschwindigkeitskontrolle
        /// </summary>
        protected int frames = 0;

        /// <summary>
        /// Setzt die Figur an die nächste Position
        /// </summary>
        protected void SetNextPosition()
        {
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
        }

        /// <summary>
        /// Macht einen Schritt durch den Spielfeldrand
        /// </summary>
        protected void StepThroughTheSidelines()
        {
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
        }

        /// <summary>
        /// Verarbeitet die Frames, in denen keine Bewegung stattgefunden hat
        /// </summary>
        protected void ProcessEmptyFrames()
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
