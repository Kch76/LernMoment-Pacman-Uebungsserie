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
        private CsharpCanvas canvas;

        // Dies ist der Pacman, mit dem wir spielen wollen
        private Pacman pacman;

        // Dies ist das Labyrinth, welches gerade verwendet wird.
        private Maze maze;

        /// <summary>
        /// Erstellt eine neue Instanz des Pacmancontrollers
        /// </summary>
        /// <param name="_canvas">Canvas in den gezeichnet werden soll</param>
        public PacmanController(CsharpCanvas _canvas)
        {
            // Solange der PacmanController lebt wollen wir Zugriff auf den übergebenen CsharpCanvas
            // haben. Darum wird eine Referenz im entsprechenden Attribut gespeichert.
            canvas = _canvas;
            
            // definieren was passieren soll, wenn der CsharpCanvas seinen Inhalt neu zeichnen
            // will. Hier wird die Methode als EventHandler an das Draw-Event gehängt.
            canvas.Draw += DrawPacmanAtItsCurrentPositionAndRedrawMaze;

            // Der CsharpCanvas wird als Spiel initialisiert (mit Punkte & Levelanzeige)
            // wenn das Spielfeld 30 mal pro Sekunde gezeichnet wird, sollte ein flüssiges
            // spielen möglich sein.
            canvas.InitGame(30);

            // erstelle einen Pacman
            pacman = new Pacman();

            // ein Labyrinth erzeugen, dieses wird dabei direkt maze zugeordnet
            GenerateMaze();
        }
               
        /// <summary>
        /// Draw Eventhandler, hier wird gezeichnet
        /// </summary>
        private void DrawPacmanAtItsCurrentPositionAndRedrawMaze()
        {
            // Da die Anzeige bei jedem Zeichnen gelöscht wird, muss jedesmal das Labyrinth gezeichnet werden.
            // Dazu muss für jede Wand ein Rechteckgezeichnet werden.
            foreach(var wall in maze.Walls)
            {
                // Meine Wände sollen in Braun gezeichnet werden.
                canvas.SetForegroundColor(System.Drawing.Color.Brown);
                canvas.AddRectangle(wall.LeftCornerX, wall.LeftCornerY, wall.Width, wall.Height, Fill.Fill);
            }

            // nur wenn eine Taste gedrückt wurde, wird Pacman bewegt!
            if (canvas.LastPressedKey != System.Windows.Forms.Keys.None)
            {
                // Verabeiten des Tastendrucks in Pacman
                pacman.MoveToNewPosition(canvas.LastPressedKey);
                // Taste als verarbeitet melden
                canvas.KeyHandled();
            }

            // Zeichne Pacman auf den CsharpCanvas
            canvas.AddPicture(pacman.ImagePath, pacman.LeftCornerX, pacman.LeftCornerY, pacman.Size, pacman.Size, 0);
        }

        /// <summary>
        /// Erzeugt ein neues Labyrinth
        /// </summary>
        private void GenerateMaze()
        {
            // neues Labyrinth erstellen
            maze = new Maze();

            // Zuerst werden alle horizontalen Wände erstellt
            maze.AddWall(new MazeWall(50, 50, 300, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(400, 50, 150, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(100, 100, 150, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(200, 150, 150, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(200, 300, 50, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(450, 300, 100, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(50, 350, 200, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(300, 350, 50, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(450, 400, 100, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(50, 550, 100, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(200, 550, 200, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(450, 550, 100, WallDirection.Horizontal));

            // Im Anschluss alle waagerechten Wände
            maze.AddWall(new MazeWall(50, 50, 200, WallDirection.Vertical));
            maze.AddWall(new MazeWall(50, 350, 200, WallDirection.Vertical));
            maze.AddWall(new MazeWall(100, 100, 150, WallDirection.Vertical));
            maze.AddWall(new MazeWall(150, 500, 50, WallDirection.Vertical));
            maze.AddWall(new MazeWall(200, 150, 150, WallDirection.Vertical));
            maze.AddWall(new MazeWall(200, 500, 50, WallDirection.Vertical));
            maze.AddWall(new MazeWall(350, 150, 150, WallDirection.Vertical));
            maze.AddWall(new MazeWall(350, 350, 150, WallDirection.Vertical));
            maze.AddWall(new MazeWall(400, 50, 350, WallDirection.Vertical));
            maze.AddWall(new MazeWall(400, 450, 100, WallDirection.Vertical));
            maze.AddWall(new MazeWall(450, 300, 100, WallDirection.Vertical));
            maze.AddWall(new MazeWall(450, 500, 50, WallDirection.Vertical));
            maze.AddWall(new MazeWall(550, 50, 250, WallDirection.Vertical));
            maze.AddWall(new MazeWall(550, 400, 150, WallDirection.Vertical));
        }
    }
}
