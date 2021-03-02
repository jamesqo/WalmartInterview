using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WalmartInterview
{
    class Program
    {
        static void Fail(string message)
        {
            Console.Error.WriteLine(message);
            Environment.Exit(1);
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Fail("Usage: dotnet run [path_to_input_file]");
            }

            // Read in the input file

            string inputFile = args[0];
            var lines = File.ReadAllLines(inputFile);

            var reservations = new List<(string, int)>(); // We're using this instead of a Dictionary to maintain insertion order
            for (int i = 0; i < lines.Length; i++)
            {
                // Read in one reservation per line

                string line = lines[i];
                var parts = line.Split(' ');
                if (parts.Length != 2) Fail($"Invalid reservation format: {line}");

                string reservationId = parts[0];
                string numberOfSeatsText = parts[1];
                if (!int.TryParse(numberOfSeatsText, out int numberOfSeats)) Fail($"Invalid number of seats: {numberOfSeatsText}");

                reservations.Add((reservationId, numberOfSeats));
            }

            // Assign seats

            var assignments = new List<(string, IEnumerable<string>)>();
            var assigner = new SeatAssigner(numberOfColumns: 20, numberOfRows: 10);
            foreach (var (reservationId, numberOfSeats) in reservations)
            {
                assignments.Add((reservationId, assigner.NextAssignment(numberOfSeats)));
            }
            
            // Generate the output file

            var output = new StringBuilder();
            foreach (var (reservationId, assignment) in assignments)
            {
                output.Append(reservationId).Append(" ").Append(string.Join(",", assignment)).AppendLine();
            }
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "assignments.txt");
            File.WriteAllText(outputFile, output.ToString());
            Console.WriteLine(outputFile);
        }
    }
}
