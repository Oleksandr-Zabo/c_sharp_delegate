namespace c_sharp_delegate
{//lab ex.1 
    internal class Program
    {
        public delegate void MessageDelegate(string message);

        static void Main(string[] args)
        {
            // Create delegate instance and assign them to methods
            MessageDelegate message = DisplayMessage;
            message += PrintMessage;
            message += LogMessage;

            // Invoke the methods through the delegate
            message("Hello, World!");

            Console.ReadLine();
        }

        // Method to display a message on the screen
        static void DisplayMessage(string message)
        {
            Console.WriteLine("DisplayMessage: " + message);
        }

        // Method to print a message
        static void PrintMessage(string message)
        {
            Console.WriteLine("PrintMessage: " + message);
        }

        // Method to log a message
        static void LogMessage(string message)
        {
            Console.WriteLine("LogMessage: " + message);
        }
    }
}

