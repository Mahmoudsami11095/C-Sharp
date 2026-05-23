using OOP_Assignment_03.Base;

namespace OOP_Assignment_03
{
    internal class Program
    {
        /*
          In Main, do the following: 
            a. Create a Cinema and open it. 
            b. Create one of each ticket type (hardcoded data) and add them to the Cinema. 
            c. Print all tickets. 
            d. Close the Cinema. 
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            #region Part 01 : Theoretical Questions Q1
            /*
                Q1 : Identify the type of relationship in each scenario below (Inheritance, Association, Aggregation, Composition, or Dependency): 
                a) A University has Departments. If the university is closed, the departments no longer exist.
                     Composition: This is a strong "death" relationship. If the university is closed and the departments no longer exist, the departments are entirely dependent on the university's lifecycle.
                b) A Driver uses a Car. The driver does not own the car. 
                     Association: This is a "uses-a" relationship where both objects have independent lifecycles. The driver uses the car but does not own it.
                c) A Dog is an Animal. 
                     Inheritance: This is an "is-a" relationship, establishing a parent-child hierarchy where a dog inherits the traits of an animal.
                d) A Team has Players. If the team is deleted, the players still exist. 
                     Aggregation: This is a weak "has-a" relationship. The team contains players, but if the team is deleted, the players still exist independently.
                e) A method receives a Logger as a parameter and calls it inside the method only.
                     Dependency: The method relies on the Logger temporarily to do its job. Because it is received as a parameter and used only inside the method, the class depends on it without owning it.
            */
            #endregion
            #region Part 01 : Theoretical Questions Q2
            /*
                Q2 : Answer the following questions about access modifiers and sealed: 
                a) A parent class has a protected field. Can a child class in a different assembly access it? What about through an object instance from outside? 
                     Protected Access: A child class in a different assembly can access a parent's protected field, but only from within the child class itself (via inheritance). However, you cannot access it through an object instance from the outside. To the outside world, protected acts exactly like private.

                b) What is the difference between protected internal and private protected? 
                   protected internal vs. private protected: protected internal is an OR condition; the member is accessible from any class within the same assembly OR from a derived class in any assembly. private protected is an AND condition; it is only accessible from derived classes IF they are also in the same assembly.

                c) What does the sealed keyword do when applied to a class? What about when applied to a method? 
                   The sealed keyword: When applied to a class, sealed prevents the class from being inherited by any other class. When applied to an overridden method, it prevents that specific method from being overridden any further in deeper derived classes.

                d) Can you create an object from a sealed class using new? Why or why not? 
                   Instantiating sealed classes: Yes, you can create an object from a sealed class using new. The sealed keyword only restricts inheritance, not instantiation.
            */
            #endregion
            #region Part 02 : Practical (Extending the Movie Ticket Booking System) 
            // a.Create a Cinema and open it. 
            CinemaClass cinema = new("Default Cinema Name");
            cinema.OpenCinema();
            // b. Create one of each ticket type (hardcoded data) and add them to the Cinema. 
            TicketClass ticket = new("Zoz", 500);
            cinema.AddTicket(ticket);
            // c. Print all tickets.
            cinema.PrintAllTickets();
            // d.Close the Cinema.
            cinema.CloseCinema();
            #endregion
        }
    }
}
