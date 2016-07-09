using System;

namespace UnitTestsTask
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();
            if (!VerifyAccess(username, password))
                Console.WriteLine("Username or password is incorrect!");
            else
            {
                Console.WriteLine("Enter expression to calculate (eg 6 / 2):");
                var exp = Console.ReadLine();
                var num1 = 0;
                var num2 = 0;
                var sign = string.Empty;
                if (!TryGetExpression(exp, out num1, out num2, out sign))
                {
                    Console.WriteLine("Expression is incorrect!");
                    Console.ReadLine();
                    return;
                }
                try
                {
                    Console.WriteLine("Result: {0}", Calculate(num1, num2, sign));
                }
                catch (DivideByZeroException ex)
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

        private static bool TryGetExpression(string exp, out int num1, out int num2, out string sign)
        {
            var parts = exp.Trim().Split(' ');
            num1 = 0;
            num2 = 0;
            sign = null;
            if (parts.Length != 3 || !int.TryParse(parts[0], out num1)
                || !IsMathSign(parts[1]) || !int.TryParse(parts[2], out num2))
                return false;
            sign = parts[1];
            return true;
        }

        private static bool IsMathSign(string sign)
        {
            return sign == "+" || sign == "-" || sign == "*" || sign == "/";
        }

        private static int Calculate(int num1, int num2, string sign)
        {
            var calc = new Calculator();
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
