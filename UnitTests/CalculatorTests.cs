namespace UnitTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(4, 5, 9)]
        public void Sum_ReturnsExpectedResult(double number1, double number2, double expectedResult)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.Sum(number1, number2);
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(20, 10, 2)]
        [InlineData(15, 3, 5)]
        public void Divide_ReturnsExpectedResult(int numerator, int denominator, int expectedResult)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var result = calculator.Divide(numerator, denominator);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void Divide_ThrowsDivideByZeroException()
        {
            // Arrange
            var calculator = new Calculator();
            var numerator = 10;
            var denominator = 0;
            // Act and Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(numerator, denominator));
        }
        [Theory]
        [MemberData(nameof(DataForAverageTests))]
        public void Average_ReturnsExpectedResult(List<double> numberList, double expectedResult)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.Average(numberList);
            //Assert
            Assert.Equal(expectedResult, result);
        }
        public static IEnumerable<object[]> DataForAverageTests()
        {
            yield return new object[] { new List<double> { 1, 2, 3, 4, 5 }, 3 };
            yield return new object[] { new List<double> { 10, 15, 20 }, 15 };
            yield return new object[] { new List<double> { -5, -10, -15 }, -10 };
        }
    }
}