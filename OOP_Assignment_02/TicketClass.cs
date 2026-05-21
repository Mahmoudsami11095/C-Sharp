namespace OOP_Assignment_02
{
    internal class TicketClass
    {
        /*
         In Assignment 01, you built a basic Movie Ticket Booking System with a Ticket class, a SeatLocation struct, and a TicketType enum. Now you will 
         improve and extend that system using encapsulation, properties, indexers, and static members. 
         What you need to build : 
         1. Refactor the Ticket class to use proper encapsulation: 
            a. Create public properties for each field with the following validation rules: 
             • MovieName : cannot be null or empty. If an invalid value is set, keep the previous value. 
             • Type : use the TicketType enum from Assignment 01 (no special validation needed). 
             • Seat : use the SeatLocation struct from Assignment 01 (no special validation needed). 
             • Price : must be greater than 0. If an invalid value is set, keep the previous value. 
            b. Add property `PriceAfterTax` that returns the price with 14% tax included (calculated, not stored). 
        
         2. Add a static field and a static method to the Ticket class: 
            a. Add a ’ticketCounter’ field that starts at 0. 
            b. Add a ‘TicketId’ property. Each ticket gets a unique ID automatically when created (increment `ticketCounter` in the 
               constructor and assign it to the ID). 
            c. Add a ‘GetTotalTicketsSold()’  method that returns the current value of `ticketCounter`. 
        
         3. Create a `Cinema` class that holds up to 20 tickets using a private array. Add the following: 
            a. Allow User To get and set tickets by index if the index is out of range, the getter returns null and the setter does nothing. 
            b. Allow User To Get Movie By movieName that returns the first ticket found matching the given movie name, or null if not found. 
            c. A method `AddTicket(Ticket t)` that adds a ticket to the first available (null) slot. Returns true if added, false if the cinema is full. 
        
         4. Create a static utility class called `BookingHelper` with the following static methods: 
            a. ` double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)` That returns total price with a 10% discount if the group has 5 or more tickets, otherwise returns the full total. 
            b. ` string GenerateBookingReference()` That returns a unique string each time it is called (e.g., "BK-1", "BK-2", "BK-3", ...). Use a private static counter internally. 
        
         5. In your `Main` method, build a Console Application that does the following: 
            a. Ask the user to enter data for 3 tickets (movie name, ticket type, seat row, seat number, price). Create each Ticket and add it to the Cinema . 
            b. Print all 3 tickets (access by index 0, 1, 2) showing: TicketId, MovieName, Type, Seat, Price, and PriceAfterTax. 
            c. Ask the user for a movie name and search for it. Print the result or a "not found" message. 
            d. Print the total tickets sold using the method. 
            e. Generate and print 2 booking references . 
            f. Calculate and print the group discount for a group of 5 tickets at 80 EGP each of them. 
        */
        // Static Fields
        private static int ticketCounter = 0;

        // Private backing fields for validation
        private string _movieName = "Unknown";
        private double _price = 0;

        // Public properties with validation
        public TicketType Type { get; set; }
        public SeatLocation Seat { get; set; }
        public string MovieName
        {
            get => _movieName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _movieName = value;
                }
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }
        // Calculated Property
        public double PriceAfterTax => Price + Price * .14;

        public int TicketId { get; private set; }
        public TicketClass(string movieName, TicketType type, SeatLocation seat, double price)
        {
            ticketCounter++;
            TicketId = ticketCounter;
            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }

        public TicketClass(string movieName) : this(movieName, TicketType.Standard, new SeatLocation('A', 1), 50.0)
        {
        }

        public static int GetTotalTicketsSold() => ticketCounter;

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
            Console.WriteLine($"Ticket #{TicketId} | {MovieName} | {Type} | Seat: {Seat.Row}-{Seat.Number} | Price: {Price} EGP | After Tax: {PriceAfterTax} EGP");
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

