using NUnit.Framework;

namespace MyMath.Tests
{
    /// <summary>
    /// Tests for the Operations class
    /// </summary>
    public class OperationsTests
    {
        /// <summary>
        /// Tests the Add operation on two valid integer arguments
        /// </summary>
        [Test]
        public void Add_AddsTwoNumbers_CorrectResult()
        {
            // Arrange
            int a = 5;
            int b = 7;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(12, result);
        }
    }
}
