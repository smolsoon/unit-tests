using System;
using Xunit;
using Calculator;

namespace Calculators.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void adding_two_values()
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var existingValue = calc.Adding(4,5);
            //Assert
            Assert.Equal(9,existingValue);

        }
    }
}
