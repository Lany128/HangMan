using System.Diagnostics.Tracing;
using System.Reflection.Metadata;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] theList = {"Rose", "Lotus", "Marigold", "Jasmine", "Periwinkle"};
            
             Random randomWord = new Random();
             string selectedWord =  theList[randomWord.Next(theList.Length)].ToLower();
             char[] wordToGuess = selectedWord.ToCharArray();
             char[] guessedLetters = new char[wordToGuess.Length];

             for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';

            }

            int attempsLeft = 10;

            while (attempsLeft > 0) 
            {
                Console.WriteLine($"the choosen word: {selectedWord}");

                Console.WriteLine($"Current Word:{new char[wordToGuess.Length]}");
                Console.WriteLine("Guess a letter: ");

                char guess = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                bool correctGuess = false;

                for (int i = 0; i < wordToGuess.Length ; i++) 
                {
                if (wordToGuess[i] == guess) 
                    {
                        guessedLetters[i] = guess;
                        correctGuess = true;
                    }
                if (!correctGuess) 
                    {
                        attempsLeft--;
                        Console.WriteLine($"Incorrect!\nAttempts left: {attempsLeft}");
                    }
                if (new string (guessedLetters) == selectedWord) 
                    {
                        Console.WriteLine($"Congratulations!\nYou guessed the word;{selectedWord}");
                        Console.ReadLine();
                        break;
                    }
                if (attempsLeft == 0) 
                    {
                        Console.WriteLine($"Sorry,you are out of attempts.\nthe word was:{selectedWord}");
                        Console.ReadLine();
                    }
                    Console.WriteLine("Thanks for playing");
                    Console.ReadLine();
                }

            }
        }
    }
}