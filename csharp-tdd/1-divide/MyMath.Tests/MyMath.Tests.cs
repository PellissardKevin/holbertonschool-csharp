using NUnit.Framework;

namespace MyMath.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void Divide_DivideMatrixByNumber_ResultCorrect()
        {
            // Arrange
            int[,] matrix = new int[,] { { 4, 6 }, { 8, 10 } };
            int divisor = 2;
            int[,] expectedResult = new int[,] { { 2, 3 }, { 4, 5 } };

            // Act
            int[,] result = Matrix.Divide(matrix, divisor);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Divide_DivideMatrixByZero_ReturnsNull()
        {
            // Arrange
            int[,] matrix = new int[,] { { 4, 6 }, { 8, 10 } };
            int divisor = 0;

            // Act
            int[,] result = Matrix.Divide(matrix, divisor);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Divide_NullMatrix_ReturnsNull()
        {
            // Arrange
            int[,] matrix = null;
            int divisor = 2;

            // Act
            int[,] result = Matrix.Divide(matrix, divisor);

            // Assert
            Assert.IsNull(result);
        }
    }
}
