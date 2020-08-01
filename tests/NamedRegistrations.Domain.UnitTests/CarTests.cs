using System;
using Xunit;

namespace NamedRegistrations.Domain.UnitTests
{
    public class CarTests
    {
        [Fact]
        public void Car_ShouldBeInitializedWithGoodEngineAndFourWheels()
        {
            // Arrange
            var car = new Car("123", CarType.Coupe);

            // Act
            var vin = car.Vin;
            var type = car.Type;
            var engine = car.EngineCondition;
            var wheels = car.Wheels;

            // Assert
            Assert.Equal("123", vin);
            Assert.Equal(CarType.Coupe, type);
            Assert.Equal(Car.GoodEngine, engine);
            Assert.Equal(4, wheels);
        }
    }
}
