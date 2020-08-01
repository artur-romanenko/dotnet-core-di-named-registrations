namespace NamedRegistrations.Domain.Services
{
    public interface IEngineValidator
    {
        bool IsEngineInAGoodCondition(string engineCondition);
    }

    public class EngineValidator : IEngineValidator
    {
        public bool IsEngineInAGoodCondition(string engineCondition)
        {
            // Complex engine validation logic
            return engineCondition != Car.BadEngine;
        }
    }
}
