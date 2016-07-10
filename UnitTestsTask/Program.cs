using System;
using System.Globalization;

namespace UnitTestsTask
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            if (!VerifyAccess(username, password))
                Console.WriteLine("Username or password is incorrect!");
            else
            {
                Console.WriteLine("Enter expression to calculate (eg 6 / 2):");
                string exp = Console.ReadLine();
                int i1, i2;
                double d1, d2;
                string sign;

                try
                {
                    if (TryGetIntExpression(exp, out i1, out i2, out sign))
                        Console.WriteLine("Result: {0}", Calculate(i1, i2, sign));
                    else if (TryGetDoubleExpression(exp, out d1, out d2, out sign))
                        Console.WriteLine("Result: {0}", Calculate(d1, d2, sign));
                    else
                        Console.WriteLine("Expression is incorrect!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }

        private static bool VerifyAccess(string username, string password)
        {
            IAccountRepository accountRep = new AccountRepository();
            var permissonResolver = new PermissionResolver(accountRep);
            return permissonResolver.HasAccess(username, password);
        }

        private static bool TryGetIntExpression(string exp, out int num1, out int num2, out string sign)
        {
            var parts = exp.Trim().Split(' ');
            num1 = 0;
            num2 = 0;
            sign = null;

            if (parts.Length != 3 || !Int32.TryParse(parts[0], out num1)
                || !IsMathSign(parts[1]) || !Int32.TryParse(parts[2], out num2))
                return false;

            sign = parts[1];
            return true;
        }

        private static bool TryGetDoubleExpression(string exp, out double num1, out double num2, out string sign)
        {
            char sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            var parts = exp.Replace(sep == '.' ? ',' : '.', sep).Trim().Split(' ');
            num1 = 0;
            num2 = 0;
            sign = null;

            if (parts.Length != 3 || !Double.TryParse(parts[0], out num1)
                || !IsMathSign(parts[1]) || !Double.TryParse(parts[2], out num2))
                return false;

            sign = parts[1];
            return true;
        }

        private static bool IsMathSign(string sign)
        {
            return sign == "+" || sign == "-" || sign == "*" || sign == "/";
        }

        private static T Calculate<T>(T num1, T num2, string sign)
        {
            ICalculator<T> calc = num1 is int ? (ICalculator<T>)new IntCalculator() : (ICalculator<T>)new DoubleCalculator();
            switch (sign)
            {
                case "+":
                    return calc.Sum(num1, num2);
                case "-":
                    return calc.Subtr(num1, num2);
                case "*":
                    return calc.Mult(num1, num2);
                case "/":
                    return calc.Div(num1, num2);
                default:
                    throw new Exception("Incorrect sign.");
            }
        }
    }
}
