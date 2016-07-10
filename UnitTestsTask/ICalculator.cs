namespace UnitTestsTask
{
    public interface ICalculator<T>
    {
        T Sum(T num1, T num2);
        T Subtr(T num1, T num2);
        T Mult(T num1, T num2);
        T Div(T num1, T num2);
    }
}
