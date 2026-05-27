namespace OOP_Assignment_04
{
    internal class Ticket
    {
        private static int _totalTickets = 0;
        private decimal _price;

        public int TicketId { get; }
        public string MovieName { get; set; }

        public virtual decimal Price
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

        public Ticket(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;
            TicketId = ++_totalTickets;
        }

        public override string ToString()
        {
            return $"Ticket #{TicketId} | {MovieName} | Price: {Price:0} EGP | After Tax: {PriceAfterTax:0.00} EGP";
        }

        public static int GetTotalTickets() => _totalTickets;

        public virtual void PrintTicket()
        {
            Console.WriteLine(ToString());
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public void SetPrice(decimal basePrice, decimal multiplier)
        {
            Price = basePrice * multiplier;
        }
    }
}
