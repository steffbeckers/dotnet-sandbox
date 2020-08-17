using System;
using Xunit;

namespace Sandbox.Testing.xUnit
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-2, 5, 3)]
        [InlineData(10, -5, 5)]
        [InlineData(10, 5.5, 15.5)]
        public void ShouldAddNumbers(double number1, double number2, double expected)
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double sum = calculator.Add(number1, number2);

            // Assert
            Assert.Equal(expected, sum);
        }
    }
}
