namespace OOP_Assignment_05.Child
{
    internal class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; set; } = 50m;

        public override decimal Price
        {
            get => base.Price + ServiceFee;
            set => base.Price = value;
        }

        public VIPTicket(string movieName, decimal price, bool loungeAccess) : base(movieName, price)
        {
            LoungeAccess = loungeAccess;
        }

        public override string ToString()
        {
            return $"[Ticket #{TicketId}] {MovieName} | VIP | Lounge: {(LoungeAccess ? "Yes" : "No")} | Fee: {ServiceFee:0} | Price: {Price:0} | After Tax: {PriceAfterTax:0.#} | Booked: {(IsBooked ? "Yes" : "No")}";
        }
    }
}
