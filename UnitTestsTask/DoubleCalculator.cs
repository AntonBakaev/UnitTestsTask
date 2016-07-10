using System;

namespace UnitTestsTask
{
    public class DoubleCalculator : ICalculator<double>
    {
        public double Sum(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtr(double num1, double num2)
        {
            return num1 - num2;
        }
        public double Mult(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Div(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException();
            return num1 / num2;
        }
    }
}
