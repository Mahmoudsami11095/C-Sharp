namespace OOP_Assignment_05
{
    internal class Ticket : IPrintable, IBookable, ICloneable
    {
        private static int _totalTickets = 0;
        private decimal _price;

        public int TicketId { get; private set; }
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

        public bool IsBooked { get; private set; }

        public Ticket(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;
            TicketId = ++_totalTickets;
        }

        public override string ToString()
        {
            return $"[Ticket #{TicketId}] {MovieName} | Price: {Price:0} | After Tax: {PriceAfterTax:0.#} | Booked: {(IsBooked ? "Yes" : "No")}";
        }

        public static int GetTotalTickets() => _totalTickets;

        public virtual void PrintTicket()
        {
            Print();
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
            if (!IsBooked)
            {
                IsBooked = true;
            }
            else
            {
                throw new InvalidOperationException($"Ticket #{TicketId} is already booked.");
            }
        }

        public void Cancel()
        {
            if (IsBooked)
            {
                IsBooked = false;
            }
            else
            {
                throw new InvalidOperationException($"Ticket #{TicketId} is not booked, so it cannot be canceled.");
            }
        }

        public virtual object Clone()
        {
            Ticket clone = (Ticket)this.MemberwiseClone();
            clone.TicketId = ++_totalTickets;
            clone.IsBooked = false;
            return clone;
        }
    }
}
