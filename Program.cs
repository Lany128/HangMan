using System.Diagnostics.Tracing;
using System.Reflection.Metadata;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
           const char  EMPTY_LINE = '_';
           const int ATTEMPTS_LEFT = 10;
           int attemptsLeft = ATTEMPTS_LEFT; //will track attempts left
           char guessTheWord = '*';
           const int MIN_AMOUNTS_OF_LETTER_TO_GUESS = 3;
            string wordGuess = ""; 

            string[] theList = {"Rose", "Lotus", "Marigold", "Jasmine", "Periwinkle"};
            
             Random randomWord = new Random();
             string selectedWord =  theList[randomWord.Next(theList.Length)].ToLower();
             char[] wordToGuess = selectedWord.ToCharArray();
             char[] guessedLetters = new char[wordToGuess.Length];
             HashSet<char>checkRepeatedWord = new HashSet<char>();

            for (int i = 0; i <guessedLetters.Length; i++) 
            {
                guessedLetters[i] = EMPTY_LINE;
            }
            
            while (attemptsLeft > 0) 
            {
                Console.WriteLine($"Guess the name of the flower:\n{new string(guessedLetters)}");
                Console.WriteLine($"You have {attemptsLeft} attempts.");

                Console.WriteLine($"the choosen word:{selectedWord} *delete this after the code is done*");

                char guess = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                int missingLetter = 0;

                //calculate missing letters
                for (int i = 0; i < guessedLetters.Length; i++)
                {
                    if (guessedLetters[i] == EMPTY_LINE)
                    { 
                        missingLetter++;
                    }
                }

                if (missingLetter < MIN_AMOUNTS_OF_LETTER_TO_GUESS) 
                {
                    Console.WriteLine($"If you wish to guess the entire word, press {guessTheWord}.");
                
                }

                //If the user decides to guess the whole word
                if (guess == guessTheWord && missingLetter < MIN_AMOUNTS_OF_LETTER_TO_GUESS)
                { 
                    Console.WriteLine("Enter the entire guessing word: ");
                    wordGuess= Console.ReadLine().ToLower();

                    if (wordGuess == selectedWord)
                    {
                        Console.Write($"Congratulations! You have guesses the word:{selectedWord}");
                        break;
                    }

                    else
                    {
                        attemptsLeft--;
                        Console.WriteLine("Incorrect word guess");
                        continue;
                    }
                }
                
                //If the user repeat the same letter
                if (checkRepeatedWord.Contains(guess))
                {
                    Console.WriteLine("You have already tried this letter.\nTry another one.");
                    continue;
                }
                checkRepeatedWord.Add(guess);

                bool correctGuess = false;

                //substitute the underscore with the guessed leter
                for (int i = 0; i < wordToGuess.Length ; i++) 
                {
                if (wordToGuess[i] == guess) 
                    {
                        guessedLetters[i] = guess;
                        correctGuess = true;
                    }
                }

                //check if the user has guessed the word
                if (correctGuess)
                { 
                     Console.WriteLine("Good guess!!");
                }
                else
                {
                    attemptsLeft--;
                    Console.WriteLine("Incorrect Letter!");
                }

                for (int i = 0; i < guessedLetters.Length; i++)
                {
                    if (guessedLetters[i] == EMPTY_LINE)
                    {
                        missingLetter++;
                    }
                }

                if (new string(guessedLetters) == selectedWord)
                {
                    Console.WriteLine($"Congratulations!\nYou guessed the word;{selectedWord}");
                    break;
                }
            }

            if (attemptsLeft == 0)
                {
                    Console.WriteLine($"Sorry,you are out of attempts.\nthe word was:{selectedWord}");
                }
                Console.WriteLine("Thanks for playing");
                Console.ReadLine();
            
        }
    }
}