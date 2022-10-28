using BullsAndCows;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_return_4_digit_number_when_generat_secret()
        {
            //given
            var secretGenerator = new SecretGenerator();
            //when
            string secret = secretGenerator.GenerateSecret();
            //then
            Assert.Equal(4, secret.Split(" ").Length);
        }

        [Fact]
        public void Should_return_4_random_different_digit_number_when_generat_secret()
        {
            //given
            var mockRandom = new Mock<Random>();
            mockRandom.SetupSequence(random => random.Next(It.IsAny<int>()))
                .Returns(1).Returns(1).Returns(5).Returns(3).Returns(5).Returns(4).Returns(9).Returns(1);
            var secretGenerator = new SecretGenerator(mockRandom.Object);
            //when
            string secret = secretGenerator.GenerateSecret();
            //then
            Assert.Equal("1 5 3 4", secret);
        }
    }
}
