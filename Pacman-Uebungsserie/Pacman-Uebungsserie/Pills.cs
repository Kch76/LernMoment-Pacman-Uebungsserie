using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanUebungsserie
{
   public  class Pills
    {
        /// <summary>
        /// Liste alle Punkte
        /// </summary>
        private List<Pill> _Pills = new List<Pill>();

        /// <summary>
        /// Erzeugt eine neue Instanz und setzt alle Punkte ein
        /// </summary>
        public Pills()
        {
            for (int i = 0; i < 600; i += 50)
            {
                for (int j = 0; j < 600; j += 50)
                {
                    _Pills.Add(new Pill(i + 25, j + 25));
                }
            }
        }

        /// <summary>
        /// Gibt alle Punkte zurück
        /// </summary>
        /// <returns>Liste aller Punkte</returns>
        public List<Pill> GetPills()
        {
            return _Pills;
        }

        /// <summary>
        /// Überprüft, ob an der angegebenen Stelle ein Punkt ist. Erreichte Punkte werden entfernt
        /// </summary>
        /// <param name="x">Position die geprüft werden soll in X-Richtung</param>
        /// <param name="y">Position die geprüft werden soll in Y-Richtung</param>
        /// <returns>true, wenn ein Punkt erreicht und entfernt wurde</returns>
        public bool CheckAndRemovePill(int x, int y)
        {
            foreach (var pill in _Pills)
            {
                if (pill.X == x && pill.Y == y)
                {
                    _Pills.Remove(pill);
                    return true;
                }
            }
            return false;
        }
    }
}
