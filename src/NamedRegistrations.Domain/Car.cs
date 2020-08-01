using System;

namespace NamedRegistrations.Domain
{
    public class Car
    {
        public const string GoodEngine = "Good";
        public const string BadEngine = "Bad";

        public Car(string vin, CarType type, string engineCondition = GoodEngine, int wheels = 4)
        {
            if (string.IsNullOrWhiteSpace(vin))
                throw new ArgumentNullException(vin);

            if (vin.Length < 3)
                throw new ArgumentException("VIN length is invalid.", nameof(vin));

            Vin = vin;
            Type = type;
            EngineCondition = engineCondition;
            Wheels = wheels;
        }

        public string Vin { get; private set; }
        
        public CarType Type { get; private set; }

        public string EngineCondition { get; private set; }

        public int Wheels { get; private set; }
    }
}
