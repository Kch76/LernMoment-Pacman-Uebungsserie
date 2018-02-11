using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanUebungsserie
{
    /// <summary>
    /// Definiert eine Richtung für eine Wand
    /// </summary>
    public enum WallDirection
    {
        Vertical,
        Horizontal
    }

    class MazeWall
    {
        /// <summary>
        /// Dies ist die aktuelle Position der linken oberen Ecke der Wand in X-Richtung
        /// </summary>
        public int LeftCornerX { get; private set; }

        /// <summary>
        /// Dies ist die aktuelle Position der linken oberen Ecke der Wand in Y-Richtung
        /// </summary>
        public int LeftCornerY { get; private set; }

        /// <summary>
        /// Dies ist die aktuelle Position der rechten unteren Ecke der Wand in X-Richtung
        /// </summary>
        public int RightLowerCornerX { get { return LeftCornerX + Width; } }

        /// <summary>
        /// Die ist die aktuelle Position der rechten unteren Ecke der Wand in Y-Richtung
        /// </summary>
        public int RightLowerCornerY { get { return LeftCornerY + Height; } }

        /// <summary>
        /// So hoch ist die Wand
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// So breit ist die Wand
        /// </summary>
        public int Width { get; private set; }
        
        /// <summary>
        /// Konstante für die Wandstärke
        /// </summary>
        private const int Thickness = 5;

        /// <summary>
        /// Erzeugt eine neue Isntanz einer Wande
        /// </summary>
        /// <param name="x">X Position der Wand</param>
        /// <param name="y">Y Position der Wand</param>
        /// <param name="length">So lang wird die Wand</param>
        /// <param name="direction">In diese Richtung besitzt die Wand die angegebene Länge</param>
        public MazeWall(int x, int y, int length, WallDirection direction)
        {           
            // da es sich bei den Wänden beim Zeichnen um Rechtecke handeln wird, müssen
            // die Werte für die Ecken berechnet werden. Außerdem muss abhängig von der Richtung
            // die Länge und die Dicke den entsprechenden Eigenschaften zugeordnet werden
            switch (direction)
            {
                case WallDirection.Horizontal:
                    // Bei einer horizontalen Wand entspricht Width der Länge. Es muss zusätzlich die Dicke 
                    // Addiert werden. Dadurch werden angrenzende Senkrechte Wände direkt angeschlossen.
                    // Es ahndelt sich hierbei jedoch eher um eine kosmetische Anpassung
                    Width = length + Thickness;
                    Height = Thickness;
                    // Bei der Berechnung der Positionen ist zu beachten, dass die Position der Wandangegeben wurde.
                    // Zum Zeichnen muss jedoch die Ecke angegeben werden. Deshalb muss in der Richtung, in der die
                    // Wand nur die Dicke besitzt, die Eckposition so angepasst werden, dass sich die Mitte der Wand 
                    // an der angegebenen Position befindet. Ansonsten könnte es hier zu behinderungen an einer 
                    // Seite der Wand kommen.
                    LeftCornerX = x - Thickness / 2 - 1;
                    LeftCornerY = y;
                    break;
                case WallDirection.Vertical:
                    Width = Thickness;
                    Height = length + Thickness;
                    LeftCornerX = x - Thickness / 2 - 1;
                    LeftCornerY = y;
                    break;
            }
        }
    }
}
