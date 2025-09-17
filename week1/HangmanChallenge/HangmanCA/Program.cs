using System;

namespace HangmanCA
{
    class Program
    {
        static readonly string[] wordlist = [
            "word",
            "sharp",
            "random",
            "rhythm",
            "jazz",
            "read",
            "tree",
            "hangman",
            "bird",
            "food"
        ];

        static readonly string[] hangmen = [
            """
            ____
            |  |
            |  O
            | /|\
            | / \
            |
            """,
            """
            ____
            |  |
            |  O
            | /|\
            | / 
            |
            """,
            """
            ____
            |  |
            |  O
            | /|\
            | 
            |
            """,
            """
            ____
            |  |
            |  O
            | /|
            | 
            |
            """,
            """
            ____
            |  |
            |  O
            | 
            | 
            |
            """,
            """
            ____
            |  |
            |  
            | 
            | 
            |
            """,
        ];

        static string GetHangman(int lives)
        {
            int index = lives - 1;

            if (index < 0) index = 0;
            if (index > 5) index = 5;

            return hangmen[index];
        }

        static void PrintHeader(char[] displayWord, int lives, List<char> _guessedLetters, List<char> wrongUsedLetters, string message)
        {
            string output = $"""
            
                === HANGMAN ===
                Lives left: {lives}
                Incorrect guesses: {((wrongUsedLetters.Count > 0) ? string.Join(", ", wrongUsedLetters) : "nothing")}

                ${GetHangman(lives)}

                  {string.Join(" ", displayWord)}

                {message}
                """;

            Console.Clear();
            Console.WriteLine(output);
        }
        
        public static void Main(string[] args)
        {
            // indicate application startup
            Console.WriteLine("Starting Hangman Game...");

            string message = "";  // print message(s) below header

            Random rand = new Random();
            string word = wordlist[rand.Next(wordlist.Length)];
            char[] displayWord = new string('_', word.Length).ToCharArray();
            int lives = 6; // lose at zero
            List<char> guessedLetters = [];
            List<char> wrongUsedLetters = [];

            // placeholder for game setup and initlialization
            Console.WriteLine("Welcome to Hangman!");

            // placeholder for game loop
            while (lives > 0)
            {
                // print header
                // Console.Clear();
                // Console.WriteLine("===HANGMAN===");
                // Console.WriteLine($"Lives left: {lives}");
                // string incorrectLetters = (wrongUsedLetters.Count > 0) ? string.Join(", ", wrongUsedLetters) : "nothing";
                // Console.WriteLine($"Incorrect guesses: {incorrectLetters}"); // print already guessed
                // Console.WriteLine();
                // Console.WriteLine($"(insert hangman image here)");
                // Console.WriteLine();
                // Console.WriteLine($"  {string.Join(" ", displayWord)}"); // print displayWords
                // Console.WriteLine();
                // Console.WriteLine(message);
                PrintHeader(displayWord, lives, guessedLetters, wrongUsedLetters, message);

                // input letter
                Console.Write($"> "); // input request
                string input = Console.ReadLine() ?? "";

                // normalize input (lowercase, trim whitespace)
                input = input.Trim();
                input = input.ToLower();

                // validate: must be length 1
                if (input.Length < 1)
                {
                    message = "Error: Please enter a letter to guess!";
                    continue;
                }
                else if (input.Length > 1)
                {
                    message = "Error: Please enter only one letter!";
                    continue;
                }

                // convert string to char
                char guessedLetter = char.Parse(input);

                // calidate: must be a valid letter in the english alphabet
                if (guessedLetter < 97 || guessedLetter > 122)
                {
                    // not a letter
                    message = $"Error: \"{guessedLetter}\" is not a valid english letter!";
                    continue;
                }

                // is letter used already?
                if (guessedLetters.Contains(guessedLetter))
                {
                    message = $"You already guessed that letter ({guessedLetter})!";
                    continue;
                }
                else
                {
                    // add letter to guessedLetters
                    guessedLetters.Add(guessedLetter);
                }

                // is letter in word?
                if (word.Contains(guessedLetter))
                {
                    // correct guess
                    message = $"Correct guess! ({guessedLetter})";
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guessedLetter)
                        {
                            displayWord[i] = guessedLetter;
                        }
                    }
                }
                else
                {
                    // incorrect guess, lose a life
                    message = $"Incorrect guess... ({guessedLetter})";
                    wrongUsedLetters.Add(guessedLetter);
                    lives--;
                }

                // did you win yet
                if (!displayWord.Contains('_'))
                {
                    break;
                }
            }

            PrintHeader(displayWord, lives, guessedLetters, wrongUsedLetters, message);

            Console.WriteLine($"The word was: {word}\n");

            // if lives > 0, you won! yay!
            if (lives > 0)
            {

                Console.WriteLine("You won! Yay!\n");
            }
            else
            {
                Console.WriteLine("You lost... Better luck next time!");
            }

            // indicate application shutdown
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Console.WriteLine("\rExiting Hangman Game...");
        }
    }
}
