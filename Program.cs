using System;

class NumberGuesser
{
    static void Main()
    {
        Random random = new Random();
        int targetNumber = random.Next(1, 101);  // Zufallszahl zwischen 1 und 100
        int guess = 0;
        int attempts = 0;
        int maxAttempts = 5;

        Console.WriteLine("Willkommen zum Zahlraten-Spiel!");
        Console.WriteLine("Du hast 5 Versuche, um die Zahl zu erraten.");
        Console.WriteLine("Ich habe eine Zahl zwischen 1 und 100 gewählt. Viel Glück!");

        while (guess != targetNumber && attempts < maxAttempts)
        {
            Console.Write($"Versuch {attempts + 1} von {maxAttempts}: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out guess))
            {
                attempts++;

                // Berechnen der Nähe zur Zahl und Ausgabe der entsprechenden Farbe
                int difference = Math.Abs(targetNumber - guess);

                if (difference == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Glückwunsch! Du hast die Zahl in {0} Versuchen erraten!", attempts);
                    break;
                }
                else if (difference <= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Sehr nah! Versuche es noch einmal.");
                }
                else if (difference <= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Du bist nah dran. Weiter so!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Viel zu weit entfernt! Versuche es weiter.");
                }

                // Zurücksetzen der Schriftfarbe auf Standard
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein.");
            }
        }

        if (guess != targetNumber)
        {
            Console.WriteLine($"Leider hast du die Zahl nicht erraten. Die richtige Zahl war {targetNumber}.");
        }
    }
}
