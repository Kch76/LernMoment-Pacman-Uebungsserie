using System;
using System.Collections.Generic;

namespace PacmanUebungsserie
{
    class Ghost : AbstractFigure
    {
        private int stepsInOneWay = 0;
        public void ProcessGhostStep(bool collision)
        {
            var rnd = new Random();
            if (frames == 0)
            {
                // Sollte der Geist mit einer Wand kollidieren, dreht er um
                if (collision)
                {
                    switch (Angle)
                    {
                        case 90: Angle = 270; break;
                        case 180: Angle = 0; break;
                        case 270: Angle = 90; break;
                        case 0: Angle = 180; break;
                    }
                }

                // Um die Bewegung ien bisschen Zzufällig zu gestalten, wird manchmal die Richtung geändert.
                // Die Richtung wird nur gewechslet, wenn sich der Geist gerade auf einer Punktlinie befindet
                if (stepsInOneWay >= 3 && X % 50 == 25 && Y % 50 == 25)
                {
                    if ((rnd.Next() % 2 == 1))
                    {
                        var newAngle = new Random();
                        var oldAngle = Angle;
                        switch (newAngle.Next(1, 4))
                        {
                            case 1:
                                Angle = 90;
                                break;
                            case 2:
                                Angle = 180;
                                break;
                            case 3:
                                Angle = 270;
                                break;
                            case 4:
                                Angle = 0;
                                break;
                        }
                        if (oldAngle != Angle)
                        {
                            stepsInOneWay = 0;
                        }
                    }
                }

                // Geist bewegen
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

                // Geist duch den Spielfeldrand laufen lassen
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
                stepsInOneWay++;
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

        /// <summary>
        /// erzeugt einen neuen Geist an einer freien Position
        /// </summary>
        /// <param name="ghosts">neuer Geist</param>
        public Ghost(List<Ghost> ghosts)
        {
            ImagePath = "Ressources/Ghost.gif";

            // Startposition festlegen
            // um die Startposition zufällig zu wählen, wird eine zufällige Position festgelegt und mit dem Ratsreschritt multipliziert
            do
            {
                var rnd = new Random();
                X = rnd.Next(0, 11) * 50 - 25;
                Y = rnd.Next(0, 11) * 50 - 25;
            }
            while (CheckOtherGhosts(ghosts));

            Speed = 5;
        }

        /// <summary>
        /// Überprüft ob sich an der Position des Geists bereits ein anderer Geist befindet
        /// </summary>
        /// <param name="ghosts"></param>
        /// <returns></returns>
        private bool CheckOtherGhosts(List<Ghost> ghosts)
        {
            foreach (var ghost in ghosts)
            {
                if (ghost.X == X && ghost.Y == Y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Überpfüft, ob dieser Geist mit Pacman kollidiert
        /// </summary>
        /// <param name="pacman">Pacman</param>
        /// <returns>true, wenn es eine Kollision gibt, sonst false</returns>
        public bool CheckCollision(Pacman pacman)
        {
            if (X + Size / 2 > pacman.LeftCornerX && X - Size / 2 < pacman.LeftCornerX + pacman.Size)
            {
                if (Y + Size / 2 > pacman.LeftCornerY && Y - Size / 2 < pacman.LeftCornerY + pacman.Size)
                    return true;
            }
            return false;
        }
    }
}
