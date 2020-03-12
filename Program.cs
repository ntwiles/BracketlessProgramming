using System;

class Program
{
    static void Main(string[] args)
    {
        int maxNumGuesses = 10;
        Random rand = new Random();
        int secretNum = rand.Next(1, maxNumGuesses);

        int guess = 0;
        int guessesMade = 0;
        bool gameWon = false;

        int getGuess() => Int32.TryParse(Console.ReadLine(), out int result) ? result : getGuess();
        (int guess, int, bool gameWon) checkGuessEqual() => (guess = getGuess(), guessesMade++, gameWon = guess == secretNum ? true : false);
        void doRound() => Console.WriteLine(checkGuessEqual().gameWon ? 
            "You won! "+ (maxNumGuesses - guessesMade) + " guesses left." : 
            guess > secretNum ? 
            "Too high! "+(maxNumGuesses - guessesMade) + " guesses left." : 
            "Too low! "+(maxNumGuesses - guessesMade) + " guesses left.",
            maxNumGuesses - guessesMade);

        Console.WriteLine("# from 1-10. Guess:");

        while (guessesMade < maxNumGuesses && !gameWon) doRound();

        if (guessesMade == maxNumGuesses) Console.WriteLine("Game over!");
        Console.ReadKey();
    }
}

