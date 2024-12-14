namespace c_sharp_delegate
{//lab ex. 3
    class Program
    {
        static void Main(string[] args)
        {
            
            Predicate<int> predicate = IsEven;
            predicate += IsOdd;
            predicate += IsPrime;
            predicate += IsFibonacci;

            int[] testNumbers = { 2, 3, 4, 5, 6, 13, 21, 22, 34, 35 };

            foreach (var number in testNumbers)
            {
                Console.WriteLine($"Number: {number}");
                TestNumber(predicate, number);
                Console.WriteLine();
            }
        }

        static void TestNumber(Predicate<int> predicate, int number)
        {
            foreach (Predicate<int> item in predicate.GetInvocationList())//.GetInvocationList() returns an array of delegates
            {
                Console.WriteLine(item(number));
            }
        }

        static bool IsEven(int number)
        {
            Console.Write($"Is Even: ");
            return number % 2 == 0;
        }

        static bool IsOdd(int number)
        {
            Console.Write($"Is Odd: ");
            return number % 2 != 0;
        }

        static bool IsPrime(int number)
        {
            Console.Write($"Is Prime: ");
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }

        static bool IsFibonacci(int number)
        {
            Console.Write($"Is Fibonacci: ");
            if (number < 0) return false;
            int a = 0, b = 1, temp;
            while (b < number)
            {
                temp = a + b;
                a = b;
                b = temp;
            }
            return b == number || number == 0;
        }
    }
}

