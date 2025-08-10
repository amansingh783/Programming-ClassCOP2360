using System;

namespace ContractorAppV2
{
    class Contractor
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime StartDate { get; set; }

        public Contractor(string name, int number, DateTime startDate)
        {
            Name = name;
            Number = number;
            StartDate = startDate;
        }
    }

    class Subcontractor : Contractor
    {
        public int Shift { get; set; }
        public double HourlyRate { get; set; }

        public Subcontractor(string name, int number, DateTime startDate, int shift, double hourlyRate)
            : base(name, number, startDate)
        {
            Shift = shift;
            HourlyRate = hourlyRate;
        }

        public double CalcPay()
        {
            double shiftDiff = (Shift == 2) ? 0.03 : 0.0;
            return HourlyRate * (1 + shiftDiff);
        }
    }

    class ContractorProgramV2
    {
        static void Main()
        {
            Console.WriteLine("Enter subcontractor details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            int number;
            Console.Write("Number: ");
            while (!int.TryParse(Console.ReadLine(), out number))
                Console.Write("Invalid number. Try again: ");

            DateTime startDate;
            Console.Write("Start Date (MM/dd/yyyy): ");
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
                Console.Write("Invalid date format. Try again (MM/dd/yyyy): ");

            int shift;
            Console.Write("Shift (1 for day, 2 for night): ");
            while (!int.TryParse(Console.ReadLine(), out shift) || (shift != 1 && shift != 2))
                Console.Write("Invalid shift. Enter 1 for day or 2 for night: ");

            double hourlyRate;
            Console.Write("Hourly Pay Rate: ");
            while (!double.TryParse(Console.ReadLine(), out hourlyRate))
                Console.Write("Invalid rate. Try again: ");

            var subcontractor = new Subcontractor(name, number, startDate, shift, hourlyRate);

            Console.WriteLine($"\nSubcontractor Information:");
            Console.WriteLine($"Name: {subcontractor.Name}");
            Console.WriteLine($"Number: {subcontractor.Number}");
            Console.WriteLine($"Start Date: {subcontractor.StartDate:MM/dd/yyyy}");
            Console.WriteLine($"Shift: {subcontractor.Shift}");
            Console.WriteLine($"Hourly Pay Rate: {subcontractor.HourlyRate:C}");

            double pay = subcontractor.CalcPay();
            Console.WriteLine($"Pay (with shift differential if applicable): {pay:C}");
        }
    }
}