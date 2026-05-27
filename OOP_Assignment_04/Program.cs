using OOP_Assignment_04.child;

namespace OOP_Assignment_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region Part 01 : Theoretical Questions 
            /*
            Q1: What is the difference between static binding and dynamic binding? When does each one happen?
            - Static Binding (Early Binding): The method definition to be executed is determined by the compiler at compile time. 
                                              This happens when you use method overloading, static methods, or normal non-virtual methods.
            - Dynamic Binding (Late Binding): The method to be executed is determined by the runtime environment (like the CLR in C#) at 
                                              runtime based on the actual object type instantiated in memory. This happens when method 
                                              overriding is utilized via inheritance.  

            Q2: What is the difference between method overloading and method overriding? 
            - Method Overloading: This occurs when a single class has multiple methods with the same name but different 
                                  parameters (different types, numbers, or order of parameters). It is a form of compile-time polymorphism.  
            - Method Overriding : This occurs when a child class provides a new, specific implementation for a method that is 
                                  already defined in its parent class. The method signature (name and parameters) must remain 
                                  exactly the same, and it represents runtime polymorphism.  

            Q3: What keywords are used for Method Overriding? What does each one mean ?
                - virtual: Used in the base class to indicate that a method can be optionally overridden by any child classes. 
                - abstract: Used in an abstract base class to indicate a method must be overridden by child classes (it has no body in the base class).  
                - override: Used in the child class to explicitly state that the method is replacing the base class's virtual or abstract implementation.  
                - base: Often used inside the child's overridden method to call the parent class's original implementation, allowing you to add to it rather than completely replacing it.  
            */
            #endregion
            #region Part 02 : Practical (Extending the Movie Ticket Booking System) 
            /* What you need to build : 
                1. Refactor the base Ticket class: 
                    a. Add a PrintTicket() method that prints: TicketId, MovieName, Price, PriceAfterTax. Child classes should be able to provide their 
                     own version of this method. 
                    b. Add two versions of a SetPrice method — one that takes a decimal (sets price directly) and one that takes a decimal base price 
                     and a decimal multiplier (sets price = base × multiplier).

                2. In each child class, provide its own version of PrintTicket(): 
                    a. StandardTicket — prints the base ticket info and the SeatNumber. 
                    b. VIPTicket — prints the base ticket info, LoungeAccess, and ServiceFee. 
                    c. IMAXTicket — prints the base ticket info and whether it is 3D. 

                3. In the Cinema class, update PrintAllTickets() so it loops through the 
                   Ticket[] array and calls PrintTicket() on each one. 

                4. Create a static method ProcessTicket(Ticket t) that takes any Ticket and calls PrintTicket() on it. 

                5. In Main: 
                    a. Create a Cinema and open it. 
                    b. Create one StandardTicket, one VIPTicket, and one IMAXTicket. 
                    c. Test both versions of SetPrice on one ticket. 
                    d. Add all tickets to the Cinema and call PrintAllTickets(). 
                    e. Call ProcessTicket() with one of the tickets. 
                    f. Close the Cinema.*/

            // a. Create a Cinema and open it. 
            Cinema cinema = new Cinema("Cineplex");
            cinema.OpenCinema();

            // b. Create one of each ticket type (hardcoded data) and add them to the Cinema. 
            StandardTicket ticket1 = new StandardTicket("Inception", 120m, "A-5");
            VIPTicket ticket2 = new VIPTicket("Avengers", 200m, true);
            IMAXTicket ticket3 = new IMAXTicket("Dune", 180m, false);

            // c. Test both versions of SetPrice on one ticket. 
            Console.WriteLine("========== SetPrice Test ==========");
            ticket1.SetPrice(150m);
            Console.WriteLine($"Setting price directly: {ticket1.Price:0}");
            ticket1.SetPrice(100m, 1.5m);
            Console.WriteLine($"Setting price with multiplier: 100 x 1.5 = {ticket1.Price:0}");
            Console.WriteLine();

            cinema.AddTicket(ticket1);
            cinema.AddTicket(ticket2);
            cinema.AddTicket(ticket3);

            // d. Print all tickets.
            cinema.PrintAllTickets();

            // e. Call ProcessTicket() with one of the tickets.
            Console.WriteLine("========== Process Single Ticket ==========");
            ProcessTicket(ticket2);
            Console.WriteLine();

            // Print Statistics
            Console.WriteLine("========== Statistics ==========");
            Console.WriteLine($"Total Tickets Created: {Ticket.GetTotalTickets()}");
            Console.WriteLine($"Booking Ref 1: {BookingHelper.GenerateBookingReference()}");
            Console.WriteLine($"Booking Ref 2: {BookingHelper.GenerateBookingReference()}");

            decimal ticketPrice = 100m;
            int groupSize = 5;
            decimal discountedTotal = BookingHelper.CalcGroupDiscount(groupSize, ticketPrice);
            Console.WriteLine($"Group Discount ({groupSize} x {ticketPrice:0} EGP): {discountedTotal:0} EGP (10% off)");
            Console.WriteLine(); // Spacing

            // f. Close the Cinema.
            cinema.CloseCinema();

            #endregion
        }

        public static void ProcessTicket(Ticket t)
        {
            if (t != null)
            {
                t.PrintTicket();
            }
        }
    }
}
