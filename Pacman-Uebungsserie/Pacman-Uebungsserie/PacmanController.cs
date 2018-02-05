using Lernmoment.CsharpCanvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanUebungsserie
{
    class PacmanController
    {
        CsharpCanvas canvas;

        public PacmanController(CsharpCanvas _canvas)
        {
            canvas = _canvas;
            canvas.SetBackgroundColor(System.Drawing.Color.AliceBlue);
            canvas.Draw += Canvas_Draw;

            // for continous drawing
            canvas.InitGame(5);
        }
               
        private void Canvas_Draw()
        {
        }
    }
}
