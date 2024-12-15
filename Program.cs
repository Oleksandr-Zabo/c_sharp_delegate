using System;
namespace c_sharp_delegate
{//hw ex-2
    internal class Program
    {
        static void Main()
        {
            // method for displaying current time
            Action display = DisplayCurrentTime;//Action - delegate, який не приймає параметрів і не повертає значення(void)
            display += DisplayCurrentDate;
            display += DisplayCurrentDayOfWeek;

            // calling methods
            display();

            Console.WriteLine();

            // Func - delegate, який приймає один або більше параметрів і повертає значення
            Func<double, double, double> calculateArea = CalculateTriangleArea;//Func<T1, T2, ..., TResult> - delegate, який приймає один або більше параметрів і повертає значення (TResult)
            calculateArea += CalculateRectangleArea;

            // calling methods and calculating areas
            double baseLength = 5.0;
            double height = 3.0;
            double width = 4.0;

            double triangleArea = 0, rectangleArea = 0;

            foreach (Func<double, double, double> method in calculateArea.GetInvocationList())
            {
                if (method == CalculateTriangleArea)
                {
                    triangleArea = method(baseLength, height);
                }
                else if (method == CalculateRectangleArea)
                {
                    rectangleArea = method(width, height);
                }

            }

            Console.WriteLine($"Area of the triangle: {triangleArea}");
            Console.WriteLine($"Area of the rectangle: {rectangleArea}");

            Console.WriteLine();

            // Method for checking if a number is positive
            Predicate<double> isPositive = IsPositive;// Predicate<T> - delegate, який приймає один параметр і повертає значення типу bool

            Console.WriteLine($"Is {baseLength} positive? {isPositive(baseLength)}");
            Console.WriteLine($"Is {-width} positive? {isPositive(-width)}");
        }

        static void DisplayCurrentTime()
        {
            Console.WriteLine("Current Time: " + DateTime.Now.ToLongTimeString());
        }

        static void DisplayCurrentDate()
        {
            Console.WriteLine("Current Date: " + DateTime.Now.ToShortDateString());
        }

        static void DisplayCurrentDayOfWeek()
        {
            Console.WriteLine("Current Day of the Week: " + DateTime.Now.DayOfWeek);
        }

        static double CalculateTriangleArea(double baseLength, double height)
        {
            return 0.5 * baseLength * height;
        }

        static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }

        static bool IsPositive(double number)
        {
            return number > 0;
        }
    }
}


