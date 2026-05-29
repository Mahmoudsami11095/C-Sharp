namespace OOP_Assignment_05.Child
{
    internal class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }

        public StandardTicket(string movieName, decimal price, string seatNumber) : base(movieName, price)
        {
            SeatNumber = seatNumber;
        }

        public override string ToString()
        {
            return $"[Ticket #{TicketId}] {MovieName} | Standard | Seat: {SeatNumber} | Price: {Price:0} | After Tax: {PriceAfterTax:0.#} | Booked: {(IsBooked ? "Yes" : "No")}";
        }
    }
}
