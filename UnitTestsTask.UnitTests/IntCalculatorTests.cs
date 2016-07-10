using System;
using NUnit.Framework;

namespace UnitTestsTask.UnitTests
{
    [TestFixture]
    public class IntCalculatorTests
    {
        private IntCalculator intCalc;

        [SetUp]
        public void SetUp()
        {
            intCalc = new IntCalculator();
        }

        [TestCase(4, 7, 11)]
        [TestCase(9, 9, 18)]
        [TestCase(-53, -4, -57)]
        [TestCase(-13, -13, -26)]
        [TestCase(-11, 6, -5)]
        [TestCase(41, -22, 19)]
        [TestCase(0, 3, 3)]
        [TestCase(72, 0, 72)]
        [TestCase(-4, 0, -4)]
        [TestCase(0, -1, -1)]
        [TestCase(0, 0, 0)]
        public void Sum_VariuosInputs_ChecksThem(int num1, int num2, int expected)
        {
            Assert.AreEqual(expected, intCalc.Sum(num1, num2));
        }

        [TestCase(7, 4, 3)]
        [TestCase(9, 9, 0)]
        [TestCase(-53, -4, -49)]
        [TestCase(-13, -13, 0)]
        [TestCase(-11, 6, -17)]
        [TestCase(41, -22, 63)]
        [TestCase(2, 18, -16)]
        [TestCase(-20, -33, 13)]
        [TestCase(-3, 50, -53)]
        [TestCase(1, -20, 21)]
        [TestCase(0, 3, -3)]
        [TestCase(72, 0, 72)]
        [TestCase(-4, 0, -4)]
        [TestCase(0, -1, 1)]
        [TestCase(0, 0, 0)]
        public void Subtr_VariousInputs_ChecksThem(int num1, int num2, int expected)
        {
            Assert.AreEqual(expected, intCalc.Subtr(num1, num2));
        }

        [TestCase(4, 7, 28)]
        [TestCase(9, 9, 81)]
        [TestCase(-13, -3, 39)]
        [TestCase(-7, -7, 49)]
        [TestCase(-11, 6, -66)]
        [TestCase(41, -2, -82)]
        [TestCase(0, 3, 0)]
        [TestCase(72, 0, 0)]
        [TestCase(-4, 0, 0)]
        [TestCase(0, -1, 0)]
        [TestCase(0, 0, 0)]
        public void Mult_VariousInputs_ChecksThem(int num1, int num2, int expected)
        {
            Assert.AreEqual(expected, intCalc.Mult(num1, num2));
        }

        [TestCase(28, 7, 4)]
        [TestCase(9, 9, 1)]
        [TestCase(-12, -3, 4)]
        [TestCase(-7, -7, 1)]
        [TestCase(-12, 6, -2)]
        [TestCase(44, -4, -11)]
        [TestCase(2, 3, 0)]
        [TestCase(-4, -73, 0)]
        [TestCase(0, 3, 0)]
        [TestCase(0, -1, 0)]
        public void Div_GoodVariousInputs_ChecksThem(int num1, int num2, int expected)
        {
            Assert.AreEqual(expected, intCalc.Div(num1, num2));
        }

        [TestCase(72)]
        [TestCase(-4)]
        [TestCase(0)]
        public void Div_DivideByZeroVariousInputs_ThrowsDivideByZeroException(int num1)
        {
            Assert.Catch<DivideByZeroException>(() => intCalc.Div(num1, 0));
        }
    }
}
