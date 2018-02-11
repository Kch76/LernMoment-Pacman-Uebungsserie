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
    }
}
