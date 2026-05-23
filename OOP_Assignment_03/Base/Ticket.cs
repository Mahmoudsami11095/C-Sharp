using System;

namespace OOP_Assignment_03.Base
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
            return $"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:0.00} EGP";
        }

        public static int GetTotalTickets() => _totalTickets;
    }
}
