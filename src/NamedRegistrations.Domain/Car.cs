using System;

namespace NamedRegistrations.Domain
{
    public class Car
    {
        public Car(string vin)
        {
            if (string.IsNullOrWhiteSpace(vin))
                throw new ArgumentNullException(vin);

            if (vin.Length < 3)
                throw new ArgumentException("VIN length is invalid.", nameof(vin));

            Vin = vin;
        }

        public string Vin { get; private set; }
    }
}
