using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        private const int SecreteLength = 4;
        private Random random;
        public SecretGenerator()
        {
            random = new Random();
        }

        public SecretGenerator(Random random)
        {
            this.random = random;
        }

        public virtual string GenerateSecret()
        {
            var secretList = new List<int>();
            for (int length = 0; length < 4;)
            {
                int secretNumber = random.Next(10);
                if (!secretList.Contains(secretNumber))
                {
                    secretList.Add(secretNumber);
                    length++;
                }
            }

            return string.Join(" ", secretList);
        }
    }
}