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
            int countCows = 0;
            foreach (var digit in guessDigits)
            {
                if (secretDigits.Contains(digit))
                {
                    countCows++;
                }
            }

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