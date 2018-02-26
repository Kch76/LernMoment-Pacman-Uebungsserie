Übungsserie Pacman

Willkommen zur Übungsserie Pacman. In dieser Übungsserie lernst du anhand des Spiels Pacman einige grundlegende Konzepte der Softwareentwicklung und kannst deine Basisskills trainieren. Im Laufe der Übung kannst du außerdem ein paar tiefergreifende Konzepte kennenlernen.

Um mit der Aufgabe beginne zu können, solltest du dir das erste Release herunterladen. (https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/v1.0) Darin ist alle enthalten, was du für den Einstieg brauchst. Mit diesem Projekt kannst du direkt los legen. Es gibt weitere Releases dieser Übung, so dass du deine Lösung immer wieder mit einer Musterlösung vergleichen kannst. Sollte dir eine Übung nicht gelingen oder möchtest du zu einem späteren Zeitpunkt einsteigen, kannst du so an einer Übungsstufe weitermachen, ohne die vorherigen Aufgaben gelöst zu haben.
Für diese Übung wirst du CsharpCanvas verwenden. Diese Bibliothek haben wir erstellt, damit es einfacher ist Aufgaben zu lösen, die eine grafische Ausgabe besitzen. 

Hier noch ein paar Hinweise:
-	Die Zeichenfläche des CsharpCanvas ist 600x600 Pixel groß.
-	Die Koordinaten des CsharpCanvas beginnen oben links in der Ecke mit X = 0 und Y = 0 ein Punkt mit der Position X = 100 und Y = 100 liegt also 100 Pixel rechts vom linken Rand und 100 Pixel unterhalb des oberen Randes

Nun aber erstmal genug des Einstiegs, steigen wir gleich in die erste Aufgabe ein.

Aufgabe 1: Pacman bewegen

Deine erste Aufgabe wird es sein, Pacman auf dem Spielfeld zu platzieren und ihn mit Hilfe der Pfeiltasten bewegen zu können. Pacman soll auf die Pfeiltasten reagieren. Pfeilhoch soll ihn nach oben gehen lassen, Pfeilrunter nach unten und so weiter. Pacman soll dazu eine Klasse bekommen, die ihn repräsentiert. 

Eine Musterlösung findest du hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.1

Aufgabe 2: Labyrinthe zeichnen

Als zweite Aufgabe soll ein Labyrinth gezeichnet werden. Für das Labyrinth ist es wichtig, dass Pacman noch hindurch passt und die Wege erreichbar sind. Hier musst du aufpassen, dass die Abstände mindestens so groß sind, das Pacman hindurch passt. In der Beispiellösung hat Pacman eine Schrittweite, wenn dies in deiner Lösung auch so ist muss es möglich sein, mit einem Schritt in die Mitte eines Durchgangs zu gelangen, sonst könnte es schwierig bis unmöglich sein, das Labyrinth abzulaufen. Um zu überprüfen, ob dein Labyrinth ablaufbar ist, kannst du es einfach mit Pacman ablaufen. Tipp: du kannst dein Spielfeld auf dem Papier in ein passendes Raster aufteilen und dich beim Positionieren der Mauern an diesem Raster orientieren.

Eine Musterlösung findest du hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.2

Aufgabe 3: Kollisionabfrage zwischen Pacman und dem Labyrinth

Pacman darf während der Bewegung nicht gegen eine Wand laufen. Wenn Pacman eine Wand berührt, soll das Spiel beendet werden. Wenn der Spieler die Taste „N“ drückt, soll ein neues Spiel gestartet werden. Um zu überprüfen, ob deine Lösung richtig ist, versuche das Labyrinth abzulaufen, teste auch, ob eine Berührung einer Wand zum Beenden des Spiels führt.

Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.3

Aufgabe 4: Pacman automatisch laufen lassen

Pacman soll sich jetzt automatisch bewegen, das heißt, ein Tastendruck auf die Pfeiltasten ändert die Richtung, die Bewegung läuft jedoch unabhängig davon weiter. Pacman soll sich entsprechend drehen, so dass er immer in die Laufrichtung schaut. Beachte dabei, dass die Bewegungen nicht zu schnell werden, man soll das Spiel auch noch spielen können. Versuche das Labyrinth abzulaufen. Sollte die Geschwindigkeit nicht gut gewählt sein, pass diese ab.

Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.4

Aufgabe 5: Punkte einsetzten

Bei einem Pacmanspiel soll Pacman Punkte einsammeln können, dazu müssen punkte im Speil vorhanden sein. Deine Aufgabe ist es jetzt, Punkte so in dien Labyrinth einzusetzen, dass diese von Pacman überschritten werden können. Tipp: falls du dein Labyrinth in einem bestimmten Raster eingezeichnet hast, kannst du für deine Überlegungen das gleiche Raster zum Verteilen der Punkte verwenden. Um dein Ergebnis zu überprüfen, kannst du schauen, ob an allen Stellen, die von Pacman erreicht werden können jetzt Punkte zu sehen sind und diese Überlaufen werden können.

Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.5

Aufgabe 6: Punkte fressen und zählen

Damit ein Spiel daraus wird, müssen die Punkte entfernt werden, wenn die von Pacman gefressen werden. Außerdem soll ein Spielstand angezeigt werden. Überprüfe also ob Pacman einen Punkt überläuft, wenn dies der Fall ist, entferne den Punkt und erhöhe den Punktezähler des Spiels. Um deine Lösung zu überprüfen, laufe dein Labyrinth ab und versuche alle Punkte einzusammeln, zähle vorher alle Punkte und überprüfe, ob der Punktezähler entsprechend hoch aufsummiert wird. Tipp: die Aufgabe ähnelt inhaltlich Aufgabe 3.

Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.6

Aufgabe 7: Level hinzufügen

Um das Spiel etwas interessanter zu gestalten, soll es mehrere Levels geben. Jedes Level besitzt ein eigenes Labyrinth (Labyrinth anlegen siehe Aufgabe 2). Wenn alle Punkte eines Levels aufgefressen sind, wird das nächste Level gestartet. Es soll ein Levelzähler angezeigt werden, der dem Spieler zeigt, in welchem Level er gerade unterwegs ist. Wenn alle Level erfolgreich abgeschlossen wurden, soll dem Spieler eine Siegesmeldung angezeigt werden.

Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.7

Aufgabe 8: Geister hinzufügen

Pacman muss nicht nur Punkte sammeln, er muss sich auch vor Geistern in Acht nehmen. Deshalb ist jetzt deine Aufgabe Geister ins Spiel einzubringen. Das erste Level soll bereits 2 Geister enthalten. In jedem weiteren Level soll einen weiterer Geist hinzukommen. Überlege dir eine Möglichkeit, Geister in das Labyrinth einzusetzen. Die Geister sollen selbstständig laufen können. Überlegen außerdem, wie die Geister sich spannend bewegen können, so dass sie nicht immer dieselbe Strecke entlang laufen.


Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.8

Aufgabe 9: Kollisionsabfrage mit Geistern

Nach der letzten Übung kannst du mit Pacman noch durch die Geister hindurch laufen, dass soll natürlich nicht so bleiben. Um ein das Spiel zu vervollständigen, sollst du nun eine Abfrage einbauen, die dazu führt, dass eine Berührung von Pacman mit einem Geist zum Spielende führt.

Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.9

Du bist fertig und hast Lust weiter zu machen?
Dann kannst du zum Beispiel weiter an den „KI“ der Geister arbeiten, im Moment sind die noch relativ einfach in ihrer Bewegung, überlege z.B. wie die Geister sich immer Richtung Pacman bewegen können. Wenn du darauf keine Lust hast, schau dir die Aufgaben für Fortgeschrittene an.

Aufgabe 10 (für Fortgeschrittene): Klassen zusammenlegen

Wenn man sich den Code anschaut, gibt es starke Ähnlichkeiten in den Klassen Ghost.cs und Pacman.cs. Was man dagegen tun kann? Abstrakte Klassen und Vererbung. Schau dir die beiden Klassen an und prüfe, was beide gemeinsam haben und was sie unterscheidet. Entwerfe eine Klasse die die Gemeinsamkeiten implementiert, außerdem kannst du hier evtl. schon die Rümpfe für Methoden hineinlegen, auch wenn diese sich bei beiden abgeleiteten Klassen in der Implementierung unterscheiden.


Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.10
