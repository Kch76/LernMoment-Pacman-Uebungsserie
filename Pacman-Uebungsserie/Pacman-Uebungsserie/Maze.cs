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
    }
}
