using System;
using Xunit;

namespace NamedRegistrations.Domain.UnitTests
{
    public class CarTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var car = new Car("123");

            // Act
            var vin = car.Vin;

            // Assert
            Assert.Equal("123", vin);
        }
    }
}
