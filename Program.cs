namespace c_sharp_delegate
{//lab ex. 4
    public delegate double CalcDelegate(double x, double y);

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.Write("Enter an expression: ");
            string? expression = Console.ReadLine();
            if (expression == null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            char sign = ' ';

            foreach (char item in expression)
            {
                if (item == '+' || item == '-' || item == '*')
                {
                    sign = item;
                    break;
                }
            }
            try
            {
                string[] numbers = expression.Split(sign);
                CalcDelegate? del = null;
                switch (sign)
                {
                    case '+':
                        del = new CalcDelegate(calc.Add);
                        break;
                    case '-':
                        del = new CalcDelegate(Calculator.Sub);
                        break;
                    case '*':
                        del = calc.Mult;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                Console.WriteLine($"Result: {del(double.Parse(numbers[0]), double.Parse(numbers[1]))}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
