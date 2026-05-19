namespace OOP_Assignment_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            #region Part 01 : Theoretical Questions 
            //Part 01 :  
            //Q1: Explain with code example how class and struct behave differently
            // class is a Reference Type: It is allocated on the Heap. When you assign an object to a new variable, you are just copying the memory address (the reference). Both variables point to the exact same data.
            // struct is a Value Type: It is typically allocated on the Stack.When you assign a struct to a new variable, C# creates a completely new, independent copy of the data.

            Console.WriteLine("Class vs Struct Example:");
            PointStruct pointStructA = new PointStruct() { x = 10, y = 20 };
            PointStruct pointStructB = pointStructA; // This creates a copy of pointStructA
            pointStructB.x = 30; // Modifying pointStructB does not affect pointStructA
            pointStructB.y = 40; // Modifying pointStructB does not affect pointStructA
            Console.WriteLine($"PointStructA: x = {pointStructA.x}, y = {pointStructA.y}"); // Output: x = 10, y = 20
            Console.WriteLine($"PointStructB: x = {pointStructB.x}, y = {pointStructB.y}"); // Output: x = 30, y = 40

            PointClass pointClassA = new PointClass() { x = 10, y = 20 };
            PointClass pointClassB = pointClassA; // This copies the reference, both pointClassA and pointClassB refer to the same object
            pointClassB.x = 30; // Modifying pointClassB also affects pointClassA
            pointClassB.y = 40; // Modifying pointClassB also affects pointClassA
            Console.WriteLine($"PointClassA: x = {pointClassA.x}, y = {pointClassA.y}"); // Output: x = 30, y = 40
            Console.WriteLine($"PointClassB: x = {pointClassB.x}, y = {pointClassB.y}"); // Output: x = 30, y = 40

            //Q2 : Explain the difference between public and private access modifiers with an example.
            // access modifiers control who is allowed to see and use the variables and methods inside a class
            // Public: it can be accessed from anywhere in the code. This means that any other class or method can use that member without any restrictions.
            // Private: it can only be accessed from within the same class. This means that other classes or methods cannot directly access or modify that member. private member can only be accessed by code that lives inside that exact same class.
            Console.WriteLine("\nPublic vs Private Access Modifiers Example:");
            MyClass myClass = new MyClass();
            myClass.PublicMethod(); // This is allowed, as PublicMethod is public
                                    // myClass.PrivateMethod(); // This will cause a compile-time error, as PrivateMethod is private

            //Q3 : Describe the steps to create and use a class library in Visual Studio.
            // Phase 1: Create the Class Library
            //Launch Visual Studio and click Create a new project.
            //In the search box, type Class Library.
            //Select the Class Library template that has the C# tag and click Next.
            //Name your project(e.g., StringUtilities), choose a location, and name the Solution(e.g., LibraryDemo). Click Next.
            //Select your Target Framework(e.g., .NET 8.0) and click Create.
            //Visual Studio will generate a project with a default file named Class1.cs.

            // Phase 2: Write the Library Code
            // For other projects to use the code inside your library, the classes and methods must be marked as public (tying back to our earlier access modifier discussion).
            // Rename Class1.cs to something meaningful, like TextHelper.cs (Visual Studio will ask if you want to rename all references; click Yes).
            // Add some simple logic to the class

            // Phase 3: Create a Project to Use the Library
            // To test it, we need a separate application. The easiest way is to add a Console App to your current Solution.
            // In the Solution Explorer(usually on the right side), right - click the top-level Solution 'LibraryDemo' node.
            // Navigate to Add > New Project...
            // Search for and select Console App(C#), then click Next.
            // Name it ConsoleFrontEnd and click Next / Create.

            // Phase 4: Add the Project Reference
            // Right now, the Console App has no idea the Class Library exists.You have to explicitly link them.
            // In the Solution Explorer, look under your ConsoleFrontEnd project.
            // Right - click on Dependencies and select Add Project Reference...
            // A window will pop up. Check the box next to your StringUtilities project and click OK.

            // Phase 5: Call the Library from your App
            // Now you can write code in your Console App that utilizes the logic locked inside your Class Library.
            // Open the Program.cs file in your ConsoleFrontEnd project.
            // Add a using directive at the top to import the library's namespace, then call the method:

            //Q4 : What is a class library? Why do we use class libraries?
            /*
             * A class library is a collection of compiled code—classes, interfaces, structs, and methods—that is packaged together into a single file. 
             * In the C# and .NET world, this file is typically a .dll (Dynamic Link Library).
                Unlike a Console App or a Web App, a class library cannot run on its own. 
            It does not have an entry point (like a Main() method). 
            Instead, it acts as a toolkit or a "code repository" that other applications pull from and use.*/

            // Why do we use class libraries?
            // Code Reusability
            // Separation of Concerns(Modularity)
            // Easier Maintenance and Updates
            // Team Collaboration
            // Sharing with the World
            #endregion

            #region Part 02 :  Movie Ticket Booking System

            /* 
               User Story: You're building a simple Movie Ticket Booking System for a cinema. The system manages ticket types, seat 
               locations, pricing, and payments. Build it as a Console Application that reads data from the user and prints the 
               booking summary. 
               what you need to build : 

               1. Each ticket has a type that can only be one of: Standard, VIP, or IMAX. How 
               would you represent this? 

               2. You need a type to represent a seat location (Row as a char like 'A', 'B', and 
               Number as an int). Should this be a class or a struct? Create it. 

               3. Create a Ticket class with:  
                    a. MovieName (public),  
                    b. Type (public) 
                    c. Seat (public) 
                    d. Price (private).  

               Sometimes a ticket is created with all info, sometimes with just the movie  
               name (default type Standard, seat A1, price 50). Handle both without 
               repeating initialization logic. 

               4. Add three methods to the Ticket class: 
                    a. CalcTotal() — receives a taxPercent (double), calculates the total 
                    after tax and returns it. The original price must stay unchanged. 
                    b. ApplyDiscount() — receives a discountAmount (double) . If discount 
                    is valid (> 0 and ≤ Price), deducts it from Price and sets 
                    discountAmount to 0 (consumed). Otherwise, the discount stays 
                    unchanged. 
                    c. PrintTicket() — prints the full ticket info. 
                    Create a Console Application. Read the ticket data from the 
                    user, then print the following output: 

                Expected Output:
                            Enter Movie Name: Inception 
                Enter Ticket Type (0 = Standard , 1 = VIP , 2 = 
                IMAX ): 2 
                Enter Seat Row (A, B, C...): B 
                Enter Seat Number: 5 
                Enter Price: 200 
                Enter Discount Amount: 30 
                  
                ===== Ticket Info ===== 
                Movie    : Inception 
                Type     : IMAX 
                Seat     : B5 
                Price    : 200.00 
                Total (14% tax) : 228.00 
                  
                ===== After Discount ===== 
                Discount Before : 30.00 
                Discount After  : 0.00 
                Movie    : Inception 
                Type     : IMAX 
            */

            Console.WriteLine("\nMovie Ticket Booking System:");

            Console.Write("Enter Movie Name: ");
            string movieName = Console.ReadLine() ?? "Inception";

            Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
            TicketType ticketType = (TicketType)Enum.Parse(typeof(TicketType), Console.ReadLine() ?? "Standard");

            Console.Write("Enter Seat Row (A, B, C...): ");
            char seatRow = char.Parse(Console.ReadLine() ?? "A");

            Console.Write("Enter Seat Number: ");
            int seatNumber = int.Parse(Console.ReadLine() ?? "1");

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine() ?? "50");

            Console.Write("Enter Discount Amount: ");
            double discountAmount = double.Parse(Console.ReadLine() ?? "0");

            TicketClass ticketClass = new TicketClass(movieName, ticketType, new SeatLocation(seatRow, seatNumber), price);

            Console.WriteLine();
            Console.WriteLine("===== Ticket Info =====");
            ticketClass.PrintTicket();

            Console.WriteLine();
            Console.WriteLine("===== After Discount =====");
            double discountBefore = discountAmount;
            ticketClass.ApplyDiscount(ref discountAmount);
            Console.WriteLine($"Discount Before : {discountBefore:F2}");
            Console.WriteLine($"Discount After  : {discountAmount:F2}");
            ticketClass.PrintTicket();
            #endregion
        }
    }
}
