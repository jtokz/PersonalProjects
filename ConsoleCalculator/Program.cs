namespace ConsoleCalculator
{
    internal class Program
    {
        static double number1 = 0;
        static double number2 = 0;
        static void Main(string[] args)
        {
            home();
        }
        static void home()
        {
            while (true)
            {
                Console.WriteLine("Enter a first number");
                if (double.TryParse(Console.ReadLine(), out number1))
                {
                    Console.WriteLine("Enter a second number");
                    if (double.TryParse(Console.ReadLine(), out number2))
                    {
                        Result();
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                }
            }
        }

        static void Result()
        {
            Console.WriteLine("Enter an operation: +, -, *, /");
            string operation = Console.ReadLine();
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = Sum();
                    break;
                case "-":
                    result = Sub();
                    break;
                case "*":
                    result = Mult();
                    break;
                case "/":
                    result = Div();
                    break;
                default: Console.WriteLine("Not valid operation."); break;
            }
            Console.WriteLine($"Result: {number1} {operation} {number2} = {result}");
        }

        static double Sum()
        {
            return number1 + number2;
        }
        static double Sub()
        {
            return number1 - number2;
        }
        static double Mult()
        {
            return number1 * number2;
        }
        static double Div()
        {
            if (number2 == 0)
            {
                Console.WriteLine("cannot be divided by 0");
                return 0;
            }
            return number1 / number2;
        }
    }
}
