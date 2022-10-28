using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_when_guess_given_digits_are_the_same_as_secrete()
        {
            //given
            var stubSecretGenerator=new Mock<SecretGenerator>();
            stubSecretGenerator.Setup(generator => generator.GenerateSecret())
                .Returns("1 2 3 4");
            var game = new BullsAndCowsGame(stubSecretGenerator.Object);
            //when
            var guessResult = game.Guess("1 2 3 4");

            //then
            Assert.Equal("4A0B", guessResult);
        }
    }
}
