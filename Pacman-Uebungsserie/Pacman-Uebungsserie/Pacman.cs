using System.Windows.Forms;

namespace PacmanUebungsserie
{
    class Pacman : AbstractFigure
    {
        /// <summary>
        /// Erstellt eine neue Instanz von Pacman und legt Startwerte fest
        /// </summary>
        public Pacman()
        {
            ImagePath = "Ressources/Pacman.png";

            // Festlegen der Startposition von Pacman
            X = 25;
            Y = 25;
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
        /// Ein Schritt von PAcman wird verarbeitet
        /// </summary>
        public void ProcessPackmanStep()
        {
            // Pacman wird nur bewegt, wenn eine Bewegung an der Reihe ist
            if (frames == 0)
            {
                // Position von Pacman wird entsprechend des Winkels verändert
                SetNextPosition();

                // Packman kann un von einem Rand zum nächste springen, solange dort keine Wand ist
                // siehe dazu Kollisionskontrolle
                StepThroughTheSidelines();

                // in diesem Frame wurde bewegt, deshalb wird frames um 1 erhöht.
                frames++;
            }
            else
            {
                ProcessEmptyFrames();
            }
        }
    }
}
