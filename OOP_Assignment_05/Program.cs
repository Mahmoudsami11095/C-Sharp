using OOP_Assignment_05.Child;
using System;

namespace OOP_Assignment_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema("City Center");
            cinema.OpenCinema();

            StandardTicket t1 = new StandardTicket("Inception", 80m, "A5");
            VIPTicket t2 = new VIPTicket("Avengers", 150m, true);
            IMAXTicket t3 = new IMAXTicket("Dune", 100m, true);

            t1.Book();
            t2.Book();
            t3.Book();

            cinema.AddTicket(t1);
            cinema.AddTicket(t2);
            cinema.AddTicket(t3);

            cinema.PrintAllTickets();

            Console.WriteLine("--- Clone Test ---");
            VIPTicket clonedTicket = (VIPTicket)t2.Clone();
            clonedTicket.MovieName = "Interstellar";
            Console.WriteLine($"Original : {t2}");
            Console.WriteLine($"Clone : {clonedTicket}");
            Console.WriteLine();

            t1.Cancel();
            Console.WriteLine("--- After Cancellation ---");
            t1.Print();
            Console.WriteLine();

            Console.WriteLine("--- BookingHelper.PrintAll ---");
            IPrintable[] printables = new IPrintable[] { t1, t2, t3 };
            BookingHelper.PrintAll(printables);
            Console.WriteLine();

            cinema.CloseCinema();
            #region Part 01: Theoretical Questions Q1  
            /*
             * Q1: What is an interface in C#?    
               - An interface in C# is a contract that defines a set of methods, properties, events, or indexers without providing any implementation details. 
             * Why do we use interfaces instead of depending on concrete classes directly? 
               - to decouple our systems, allowing components to interact based on agreed-upon contracts rather than strict dependencies on specific implementations.  
             * Mention at least three benefits.
               - Multiple Inheritance of Behavior: While C# classes can only inherit from a single base class, they can implement multiple interfaces, allowing a class to adopt multiple distinct behaviors.
               - Loose Coupling and Flexibility: Interfaces allow developers to swap out underlying implementations without breaking the code that consumes them.
               - Testability: Interfaces make it easy to create mock objects for unit testing, isolating the components being tested.
            */
            #endregion
            #region Part 01: Theoretical Questions Q2 : Interface Implementation Problem
            /*  Look at the following code and answer the questions below:
            interface IEnglishSpeaker
            {
                void Greet();
            }
            interface IArabicSpeaker
            {
                void Greet();
            }
            class Translator : IEnglishSpeaker, IArabicSpeaker
            {
                public void Greet()
                {
                    Console.WriteLine("Hello / Ahlan");
                }
            }
            a) What is the problem with this design? Both interfaces have a method called Greet() — how does the class handle it currently? 
            - The problem is a naming collision. Because both IEnglishSpeaker and IArabicSpeaker define a method with the exact same signature (void Greet()), the Translator class implements it implicitly. A single Greet() method currently satisfies both interfaces, meaning the object cannot provide distinct behaviors for English and Arabic greetings.
            b) How would you fix this so IEnglishSpeaker.Greet() says "Hello" and IArabicSpeaker.Greet() says "Ahlan"? What is this technique called? 
            - To fix this, you must use Explicit Interface Implementation. You implement the methods by prepending the interface name to the method name.
            class Translator : IEnglishSpeaker, IArabicSpeaker
            {
                void IEnglishSpeaker.Greet()
                {
                    Console.WriteLine("Hello");
                }

                void IArabicSpeaker.Greet()
                {
                    Console.WriteLine("Ahlan");
                }        
            }
            c) After applying your fix, can you call Greet() directly on a Translator object (e.g. translator.Greet())? Why or why not? How do you call each version? 
            - No, you cannot call translator.Greet() directly.Explicitly implemented members are intentionally hidden from the class's default public interface to avoid ambiguity. To call them, you must first cast the object to the specific interface:
            Translator translator = new Translator();
            ((IEnglishSpeaker)translator).Greet(); // Outputs: Hello
            ((IArabicSpeaker)translator).Greet();  // Outputs: Ahlan
            */
            #endregion
            #region Part 01: Theoretical Questions Q3 : Shallow Copy vs. Deep Copy
            /*
             * Q3 : Explain the difference between a shallow copy and a deep copy?
             - Shallow Copy:Creates a new object and copies the non-static fields of the current object into the new one. 
               If a field is a value type, a bit-by-bit copy is performed. If a field is a reference type, the reference is copied, 
               but the referenced object is not. Both the original and the clone will point to the same object in memory
             - Deep Copy: Creates a completely new object and recursively creates new copies of all objects referenced by the original object's fields. 
               The clone and the original are entirely independent.
             * When would you use each one? 
             - You would use a shallow copy when you want to create a new instance of an object but are okay with shared references to mutable data. 
               A deep copy is necessary when you need to ensure that changes to the copied object do not affect the original object, 
               especially when dealing with complex objects that contain references to other objects.
             * What is the risk of using a shallow copy when the object has reference-type fields? 
             - Risk: The primary risk of a shallow copy with reference-type fields is unintended side effects. If you modify the mutable reference-type data in the copied object, 
               those changes will reflect in the original object because they share the same memory reference
             */
            #endregion
            #region  Part 01: Theoretical Questions Q4 : Code Output Analysis
            /* Look at the following code and determine the output. Explain why. 
            class Department { public string Name; }
                    class Employee
                    {
                        public string Title;
                        public Department Dept;
                        public Employee ShallowCopy() => (Employee)this.MemberwiseClone();
                    }
                    var e1 = new Employee { Title = "Dev", Dept = new Department { Name = "IT" } };
                    var e2 = e1.ShallowCopy();
                    e2.Title = "QA"; 
            e2.Dept.Name = "Testing"; 
            Console.WriteLine($"{e1.Title} - {e1.Dept.Name}"); 
            Console.WriteLine($"{e2.Title} - {e2.Dept.Name}");
            
            Output:
            Dev - Testing
            QA - Testing
            Explanation:
            - The ShallowCopy() method uses MemberwiseClone(), which creates a shallow copy of the Employee object.  
            The Title field is a string (which behaves like a value type in terms of immutability). 
            Changing e2.Title to "QA" only affects e2.  The Dept field is a reference to a Department object. 
            The shallow copy means e1.Dept and e2.Dept point to the exact same Department instance in memory. 
            When e2.Dept.Name is changed to "Testing", it modifies the shared object, causing e1 to also reflect "Testing".              
            */
            #endregion

        }
    }
}
