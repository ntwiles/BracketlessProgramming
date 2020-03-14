using System;

public class Program
{
    static int maxNumGuesses = 10;
    static int maxSecretNum = 100;
    static int secretNum = new Random().Next(1, maxSecretNum);

    static int guess = 0;
    static int guessesMade = 0;
    static bool gameWon = false;

    static int getGuess() => Int32.TryParse(Console.ReadLine(), out int result) ? result : getGuess();

    static (int guess, int, bool gameWon) checkGuessEqual() => (guess = getGuess(), guessesMade++, gameWon = guess == secretNum);

    static (bool, int guessesMade) doRound() => (
        Console.WriteLine(
                checkGuessEqual().guess > secretNum ? 
                    "Too high! " + (maxNumGuesses - guessesMade) + " guesses left." :
                guess < secretNum ? 
                    "Too low! " + (maxNumGuesses - guessesMade) + " guesses left." :
                    "That's it!"
        ) is object,guessesMade);

    static bool sayHello() => Console.WriteLine("I have a secret number from 1 to "+ maxSecretNum + ". Guess:") is object;

    static bool sayGoodbye() => Console.WriteLine(gameWon ? "You won!" : "Game over.") is object;

    static void Main(string[] args) => Console.WriteLine("", sayHello(), gameLoop(), sayGoodbye(), Console.ReadKey());

    static int gameLoop() => doRound().guessesMade >= maxNumGuesses || gameWon ? 0 : gameLoop();
}



