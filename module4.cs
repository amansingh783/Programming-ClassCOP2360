    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            string num1String = Console.ReadLine();

            Console.WriteLine("Enter the second number:");
            string num2String = Console.ReadLine();

            PerformDivision(num1String, num2String);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        public static void PerformDivision(string num1Str, string num2Str)
        {
            try
            {
                int num1 = Convert.ToInt32(num1Str);
                int num2 = Convert.ToInt32(num2Str);

                int result = num1 / num2;
                Console.WriteLine($"Result of division: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Invalid input format. Please enter valid integers. Details: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: Cannot divide by zero. Details: {ex.Message}");
            }
            catch (OverflowException ex) // Handling for numbers too large
            {
                Console.WriteLine($"Error: One of the numbers is too large for an integer. Details: {ex.Message}");
            }
            catch (Exception ex) // Catch-all for any other unexpected exceptions
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }