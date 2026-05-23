namespace OOP_Assignment_03.Base
{
    internal class TicketClass
    {
        /*
         1. Create a base class Ticket with: 
            a. MovieName (string), Price (decimal, must be > 0), TicketId (int, read-only, auto-incremented). 
            b. A constructor that takes movieName and price. 
            c. A computed property PriceAfterTax that returns the price with 14% tax. 
            d. Override ToString() to return the ticket info. 
            e. A static int GetTotalTickets() method that returns the total number of tickets created. 
         */
        private static int _totalTickets = 0;
        private decimal _price;
        public int TicketId { get; }
        public string MovieName { get; set; }
        public decimal Price
        {
            get => _price;
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentException("Price must be a positive value.");
                }
            }
        }
        public decimal PriceAfterTax => Price * 1.14m;

        public TicketClass(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;
            TicketId = ++_totalTickets;
        }


        public override string ToString()
        {
            return $"Ticket ID: {TicketId}, Movie: {MovieName}, Price: {Price:C}, Price After Tax: {PriceAfterTax:C}";
        }

        public static int GetTotalTickets() => _totalTickets;
    }
}
