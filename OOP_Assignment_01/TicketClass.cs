namespace OOP_Assignment_01
{
    internal class TicketClass
    {

        public string MovieName { get; set; }
        public TicketType Type { get; set; }
        public SeatLocation Seat { get; set; }
        private double Price { get; set; }
        public TicketClass(string movieName, TicketType type, SeatLocation seat, double price)
        {
            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }

        public TicketClass(string movieName) : this(movieName, TicketType.Standard, new SeatLocation('A', 1), 50.0)
        {
        }

        public double CalcTotal(double taxPercent)
        {
            return Price + (Price * (taxPercent / 100.0));
        }

        public void ApplyDiscount(ref double discountAmount)
        {
            if (discountAmount > 0 && discountAmount <= Price)
            {
                Price -= discountAmount;
                discountAmount = 0.0;
            }
        }
        public void PrintTicket()
        {
            Console.WriteLine($"Movie    : {MovieName}");
            Console.WriteLine($"Type     : {Type}");
            Console.WriteLine($"Seat     : {Seat.Row}{Seat.Number}");
            Console.WriteLine($"Price    : {Price:F2}");
            Console.WriteLine($"Total (14% tax) : {CalcTotal(14):F2}");
        }
    }
}

struct SeatLocation
{

    public char Row { get; set; }
    public int Number { get; set; }
    public SeatLocation(char row, int number)
    {
        Row = row;
        Number = number;
    }
}
enum TicketType
{
    Standard,
    VIP,
    IMAX
}

