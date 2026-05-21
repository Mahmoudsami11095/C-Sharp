namespace OOP_Assignment_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            #region Part 01 : Theoretical Questions Q1
            /*Q1 : Consider the following class: 
                public class BankAccount
                {
                    public string Owner;
                    public double Balance;

                    public void Withdraw(double amount)
                    {
                        Balance -= amount;
                    }
                }

              a) Identify at least two problems with this design from an encapsulation perspective. 
                - Lack of Data Protection: The Balance field is public, meaning anyone can modify it directly from outside the class (e.g., account.Balance = -5000;). This bypasses the Withdraw method completely.
                - No Validation: The Withdraw method lacks business logic. It does not check if the withdrawal amount is greater than the available Balance, nor does it prevent negative withdrawals (which would essentially deposit money).

              b) Describe how you would fix this class to follow proper encapsulation principles. You do not need to write the full code. 
                public class BankAccount
                {
                    public string Owner { get; private set; }
                    public double Balance { get; private set; }

                    public BankAccount(string owner, double initialBalance)
                    {
                        Owner = owner;
                        Balance = initialBalance > 0 ? initialBalance : 0;
                    }

                    public void Withdraw(double amount)
                    {
                        if (amount > 0 && amount <= Balance)
                        {
                            Balance -= amount;
                        }
                    }
                }

            c) Explain why exposing fields directly (as public) is considered a bad practice in OOP.*/
            /*
             * Exposing fields directly breaks encapsulation, which is the core principle of hiding internal state. 
             * If a field is public, you lose control over how and when the data is changed. 
             * Furthermore, if you ever need to add validation or trigger an event when a value changes in the future, 
             * you would have to change the field to a property, which breaks the class's public contract (API) and forces recompilation of any code using it.
             */
            #endregion
            #region Part 02 : Theoretical Questions Q2
            /*
             Q02 : What is the difference between a field and a property in C#? 
                   - Difference: A field is simply a variable declared directly in a class or struct 
                     that stores data. A property is a member that provides a flexible mechanism to read, 
                     write, or compute the value of a private field using get and set accessors. 
                     Properties look like fields to the outside world but act like methods internally.

                   Can a property contain logic? 
                   - Can a property contain logic? Yes, properties can contain logic inside their get and 
                     set blocks (e.g., validation checks, formatting, or mathematical calculations).

                   Give an example of a read-only property that returns a calculated value. 
                   - public class Rectangular
                     {
                        public double Width {get; set;}
                        public double Height {get; set;}

                        // read-only calculated property
                        public double Area
                        {
                            get { return Width * Height; }
                        }
                     }

             */
            #endregion
            #region Part 01 : Theoretical Questions Q3
            /*
             * Q3: Look at the following code and answer the questions below:
                   public class StudentRegister
                    {
                        private string[] names = new string[5];
                    
                        public string this[int index]
                        {
                            get { return names[index]; }
                            set { names[index] = value; }
                        }
                    }
             * a) What is `this[int index]` called? Explain its purpose.
                  It is called an Indexer. It allows instances of a class to be indexed and accessed just 
                  like arrays (e.g., myRegister[0] = "Ahmed";).
             * b) What happens if someone writes `register[10] = "Ali";` ?
                  How would you make the indexer safer? 
                  - What happens if someone writes register[10] = "Ali"? The program will throw an IndexOutOfRangeException 
                    because the underlying array names only has a length of 5 (valid indices are 0 through 4).
                  - To make the indexer safer, you can add bounds checking inside the set accessor to ensure that the index is within the valid range before attempting to access the array.
                    public string this[int index]
                    {
                        get
                        {
                            if (index >= 0 && index < names.Length) return names[index];
                            return null; // Or throw a custom exception
                        }
                        set
                        {
                            if (index >= 0 && index < names.Length) names[index] = value;
                        }
                    }
             * c) Can a class have more than one indexer? 
                  If yes, give an example of when that would be useful. 
                  - Yes, this is called indexer overloading. You can define multiple indexers as long as their signatures (the parameter types) differ. 
                    For example, a class could have one indexer that takes an int to search by position, and another indexer that takes a string to search by a name or ID.
             */
            #endregion
            #region Part 01 : Theoretical Questions Q4
            /*
             * Q4 : Consider the following code and answer the questions below: 
             *      public class Order
                    {
                        public static int TotalOrders = 0;
                        public string Item;
                    
                        public Order(string item)
                        {
                            Item = item;
                            TotalOrders++;
                        }
                    }
                    a) What does the `static` keyword mean on `TotalOrders`? How is it different from the `Item` field? 
                       - The static keyword means that the TotalOrders field belongs to the class itself, not to any specific instance (object) of the class. 
                         There is only one shared copy of TotalOrders in memory for all Order objects. In contrast, Item is an instance field, meaning every distinct Order object has its own separate Item variable.
                    b) Can a static method inside `Order` access the `Item` field directly? Why or why not
                       - No. A static method does not operate on a specific instance of the class (it has no this reference). 
                         Because Item requires an actual object to exist, the static method wouldn't know which object's Item to read or modify.
            */
            #endregion
            #region Part 02 : Practical (Extending the Movie Ticket Booking System) 

            // a. Ask the user to enter data for 3 tickets (movie name, ticket type, seat row, seat number, price). 
            //Create each Ticket and add it to the Cinema . 
            CinemaClass cinema = new CinemaClass();
            Console.WriteLine("Welcome to the Movie Ticket Booking System!");
            Console.WriteLine("Please enter details for 3 tickets:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Ticket {i + 1}:");
                Console.Write("Movie Name: ");
                string movieName = Console.ReadLine() ?? "";

                Console.Write("Ticket Type (0=Standard, 1=VIP, 2=IMAX): ");
                TicketType type = TicketType.Standard;
                string typeInput = Console.ReadLine() ?? "Standard";
                if (!Enum.TryParse<TicketType>(typeInput, true, out type))
                {
                    if (int.TryParse(typeInput, out int numericType) && Enum.IsDefined(typeof(TicketType), numericType))
                    {
                        type = (TicketType)numericType;
                    }
                }

                Console.Write("Seat Row (A-Z): ");
                string rowInput = Console.ReadLine() ?? "A";
                char seatRow = rowInput.Length > 0 ? rowInput[0] : 'A';

                Console.Write("Seat Number: ");
                if (!int.TryParse(Console.ReadLine(), out int seatNumber))
                {
                    seatNumber = 1;
                }

                Console.Write("Price: ");
                if (!double.TryParse(Console.ReadLine(), out double price))
                {
                    price = 0.0;
                }

                TicketClass ticket = new TicketClass
                (
                    movieName,
                    type,
                    new SeatLocation { Row = seatRow, Number = seatNumber },
                    price
                );
                cinema.AddTicket(ticket);
            }

            //b. Print all 3 tickets (access by index 0, 1, 2) showing: TicketId, MovieName, Type, Seat, Price, and PriceAfterTax. 
            Console.WriteLine("\n============ All Tickets ===========");

            for (int i = 0; i < 3; i++)
            {
                TicketClass? ticket = cinema[i];
                if (ticket != null)
                {
                    ticket.PrintTicket();
                }
            }
            //c. Ask the user for a movie name and search for it. Print the result or a "not found" message. 
            Console.WriteLine("\n============ Search for a movie ===========");
            Console.Write("Movie Name to search: ");
            string moviesearchName = Console.ReadLine() ?? "";
            TicketClass? foundTicket = cinema.GetMovieByName(moviesearchName);
            if (foundTicket != null)
            {
                Console.Write("Found: ");
                foundTicket.PrintTicket();
            }
            else
            {
                Console.WriteLine("not found");
            }

            Console.WriteLine("\n============ Statistics ============");
            //d. Print the total tickets sold using the method.
            Console.WriteLine($"Total Tickets Sold: {TicketClass.GetTotalTicketsSold()}");

            //e. Generate and print 2 booking references. 
            Console.WriteLine($"Booking Reference 1: {BookingHelperClass.GenerateBookingReference()}");
            Console.WriteLine($"Booking Reference 2: {BookingHelperClass.GenerateBookingReference()}");

            //f. Calculate and print the group discount for a group of 5 tickets at 80 EGP each of them.
            double groupDiscount = BookingHelperClass.CalcGroupDiscount(5, 80);
            Console.WriteLine($"Group Discount (5 tickets x 80 EGP): {groupDiscount} EGP (10% off applied)");

            #endregion

        }
    }
}
