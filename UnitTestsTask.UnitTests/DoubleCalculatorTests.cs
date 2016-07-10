using System;
using NUnit.Framework;

namespace UnitTestsTask.UnitTests
{
    [TestFixture]
    public class DoubleCalculatorTests
    {
        private DoubleCalculator doubleCalc;

        [SetUp]
        public void SetUp()
        {
            doubleCalc = new DoubleCalculator();
        }

        [TestCase(4.2, 7.1, 11.3)]
        [TestCase(9.7, 9.7, 19.4)]
        [TestCase(-53.3, -4.0, -57.3)]
        [TestCase(-13.5, -13.5, -27.0)]
        [TestCase(-11.4, 6.2, -5.2)]
        [TestCase(41.5, -22.7, 18.8)]
        [TestCase(0.0, 3.6, 3.6)]
        [TestCase(72.11, 0.0, 72.11)]
        [TestCase(-4.99, 0.0, -4.99)]
        [TestCase(0.0, -1.6, -1.6)]
        [TestCase(0.0, 0.0, 0.0)]
        public void Sum_VariuosInputs_ChecksThem(double num1, double num2, double expected)
        {
            Assert.AreEqual(expected, doubleCalc.Sum(num1, num2));
        }

        [TestCase(7.4, 4.2, 3.2)]
        [TestCase(9.7, 9.7, 0.0)]
        [TestCase(-53.3, -4.0, -49.3)]
        [TestCase(-13.5, -13.5, 0.0)]
        [TestCase(-11.4, 6.2, -17.6)]
        [TestCase(41.5, -22.7, 64.2)]
        [TestCase(2.11, 18.65, -16.54)]
        [TestCase(1.1, -20.02, 21.12)]
        [TestCase(0.0, 3.6, -3.6)]
        [TestCase(72.11, 0.0, 72.11)]
        [TestCase(-4.99, 0.0, -4.99)]
        [TestCase(0.0, -1.6, 1.6)]
        [TestCase(0.0, 0.0, 0.0)]
        public void Subtr_VariousInputs_ChecksThem(double num1, double num2, double expected)
        {
            Assert.AreEqual(expected, doubleCalc.Subtr(num1, num2));
        }

        [TestCase(4.2, 7.1, 29.82)]
        [TestCase(-11.4, 6.2, -70.68)]
        [TestCase(0.0, 3.6, 0.0)]
        [TestCase(72.11, 0.0, 0.0)]
        [TestCase(-4.99, 0.0, 0.0)]
        [TestCase(0.0, -1.6, 0.0)]
        [TestCase(0.0, 0.0, 0.0)]
        public void Mult_VariousInputs_ChecksThem(double num1, double num2, double expected)
        {
            Assert.AreEqual(expected, doubleCalc.Mult(num1, num2));
        }

        [TestCase(29.82, 4.2, 7.1)]
        [TestCase(9.7, 9.7, 1.0)]
        [TestCase(-7.7, -7.7, 1.0)]
        [TestCase(-70.68, 6.2, -11.4)]
        [TestCase(0.0, 3.324, 0.0)]
        [TestCase(0.0, -1.9, 0.0)]
        public void Div_GoodVariousInputs_ChecksThem(double num1, double num2, double expected)
        {
            Assert.AreEqual(expected, doubleCalc.Div(num1, num2));
        }

        [TestCase(72.11)]
        [TestCase(-4.99)]
        [TestCase(0.0)]
        public void Div_DivideByZeroVariousInputs_ThrowsDivideByZeroException(double num1)
        {
            Assert.Catch<DivideByZeroException>(() => doubleCalc.Div(num1, 0));
        }
    }
}
