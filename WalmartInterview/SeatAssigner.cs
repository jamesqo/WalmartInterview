using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WalmartInterview
{
    public class SeatAssigner
    {
        private int _columnIndex = 0;
        private int _rowIndex = 0;

        public SeatAssigner(int numberOfColumns, int numberOfRows)
        {
            NumberOfColumns = numberOfColumns;
            NumberOfRows = numberOfRows;
        }

        public int NumberOfColumns { get; }
        public int NumberOfRows { get; }

        public string NextSeat()
        {
            Debug.Assert(_columnIndex < NumberOfColumns);
            Debug.Assert(_rowIndex < NumberOfRows);

            char rowLetter = (char)(_rowIndex + 'A');
            int columnNumber = _columnIndex + 1;
            string seat = $"{rowLetter}{columnNumber}";

            if (_columnIndex == NumberOfColumns - 1)
            {
                _columnIndex = 0;
                _rowIndex++;
            }
            else
            {
                _columnIndex++;
            }

            return seat;
        }

        public IEnumerable<string> NextAssignment(int numberOfSeats)
        {
            // If we're not starting on a new row, we have to add a gap of 3 seats from the previous assignment
            if (_columnIndex != 0)
            {
                _columnIndex += 3;
                // Can we fit the reservation into the remaining seats on this row?
                if (_columnIndex + numberOfSeats > NumberOfColumns)
                {
                    _columnIndex = 0;
                    _rowIndex++;

                    if (_rowIndex == NumberOfRows)
                    {
                        // No more assignments available
                        return Array.Empty<string>();
                    }
                }
            }

            var result = new List<string>();
            for (int i = 0; i < numberOfSeats; i++)
            {
                result.Add(NextSeat());
            }
            return result;
        }
    }
}
