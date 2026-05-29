namespace OOP_Assignment_05
{
    internal class Ticket : IPrintable, IBookable, ICloneable
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

        public bool IsBoooked { get; private set; }

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

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public void Book()
        {
            if (!IsBoooked)
            {
                IsBoooked = true;
                Console.WriteLine($"Ticket #{TicketId} has been booked.");
            }
            else
            {
                Console.WriteLine($"Ticket #{TicketId} is already booked.");
            }
        }

        public void Cancel()
        {
            if (IsBoooked)
            {
                IsBoooked = false;
                Console.WriteLine($"Ticket #{TicketId} booking has been canceled.");
            }
            else
            {
                Console.WriteLine($"Ticket #{TicketId} is not booked, so it cannot be canceled.");
            }
        }

        public object Clone()
        {
            return new Ticket(this.MovieName, this.Price);
        }
    }
}
