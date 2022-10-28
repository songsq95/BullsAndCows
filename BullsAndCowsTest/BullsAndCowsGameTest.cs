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
            var stubSecretGenerator = new Mock<SecretGenerator>();
            stubSecretGenerator.Setup(generator => generator.GenerateSecret())
                .Returns("1 2 3 4");
            var game = new BullsAndCowsGame(stubSecretGenerator.Object);
            //when
            var guessResult = game.Guess("1 2 3 4");

            //then
            Assert.Equal("4A0B", guessResult);
        }


        [Theory]
        [InlineData("1 2 3 4", "1 2 5 6")]
        [InlineData("1 2 3 4", "5 2 3 6")]
        [InlineData("1 2 3 4", "5 6 3 4")]
        public void Should_return_2A0B_when_guess_given_2_digits_value_position_same_as_secrete_parameters(string secret, string guess)
        {
            //given
            var stubSecretGenerator = new Mock<SecretGenerator>();
            stubSecretGenerator.Setup(generator => generator.GenerateSecret())
                .Returns(secret);
            var game = new BullsAndCowsGame(stubSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guess);

            //then
            Assert.Equal("2A0B", guessResult);
        }

        [Fact]
        public void Should_return_1A1B_when_guess_given_2_digits_value_1_digit_position_same_as_secret()
        {
            //given
            var stubSecretGenerator = new Mock<SecretGenerator>();
            stubSecretGenerator.Setup(generator => generator.GenerateSecret())
                .Returns("1 2 3 4");
            var game = new BullsAndCowsGame(stubSecretGenerator.Object);
            //when
            var guessResult = game.Guess("1 3 5 6");

            //then
            Assert.Equal("1A1B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 4 5 6", "1A1B")]
        [InlineData("1 2 3 4", "2 3 4 1", "0A4B")]
        [InlineData("1 2 3 4", "5 6 7 8", "0A0B")]
        [InlineData("1 2 3 4", "3 4 5 6", "0A2B")]
        public void Should_return_right_result_when_guess_given_4_digits(string secret, string guess, string expected)
        {
            //given
            var stubSecretGenerator = new Mock<SecretGenerator>();
            stubSecretGenerator.Setup(generator => generator.GenerateSecret())
                .Returns(secret);
            var game = new BullsAndCowsGame(stubSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guess);

            //then
            Assert.Equal(expected, guessResult);
        }
    }
}
