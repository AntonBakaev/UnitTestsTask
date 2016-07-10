namespace UnitTestsTask
{
    public class IntCalculator : ICalculator<int>
    {
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Subtr(int num1, int num2)
        {
            return num1 - num2;
        }

        public int Mult(int num1, int num2)
        {
            return num1 * num2;
        }

        public int Div(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}
