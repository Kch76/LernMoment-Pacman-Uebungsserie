using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanUebungsserie
{
    class Maze
    {
        /// <summary>
        /// Beinhaltet alle Wände eines Labyrinths
        /// </summary>
        public List<MazeWall> Walls { get; private set; }

        /// <summary>
        /// Erzeugt eine neue Instanz eines Labyrinths
        /// </summary>
        public Maze()
        {
            Walls = new List<MazeWall>();
        }

        /// <summary>
        /// Fügt die übergeben Wand zum Labyrinth hinzu
        /// </summary>
        /// <param name="wall">Wand, die zum Labyrinth hinzugefügt werden soll</param>
        public void AddWall(MazeWall wall)
        {
            Walls.Add(wall);
        }

        /// <summary>
        /// Prüft ob Packman mit einer Wand des Labyrinths kollidiert
        /// </summary>
        /// <param name="pacman">Pacman mit der aktuellen Position</param>
        /// <returns>False, wenn Pacman mit keiner Wand der Labyrinths kollidiert, sonst true</returns>
        public bool CheckCollision(Pacman pacman)
        {
            foreach (var wall in Walls)
            {
                // Überprüfung in X Richtung
                if (pacman.X + pacman.Size / 2 > wall.LeftCornerX && pacman.X - pacman.Size / 2  < wall.RightLowerCornerX)
                {
                    // Überprüfung in Y Richtung, jedoch nur, wenn in X Richtung eine Kollosion vorliegen würde
                    if (pacman.Y + pacman.Size / 2 > wall.LeftCornerY&& pacman.Y - pacman.Size / 2 < wall.RightLowerCornerY)
                       return true;
                }
            }
            return false;
        }
    }
}
