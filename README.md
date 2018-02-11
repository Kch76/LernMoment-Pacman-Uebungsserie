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

Pacman darf während der Bewegung nicht gegen eine Wand laufen. Wenn Pacman eine Wand berührt, soll das Spiel beendet werden. Wenn der Spieler die Taste „N“ drückt, soll ein neues Spiel gestartet werden.

Eine Musterlösung findest die hier https://github.com/LernMoment/Pacman-Uebungsserie/releases/tag/V1.3

