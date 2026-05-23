namespace OOP_Assignment_03.Base.Child
{
    internal class StandardTicket : TicketClass
    {
        /*
         . StandardTicket — adds SeatNumber (string).  
           Each child class should override ToString() to include its own extra info.
         */
        public string SeatNumber { get; set; }
        public StandardTicket(string movieName, decimal price, string seatNumber) : base(movieName, price)
        {
            SeatNumber = seatNumber;
        }
        public override string ToString()
        {
            return base.ToString() + $", Seat Number: {SeatNumber}";
        }
    }
}
