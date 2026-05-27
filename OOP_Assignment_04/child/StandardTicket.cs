namespace OOP_Assignment_04.child
{
    internal class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }

        public StandardTicket(string movieName, decimal price, string seatNumber) : base(movieName, price)
        {
            SeatNumber = seatNumber;
        }

        public override void PrintTicket()
        {
            Console.WriteLine(base.ToString());
            Console.WriteLine($"  Seat: {SeatNumber}");
        }
    }
}
