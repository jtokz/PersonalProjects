namespace MeterToFoot
{
    class Program
    {
        public static double amountInput = 0;
        static void Main(string[] args)
        {
            home();
        }

        public static void home()
        {
            while (true)
            {
                Console.WriteLine("Length you want to convert from meters to foot:");
                AmountInFoots();
                Console.WriteLine("Do you want to convert another length? (y/n)");
                string response = Console.ReadLine(); 
                if (response.ToLower() != "y")
                {
                    Console.WriteLine("Thanks for using me!");
                    break; // Exiting to the loop
                }
            }
        }
        public static void AmountInFoots()
        {
            double AmountInFoots = 0;
            if (double.TryParse(Console.ReadLine(), out amountInput))
            {
                AmountInFoots = (amountInput * 3.28084);
                Console.WriteLine($"Your {amountInput} meter are {AmountInFoots} foot n.n");
            } else
            {
                Console.WriteLine("Enter a valid number");
            }
        }
    }
}
