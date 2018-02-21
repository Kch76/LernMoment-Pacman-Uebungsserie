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
        /// Liste der Level
        /// </summary>
        private List<Maze> Level;

        private int _LevelCounter = 0;
        /// <summary>
        /// Level Zähler
        /// </summary>
        private int LevelCounter
        {
            get { return _LevelCounter; }
            set {
                if (value != _LevelCounter)
                {
                    if (value <= Level.Count)
                    {
                        _LevelCounter = value;
                        canvas.Level = _LevelCounter;
                        if (value != 0)
                        {
                            maze = Level[_LevelCounter - 1];
                            pacman = new Pacman();
                        }
                    }
                    else
                    {
                        QuitGame(true);
                    }
                }
            }
        }

        private int _Score = 0;
        /// <summary>
        /// Spielpunktezähler
        /// </summary>
        private int Score
        {
            get { return _Score; }
            set
            {
                _Score = value;
                // Setzte den Wert des Punktezählers auf CsharpCanvas, damit wird er angezeigt.
                canvas.Score = value;
            }
        }


        private bool IsRunningGame = false;

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

            StartGame();
        }

        /// <summary>
        /// Draw Eventhandler, hier wird gezeichnet
        /// </summary>
        private void DrawPacmanAtItsCurrentPositionAndRedrawMaze()
        {
            CheckKeys();
            if (IsRunningGame)
            {
                // Da die Anzeige bei jedem Zeichnen gelöscht wird, muss jedesmal das Labyrinth gezeichnet werden.
                // Dazu muss für jede Wand ein Rechteckgezeichnet werden.
                foreach (var wall in maze.Walls)
                {
                    // Meine Wände sollen in Braun gezeichnet werden.
                    canvas.SetForegroundColor(System.Drawing.Color.Brown);
                    canvas.AddRectangle(wall.LeftCornerX, wall.LeftCornerY, wall.Width, wall.Height, Fill.Fill);
                }

                // Alle Punkte, die in einem Labyrinth enthalten sind Zeichnen
                foreach (var pill in maze.Pills.GetPills())
                {
                    // Meine Punkte sollen in Blau gezeichnet werden.
                    canvas.SetForegroundColor(System.Drawing.Color.Blue);
                    canvas.AddCircle(pill.X, pill.Y, pill.Size, Fill.Fill);
                }

                // Pacman bewegen
                pacman.ProcessPackmanStep();
                // Zeichne Pacman auf den CsharpCanvas
                canvas.AddPicture(pacman.ImagePath, pacman.LeftCornerX, pacman.LeftCornerY, pacman.Size, pacman.Size, pacman.Angle);

                // Überprüfen, ob Punkte erziehlt wurden, wenn ja -> Punktezähler erhöhen
                if (maze.Pills.CheckAndRemovePill(pacman.X, pacman.Y))
                    Score++;

                // Überprüfen, ob Pacman an der neuen Position mit der Wand kollidiert.
                if (maze.CheckCollision(pacman))
                {
                    QuitGame(false);
                }

                // Level überprüfen, ob es bereits leer ist
                CheckLevel();
            }
        }

        /// <summary>
        /// Überprüft, ob Tasten berätigt wurden und bearbeitet sie entsprechend
        /// </summary>
        private void CheckKeys()
        {
            if (canvas.LastPressedKey != System.Windows.Forms.Keys.None)
            {
                pacman.ProcessKey(canvas.LastPressedKey);

                if (canvas.LastPressedKey == System.Windows.Forms.Keys.N)
                {
                    StartGame();
                }
                canvas.KeyHandled();
            }
        }

        /// <summary>
        /// Startet ein neues Spiel
        /// </summary>
        public void StartGame()
        {
            pacman = new Pacman();
            // Punkte zähler auf Null setzten
            Score = 0;

            LevelCounter = 0;

            Level = GenerateLevel();
            LevelCounter++;

            // Das Speilergebnis wird zurückgesetzt, dadurch wird dieses nicht mehr angezeigt.
            canvas.AddGameResult("");

            IsRunningGame = true;
        }

        /// <summary>
        /// Beendet das laufende Spiel
        /// </summary>
        private void QuitGame(bool result)
        {
            IsRunningGame = false;
            if (result)
            {
                // Es wird ein Spielergebnis mit einem Hinweis für den Start eines neuen Spiels angezeigt
                canvas.AddGameResult("You Won  Restart: press N");
            }
            else
            {
                canvas.AddGameResult("Game Over  Restart: press N");
            }
        }

        /// <summary>
        /// Überprüft die Punkte im Level
        /// </summary>
        private void CheckLevel()
        {
            if (maze.Pills.GetPills().Count<=0)
            {
                LevelCounter++;
            }
        }

        /// <summary>
        /// Erzeugt alle Level
        /// </summary>
        /// <returns>Liste der Labyrinthe</returns>
        private List<Maze> GenerateLevel()
        {
            List<Maze> level = new List<Maze>();
            level.Add(GetLevel1());
            level.Add(GetLevel2());

            return level;
        }
        
        /// <summary>
        /// Erzeugt ein neues Labyrinth für Level 1
        /// </summary>
        private Maze GetLevel1()
        {
            // neues Labyrinth erstellen
           var maze = new Maze();

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

            return maze;
        }

        /// <summary>
        /// Erzeugt ein neues Labyrinth für Level 2
        /// </summary>
        private Maze GetLevel2()
        {
            var maze = new Maze();
            maze.AddWall(new MazeWall(0, 0, 250, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(350, 0, 250, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(150, 150, 350, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(50, 250, 100, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(200, 300, 200, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(100, 350, 100, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(300, 400, 100, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(50, 550, 250, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(350, 550, 150, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(0, 595, 300, WallDirection.Horizontal));
            maze.AddWall(new MazeWall(400, 595, 200, WallDirection.Horizontal));

            maze.AddWall(new MazeWall(2, 0, 300, WallDirection.Vertical));
            maze.AddWall(new MazeWall(2, 400, 200, WallDirection.Vertical));
            maze.AddWall(new MazeWall(50, 50, 200, WallDirection.Vertical));
            maze.AddWall(new MazeWall(100, 350, 200, WallDirection.Vertical));
            maze.AddWall(new MazeWall(200, 250, 100, WallDirection.Vertical));
            maze.AddWall(new MazeWall(300, 100, 50, WallDirection.Vertical));
            maze.AddWall(new MazeWall(300, 350, 100, WallDirection.Vertical));
            maze.AddWall(new MazeWall(400, 200, 100, WallDirection.Vertical));
            maze.AddWall(new MazeWall(400, 400, 100, WallDirection.Vertical));
            maze.AddWall(new MazeWall(500, 150, 100, WallDirection.Vertical));
            maze.AddWall(new MazeWall(500, 350, 200, WallDirection.Vertical));
            maze.AddWall(new MazeWall(598, 0, 250, WallDirection.Vertical));
            maze.AddWall(new MazeWall(598, 350, 300, WallDirection.Vertical));

            return maze;
        }
    }
}
