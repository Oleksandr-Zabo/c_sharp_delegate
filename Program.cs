namespace c_sharp_delegate
{
    // hw ex. 1
    public delegate bool NumberPredicate(int number);

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 3, 4, 5, 6, 13, 21, 22, 34, 35 };

            NumberPredicate isEven = IsEven;
            NumberPredicate isOdd = IsOdd;
            NumberPredicate isPrime = IsPrime;
            NumberPredicate isFibonacci = IsFibonacci;

            var evenNumbers = FilterArray(numbers, isEven);
            var oddNumbers = FilterArray(numbers, isOdd);
            var primeNumbers = FilterArray(numbers, isPrime);
            var fibonacciNumbers = FilterArray(numbers, isFibonacci);

            Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));
            Console.WriteLine("Odd Numbers: " + string.Join(", ", oddNumbers));
            Console.WriteLine("Prime Numbers: " + string.Join(", ", primeNumbers));
            Console.WriteLine("Fibonacci Numbers: " + string.Join(", ", fibonacciNumbers));
        }

        static int[] FilterArray(int[] array, NumberPredicate predicate)
        {
            var result = new List<int>();
            foreach (var number in array)
            {
                if (predicate(number))
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }

        static bool IsFibonacci(int number)
        {
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
