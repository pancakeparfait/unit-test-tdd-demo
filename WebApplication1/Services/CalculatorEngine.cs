namespace WebApplication1.Services
{
    public class CalculatorEngine : ICalculatorEngine
    {
        public decimal Add(decimal firstValue, decimal secondValue)
        {
            return firstValue + secondValue;
        }
    }
}