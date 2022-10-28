using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;

        private string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            int countBulls = CountBulls(guess);

            int countCows = CountCows(guess, countBulls);

            return $"{countBulls}A{countCows}B";
        }

        private int CountCows(string guess, int countBulls)
        {
            var guessDigits = guess.Split(" ");
            var secretDigits = secret.Split(" ");
            int countCows = (from digit in guessDigits
                             where secretDigits.Contains(digit)
                             select digit).Count();
            countCows -= countBulls;
            return countCows;
        }

        private int CountBulls(string guess)
        {
            var guessDigits = guess.Split(" ");
            var secretDigits = secret.Split(" ");
            int countBulls = guessDigits.Where((value, index) => value == secretDigits[index]).Count();

            return countBulls;
        }
    }
}