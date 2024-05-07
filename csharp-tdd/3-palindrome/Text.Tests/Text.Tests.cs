using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void IsPalindrome_ReturnsTrue_WhenStringIsPalindrome()
        {
            // Arrange
            string palindrome = "Racecar";

            // Act
            bool result = Str.IsPalindrome(palindrome);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_ReturnsTrue_WhenStringIsPalindromeWithSpacesAndPunctuation()
        {
            // Arrange
            string palindromeWithSpacesAndPunctuation = "A man, a plan, a canal: Panama.";

            // Act
            bool result = Str.IsPalindrome(palindromeWithSpacesAndPunctuation);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_ReturnsFalse_WhenStringIsNotPalindrome()
        {
            // Arrange
            string notPalindrome = "hello";

            // Act
            bool result = Str.IsPalindrome(notPalindrome);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPalindrome_ReturnsTrue_WhenStringIsEmpty()
        {
            // Arrange
            string emptyString = "";

            // Act
            bool result = Str.IsPalindrome(emptyString);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_ReturnsTrue_WhenStringIsSingleCharacter()
        {
            // Arrange
            string singleChar = "a";

            // Act
            bool result = Str.IsPalindrome(singleChar);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
