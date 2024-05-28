using System;
using System.IO;

namespace Lab0_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable to hold user input
            string input;
            int low_num = -1;

            // Loop until a valid low number (non-negative) is entered
            while (low_num < 0)
            {
                Console.Write("Enter the low number: ");
                input = Console.ReadLine();

                // Try to parse the input string to an integer
                if (Int32.TryParse(input, out low_num) && low_num >= 0)
                {
                    Console.WriteLine($"The user typed the {input} number.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid non-negative integer.");
                    low_num = -1; // Reset low_num to keep the loop going
                }
            }

            int high_num = low_num;

            // Loop until a valid high number (greater than low_num) is entered
            while (high_num <= low_num)
            {
                Console.Write("\nEnter the high number: ");
                input = Console.ReadLine();

                // Try to parse the input string to an integer
                if (Int32.TryParse(input, out high_num) && high_num > low_num)
                {
                    Console.WriteLine($"The user typed the {input} number.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer greater than the low number.");
                    high_num = low_num; // Reset high_num to keep the loop going
                }
            }

            // List to store prime numbers
            var primes = new System.Collections.Generic.List<int>();

            // Populate the list with prime numbers from low_num to high_num - 1
            for (int i = low_num; i < high_num; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            // Print each prime number in the list
            foreach (int prime in primes)
            {
                Console.WriteLine($"Prime: {prime}");
            }

            string file_path = @"C:\CPRG211 -E\demotwoassign0\demotwoassign0\numbers.txt";

            // Write the prime numbers in reverse order to the file
            using (StreamWriter writer = new StreamWriter(file_path))
            {
                for (int i = primes.Count - 1; i >= 0; i--)
                {
                    writer.WriteLine(primes[i]);
                }
            }
        }

        // Method to check if a number is prime
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
