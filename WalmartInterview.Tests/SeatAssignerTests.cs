using Xunit;

namespace WalmartInterview.Tests
{
    public class SeatAssignerTests
    {
        [Fact]
        public void NextSeat()
        {
            var assigner = new SeatAssigner(numberOfColumns: 20, numberOfRows: 20);
            Assert.Equal("A1", assigner.NextSeat());
            Assert.Equal("A2", assigner.NextSeat());
        }

        [Fact]
        public void NextAssignment()
        {
            var assigner = new SeatAssigner(numberOfColumns: 10, numberOfRows: 20);
            Assert.Equal(new[] { "A1", "A2", "A3" }, assigner.NextAssignment(3));
            Assert.Equal(new[] { "A7", "A8", "A9", "A10" }, assigner.NextAssignment(4));
            Assert.Equal(new[] { "B1", "B2", "B3", "B4", "B5" }, assigner.NextAssignment(5)); // Starting on a new row
            Assert.Equal(new[] { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" }, assigner.NextAssignment(10)); // Number of seats is equal to theater width
        }
    }
}
