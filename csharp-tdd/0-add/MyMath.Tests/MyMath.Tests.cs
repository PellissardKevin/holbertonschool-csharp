using NUnit.Framework;

namespace MyMath.Tests
{
    public class OperationsTests
    {
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
