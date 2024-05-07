using NUnit.Framework;
using MyMath;
using System.Collections.Generic;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Max_ReturnsMaxInteger_WhenListHasOneElement()
        {
            // Arrange
            List<int> nums = new List<int> { 5 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Max_ReturnsMaxInteger_WhenListHasMultipleElements()
        {
            // Arrange
            List<int> nums = new List<int> { 2, 8, 4, 10, 6 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Max_ReturnsZero_WhenListIsEmpty()
        {
            // Arrange
            List<int> nums = new List<int>();

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Max_ReturnsCorrectValue_WhenListHasNegativeIntegers()
        {
            // Arrange
            List<int> nums = new List<int> { -5, -2, -8, -1 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
