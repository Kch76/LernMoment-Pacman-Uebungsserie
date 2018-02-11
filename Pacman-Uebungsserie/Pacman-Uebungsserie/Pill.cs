using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanUebungsserie
{
    public class Pill
    {
        /// <summary>
        /// Größe eines Punkts
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Position des Mittelpunkts eines Punkts in X-Richtung
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Position des Mittelpunkts eines Punkts in Y-Richtung
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Erzuegt eine neue Instanz eines Punkts an den angegebenen Koordinaten
        /// </summary>
        /// <param name="x">Position in X-Richtung</param>
        /// <param name="y">Position in Y-Richtung</param>
        public Pill(int x, int y)
        {
            X = x;
            Y = y;
            Size = 7;
        }
    }
}
