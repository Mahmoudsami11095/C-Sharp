using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpAssignment
{
    class Program
    {
        // Class-level field for scope demonstrations
        static int classField = 100;

        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           C# FUNDAMENTALS - ASSIGNMENT WITH ANSWERS                ║");
            Console.WriteLine("║                      20 Questions                                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");



            #region Question 1: Regions
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 2: REGIONS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is the purpose of #region and #endregion directives in C#? 
            //    How do they help in code organization?
            //
            //•	Purpose: #region / #endregion let you group and collapse/expand related code in the editor for readability and navigation. 
            //    They do not affect compilation or runtime behavior.
            //•	Use: Good for organizing long classes(e.g., properties, helpers, nested code).
            // ══════════════════════════════════════════════════════════════════════

            //Nested Region Example

            Console.WriteLine("\n" + new string('-', 70) + "\n");
            #region Nested Example
            // Nested regions are also allowed; they help group sub-sections.
            Console.WriteLine("  -> Nested region active");
            #endregion
            #endregion

            #region Question 2: Variable Declaration - Explicit vs Implicit
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 3: VARIABLE DECLARATION - EXPLICIT VS IMPLICIT
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is the difference between explicit and implicit variable 
            //    declaration in C#? Provide examples of both.
            //
            // ══════════════════════════════════════════════════════════════════════



            // EXPLICIT DECLARATION 
            // •	Explicit declaration: you write the type explicitly.Example: int count = 5;
            // •	Pros:   immediately clear type, required when no initializer is available. 
            int explicitInt = 42;
            Console.WriteLine($"explicitInt (explicit): value={explicitInt}, type={explicitInt.GetType()}");

            // IMPLICIT DECLARATION 
            // •	Implicit declaration(var): compiler infers the type from the initializer.Example: var count = 5;
            // •	Pros: reduces verbosity, required for anonymous types.
            // •	Rules: var requires an initializer and the type is determined at compile time(not dynamic).
            var implicitInt = 42;
            Console.WriteLine($"implicitInt (var): value={implicitInt}, type={implicitInt.GetType()}");

            #endregion

            #region Question 3: Constants
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 4: CONSTANTS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Write the syntax for declaring a constant in C#. Why would you use 
            //    a constant instead of a regular variable?
            //
            // ══════════════════════════════════════════════════════════════════════
            // Syntax and short explanation
            // •	Declaration syntax: const <type> < Identifier > = < compile - time - constant >;
            // •	Rules: must be initialized where declared, value must be a compile - time constant(primitives, string, enums), and const members are implicitly static.
            // Why use const instead of a regular variable
            // •	Immutability: value cannot change after compilation.
            // •	Performance / clarity: communicates intent that the value never varies.
            // •	Compile - time constant: the compiler can inline the value.
            // •	Gotcha: const values are baked into referencing assemblies — change a library const and consumers must be recompiled.Use static readonly for runtime / Version - friendly constants.

            // Constant examples
            const double Pi = 3.141592653589793;
            // class-level readonly for values determined at runtime or to avoid versioning issues
            //public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
        #endregion

            #region Question 4: Class-level vs Method-level Scope
        // ══════════════════════════════════════════════════════════════════════
        // QUESTION 4: CLASS-LEVEL VS METHOD-LEVEL SCOPE
        // ══════════════════════════════════════════════════════════════════════
        //
        // Q: Explain the difference between class-level scope and method-level 
        //    scope with examples.
        //
        // ══════════════════════════════════════════════════════════════════════

        // •	Class-level scope:
        //    •	Declared at the class level(fields/properties). Accessible from any method in the class (subject to access modifiers). Lifetime is the instance or application domain(for static).
        //    •	Use for state that multiple methods must share: static for application-wide, instance fields for per-object state.
        // •	Method-level scope:
        //    •	Local variables declared inside a method. Visible only inside that method (and only inside the block where declared). Lifetime is the method invocation.
        //    •	Use for temporary values and to avoid shared mutable state.

        
        // static int classField = 100;

        Console.WriteLine("Class-level vs Method-level scope demo:");

        // Accessing class-level (field) from Main
        Console.WriteLine($"classField (class-level): {classField}");
        
        // Method-level local variable
        int localInMain = 5;
                Console.WriteLine($"localInMain (method-level): {localInMain}");
        
        // Block-level local variable (visible only inside this if-block)
        if (true)
        {
            int blockVar = 99;
                Console.WriteLine($"blockVar (block-level): {blockVar}");
            }
            // Console.WriteLine(blockVar); // <-- compile error: 'blockVar' does not exist in this context

            // Trying to access a method-level/local variable from another method would fail:
            // For example, a separate method cannot read 'localInMain' because it's local to `Main`.
            // Attempting to do so will produce a compile-time error.


            #endregion

            #region Question 5: Block-level Scope
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 5: BLOCK-LEVEL SCOPE
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is block-level scope? Give an example showing a variable that 
            //    is only accessible within a specific block.
            //
            // ══════════════════════════════════════════════════════════════════════

            //•	Definition: Block - level scope means a variable declared inside a pair of braces { ... }
            //     is only visible inside that block(including nested inner blocks).It is created when execution
            //     enters the block and ceases to exist when execution leaves the block.
            //•	Why it matters: block - level scope prevents accidental reuse or modification of temporaries and
            //  limits lifetime to the smallest necessary region.

            // Q5: Block-level scope demonstration

            Console.WriteLine("Block-level scope demo:");

            // Variable declared inside an if-block — visible only inside that block
            if (true)
            {
                int insideIf = 10;
                Console.WriteLine($"insideIf (inside if): {insideIf}");
            }
            // Console.WriteLine(insideIf); // Compile error: 'insideIf' does not exist in this context

            // Loop variable is block-scoped to the for-loop
            for (int i = 0; i < 3; i++)
            {
                string loopMsg = $"iteration {i}";
                Console.WriteLine(loopMsg);
            }
            // Console.WriteLine(loopMsg); // Compile error: 'loopMsg' does not exist in this context

            // Exception block example
            try
            {
                int temp = 5;
                Console.WriteLine($"temp in try: {temp}");
            }
            catch (Exception)
            {
                // 'temp' is not visible here because it was declared in the try block
                // Console.WriteLine(temp); // Compile error
            }
            #endregion

            #region Question 6: Variable Lifetime - Local vs Static
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 6: VARIABLE LIFETIME - LOCAL VS STATIC
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is variable lifetime? Explain the lifetime of local variables 
            //    vs static variables.
            //
            // ══════════════════════════════════════════════════════════════════════
            // •	Local variables
            //      •	Created when execution reaches their declaration(usually when a method/ block executes) and cease to exist when execution leaves that scope(or when they are no longer reachable).
            //      •	Value - type locals typically use stack storage; reference - type locals hold references on the stack but the actual object is on the heap.
            //      •	Heap objects referenced only by locals become eligible for GC once there are no reachable roots(JIT and last - use analysis can affect exact lifetime).
            //      •	Captured locals(closures) are lifted to the heap and their lifetime is extended beyond the method call until no delegates reference them.
            // •	Static variables(type - level)
            //      •	One storage location per type; created when the type is first loaded / initialized and remain for the lifetime of the AppDomain / process(until type unload or process exit).
            //      •	Treated as GC roots(so referenced objects stay alive while the static reference exists).
            //      •	Shared across all calls/ instances — changes persist between method calls.

            // Local variable resets each call
            void ShowLocal()
            {
                int local = 0;
                local++;
                Console.WriteLine($"ShowLocal local = {local}"); // prints 1 each call
            }

            ShowLocal();
            ShowLocal();

            // Class-level/static field persists across calls (classField declared at top of file)
            Console.WriteLine($"classField before = {classField}");
            classField++;
            Console.WriteLine($"classField after  = {classField}");

            // Closure example: captured local is lifted to the heap and survives after method/block returns
            Func<int> MakeCounter()
            {
                int captured = 0;
                return () => ++captured; // 'captured' lives on while the delegate exists
            }

            var counter = MakeCounter();
            Console.WriteLine(counter()); // 1
            Console.WriteLine(counter()); // 2
            #endregion

            #region Question 7: Garbage Collector
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 7: GARBAGE COLLECTOR
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is the Garbage Collector in C#? How does it affect the 
            //    lifetime of objects?
            //
            // ══════════════════════════════════════════════════════════════════════
            //•	Short definition: the Garbage Collector(GC) is the.NET runtime component that automatically reclaims memory for managed objects that are no longer reachable from any GC root.It manages the managed heap, tracks object reachability, runs finalizers, and frees memory so you don’t have to manually call free / delete.
            // •	How it affects object lifetime(concise):
            // •	Reachability determines lifetime: an object remains alive while reachable from roots (static fields, local variables on the stack, CPU registers, GC handles, etc.).
            // •	When an object becomes unreachable it becomes eligible for collection; the GC will reclaim its memory at some later time(not necessarily immediately).
            // •	The GC is generational(Gen0 / Gen1 / Gen2 + LOH): short - lived objects are collected more frequently; long - lived survivors are promoted to higher generations.
            // •	Finalizers(destructors) run on a separate thread; finalizable objects require an extra GC pass before their memory is reclaimed.Finalizers are non - deterministic — prefer IDisposable and using for deterministic cleanup (especially for unmanaged resources).
            // •	Static fields and other roots keep objects alive for the lifetime of the AppDomain / process(or until the reference is cleared).
            // •	Practical notes / gotchas:
            // •	You cannot predict exactly when the GC runs — don't rely on finalizers for timely cleanup.
            // •	Call Dispose /using for non - memory resources; GC.Collect() is for diagnostics only and can hurt performance if abused.
            // •	The JIT/ optimizer can extend the apparent lifetime of a local variable; lifetime(GC reachability) is not always identical to the lexical scope.

            // GC demo: create an object, drop the strong reference, force collection and observe WeakReference

            Console.WriteLine("GC demo: creating an object, dropping strong reference, forcing GC.");

            WeakReference weak;
            {
                var strong = new object();
                weak = new WeakReference(strong);
                Console.WriteLine($"IsAlive while strong reference exists: {weak.IsAlive}");
                // drop strong reference by leaving the block (or setting 'strong = null;')
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(); // second collect helps reclaim objects promoted during finalization

            Console.WriteLine($"IsAlive after GC: {weak.IsAlive}");
            // If false, the object was collected — demonstrates that lifetime ends when there are no reachable roots.
            #endregion

            #region Question 8: Variable Shadowing
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 8: VARIABLE SHADOWING
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is variable shadowing in C#? Does C# allow shadowing in 
            //    nested blocks within the same method?
            //
            // ══════════════════════════════════════════════════════════════════════

            //•	Definition: variable shadowing is when a new declaration reuses an identifier that’s already declared in an outer scope so the new name “hides” the outer one while the inner scope is active.
            //  •	Rules in C# (short):
            //  •	You can shadow class members(fields/properties) with method parameters or local variables; refer to the original with this. (or the type name for static).
            //  •	You cannot redeclare a local/parameter in an inner block if it would conflict with an existing local/parameter in an outer scope — the compiler reports CS0136.
            //  •	Hiding an inherited member (base class member) is allowed but should be explicit with the new modifier(otherwise you get a warning CS0108).
            // Shadowing examples

            // 1) Shadowing a class field with a local/parameter (allowed)
            Console.WriteLine($"classField (field) before shadowing: {classField}"); // refers to class-level field

            int classFieldLocal = 5; // different name (safe)
            Console.WriteLine($"classFieldLocal (local): {classFieldLocal}");

            // Allowed shadowing of a field by a local with same identifier:
            {
                int classField = 7; // hides the class-level `classField` inside this block
                Console.WriteLine($"classField (local shadowing field): {classField}"); // prints 7
            }
            Console.WriteLine($"classField (field) after block: {classField}"); // prints original field value

            // 2) Redeclaring a local in a nested block (not allowed — compile error CS0136)
            //int x = 1;
            //{
            //    int x = 2; // CS0136: A local variable named 'x' is already defined in this scope
            //}

            #endregion

            #region Question 9: C# Naming Rules
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 9: C# NAMING RULES
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: List five rules that must be followed when naming variables in C#.
            //
            // ══════════════════════════════════════════════════════════════════════
            /*•	Must start with a letter (A–Z, a–z) or underscore (_); cannot begin with a digit.
                Example: int count; (valid) vs int 1count; (invalid)
                •	May contain only letters, digits and underscores; no spaces or punctuation.
                Example: string userName2; (valid) vs string user-name; (invalid)
                •	Cannot be a reserved C# keyword unless escaped with @.
                Example: int @class = 0; (allowed) but prefer non-keyword names
                •	Names are case-sensitive — total and Total are different identifiers.
                •	Must be unique in the same scope (you cannot redeclare a local/parameter with the same name in the same scope).
                Attempting to declare a second int x; in the same block produces a compile error.
            */
            #endregion

            #region Question 10: Naming Conventions
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 10: NAMING CONVENTIONS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What naming conventions are recommended for: (a) local variables, 
            //    (b) class names, (c) constants?
            //
            /*
             •	Local variables
                •	Use camelCase (start with lowercase). Keep names short but descriptive for the local context.
                •	Avoid hungarian notation or unnecessary prefixes.
                •	Example: int itemCount, var filePath, bool isValid
             •	Class names
                •	Use PascalCase (start with uppercase). Prefer nouns or noun phrases; types should describe responsibility.
                •	Keep names singular for single entities and use meaningful domain terms.
                •	Example: CustomerRepository, OrderProcessor, HttpResponse
             •	Constants
                •	Use PascalCase for const and static readonly members (per .NET naming guidelines). Constants express immutable, globally meaningful values.
                •	Example: const int MaxRetries = 5;, public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
             */
            // ══════════════════════════════════════════════════════════════════════
            #endregion

            #region Question 11: Error Types
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 11: ERROR TYPES
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Compare and contrast syntax errors, runtime errors, and logical 
            //    errors. Provide an example of each.
            //
            // ══════════════════════════════════════════════════════════════════════

            // 1) Syntax error
            // ----------------
            // A syntax error prevents the code from compiling. Example (commented out
            // because it would not compile):
            //
            //    int 1invalidName = 5;    // syntax error: identifier cannot start with digit
            //    Console.WriteLine("Missing quote); // syntax error: unterminated string literal
            //
            // Since syntax errors stop compilation they must be fixed before running the program.
            Console.WriteLine("1) Syntax error: shown as commented examples (would fail to compile).");

            // 2) Runtime error
            // ----------------
            // A runtime error occurs while the program is running (the code compiles,
            // but an exception is thrown during execution). Demonstrate divide-by-zero.
            Console.WriteLine("\n2) Runtime error demonstration (divide-by-zero):");
            try
            {
                int numerator = 10;
                int denominator = 0;
                // This line compiles but will throw System.DivideByZeroException at runtime.
                int result = numerator / denominator;
                Console.WriteLine($"Result: {result}"); // not reached if exception thrown
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught runtime exception: {ex.GetType().Name} - {ex.Message}");
            }

            // 3) Logical error
            // ----------------
            // Logical errors compile and run but produce incorrect results due to a bug
            // in the logic. Example: a faulty FindMax implementation that initializes
            // max to 0, which fails when all inputs are negative.
            Console.WriteLine("\n3) Logical error demonstration (buggy FindMax):");

            // C# (logical error: integer division leads to wrong average)
            int sum = 5;
            int count = 2;
            double avg = sum / count; // avg == 2.0 (wrong), because integer division occurs
                                      // Fix: double avg = (double)sum / count; -> 2.5
            Console.WriteLine("\nSummary:");
            Console.WriteLine("- Syntax errors: detected at compile time; fix source to compile.");
            Console.WriteLine("- Runtime errors: detected during execution; handle with try/catch or fix the condition.");
            Console.WriteLine("- Logical errors: program runs but produces incorrect results; require debugging and tests to find and fix.");

            #endregion

            #region Question 12: Exception Handling Importance
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 12: EXCEPTION HANDLING IMPORTANCE
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Why is exception handling important in C#? What would happen if 
            //    you don't handle exceptions?


            // Answer:
            // •	Prevents unexpected application termination by catching and handling errors.
            // •	Allows graceful recovery, deterministic cleanup of resources, and user-friendly error reporting.
            // •	If exceptions go unhandled they propagate up the call stack and, if no handler is found, the runtime will terminate the process (and typically print a stack trace).
            // •	Use try/catch/finally, top-level handlers, and proper logging. Prefer IDisposable and `using` for resource cleanup.
            //
            // ══════════════════════════════════════════════════════════════════════


            #endregion

            #region Question 13: try-catch-finally
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 13: TRY-CATCH-FINALLY
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Write a code example demonstrating try-catch-finally. Explain when 
            //    the finally block executes.
            //
            // Simple demo: try/catch/finally local function
            Console.WriteLine("\nException handling demo:");
            void ExceptionDemo()
            {
                try
                {
                    Console.WriteLine(" -> In try: about to throw");
                    throw new InvalidOperationException("Demo exception");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($" -> Caught: {ex.GetType().Name} - {ex.Message}");
                }
                finally
                {
                    Console.WriteLine(" -> In finally: cleanup runs regardless of catch");
                }
            }
            ExceptionDemo();
            /*
             finally always runs after the try block completes — whether the try completes normally, throws an exception, or control leaves via return — with a few important exceptions and gotchas:
             •	Normal behavior
                  •	finally executes after the try block and any matching catch blocks, before control returns to the caller or before the exception continues to propagate.
                  •	It runs on both normal completion and when an exception is thrown (including when the exception is re-thrown).
                  •	Common exceptions to execution
                  •	finally will not run if the process is terminated abruptly (e.g., Environment.FailFast), or the CLR forcibly aborts the process (unrecoverable errors such as StackOverflowException or certain native crashes).
                  •	Thread aborts historically could prevent execution; rely on modern patterns instead.
             •	Gotchas
                  •	If finally contains a return (or throws), it overrides the return value or the exception from try/catch — usually a bug.
                  •	The value/expression of a return in try is evaluated before finally runs. For value types the returned value is a copy; for reference types the reference is returned (the object can still be mutated inside finally).
                  •	In async methods, finally runs after awaited operations complete and the method resumes — semantics remain consistent but occur across await boundaries.
             */
            // ══════════════════════════════════════════════════════════════════════

            #endregion

            #region Question 14: Common Built-in Exceptions
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 14: COMMON BUILT-IN EXCEPTIONS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: List and explain five common built-in exceptions in C# with 
            //    scenarios when each would occur.
            //
            // Question 14: Common built-in exceptions demo
            Console.WriteLine("\nQuestion 14: Common built-in exceptions demo:\n");

            void Question14Demo()
            {
                // 1) ArgumentNullException - occurs when a required argument is null.
                try
                {
                    string s = null;
                    if (s is null) throw new ArgumentNullException(nameof(s), "Demo: parameter must not be null.");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ArgumentNullException -> Scenario: missing required argument. Message: {ex.Message}");
                }

                // 2) ArgumentOutOfRangeException - occurs when an argument's value is outside the valid range.
                try
                {
                    var list = new List<int> { 1, 2, 3 };
                    int index = -1;
                    if (index < 0 || index >= list.Count) throw new ArgumentOutOfRangeException(nameof(index), index, "Demo: index out of range.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"ArgumentOutOfRangeException -> Scenario: invalid index/argument value. Message: {ex.Message}");
                }

                // 3) InvalidOperationException - occurs when a method call is invalid for the object's current state.
                try
                {
                    var enumerator = new List<int>().GetEnumerator();
                    // Example invalid operation: calling Current before MoveNext()
                    var _ = enumerator.Current; // may throw InvalidOperationException depending on enumerator implementation
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException -> Scenario: method invalid in current state. Message: {ex.Message}");
                }

                // 4) NullReferenceException - occurs when dereferencing a null reference.
                try
                {
                    object o = null;
                    // Dereference null -> NullReferenceException
                    //_ = o.ToString();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"NullReferenceException -> Scenario: dereferencing null. Message: {ex.Message}");
                }

                // 5) FileNotFoundException - occurs when an I/O operation expects a file that does not exist.
                try
                {
                    System.IO.File.ReadAllText("this_file_does_not_exist.txt");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Console.WriteLine($"FileNotFoundException -> Scenario: missing file during IO. Message: {ex.Message}");
                }

                Console.WriteLine("\nTips: validate arguments (throw ArgumentNullException/ArgumentOutOfRangeException), check for null before dereference, and use try/catch around IO or state-dependent operations.");
            }

            Question14Demo();
            // ══════════════════════════════════════════════════════════════════════
            #endregion

            #region Question 15: Multiple catch Blocks
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 15: MULTIPLE CATCH BLOCKS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Why is the order of catch blocks important when handling multiple 
            //    exceptions? Write code showing correct ordering.
            //
            // Explanation:
            // - Catch blocks are evaluated top-to-bottom.
            // - More specific exceptions (derived types) must come before more general ones (base types),
            //   otherwise the specific catch becomes unreachable and the compiler will report an error.
            // - Correct ordering: specific -> less specific -> general (`Exception`) last.
            //
            // Demonstration:
            Console.WriteLine("\nQuestion 15: Multiple catch blocks demo:");

            // Example that throws a FormatException
            try
            {
                string notAnInt = "abc";
                // int.Parse will throw FormatException for non-numeric input
                int.Parse(notAnInt);
            }
            catch (FormatException ex) // specific exception first
            {
                Console.WriteLine($"Caught FormatException: {ex.Message}");
            }
            catch (ArgumentNullException ex) // other specific exception
            {
                Console.WriteLine($"Caught ArgumentNullException: {ex.Message}");
            }
            catch (Exception ex) // most general catch last
            {
                Console.WriteLine($"Caught general Exception: {ex.GetType().Name} - {ex.Message}");
            }

            // Incorrect ordering (do not uncomment) - would produce a compile-time error/CS0161 or make following catches unreachable:
            /*
            try
            {
                int.Parse(notAnInt);
            }
            catch (Exception ex) // catches everything first - makes the specific catches below unreachable
            {
                Console.WriteLine("This will catch all exceptions, so specific catches below are unreachable.");
            }
            catch (FormatException ex) // unreachable -> compile error
            {
                Console.WriteLine("Unreachable catch for FormatException.");
            }
            */
            // ══════════════════════════════════════════════════════════════════════

            #endregion

            #region Question 16: throw Keyword
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 16: THROW KEYWORD
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is the difference between 'throw' and 'throw ex' when 
            //    re-throwing an exception? Which one preserves the stack trace?
            //
            // • 'throw;' re-throws the current exception and preserves the original stack trace.
            // • 'throw ex;' (where 'ex' is the caught exception) resets the stack trace to the current location,
            //   losing the original error context.
            // • Always use 'throw;' inside a catch block to maintain accurate debugging information.
            //
            // Example:
            Console.WriteLine("\nQuestion 16: throw vs throw ex demo:");

            void ThrowVsThrowExDemo()
            {
                try
                {
                    CauseException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Stack trace with 'throw;':");
                    try
                    {
                        throw; // preserves original stack trace
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.StackTrace);
                    }

                    Console.WriteLine("\nStack trace with 'throw ex;':");
                    try
                    {
                        throw ex; // resets stack trace to here
                    }
                    catch (Exception e2)
                    {
                        Console.WriteLine(e2.StackTrace);
                    }
                }
            }

            void CauseException()
            {
                throw new InvalidOperationException("Demo exception for throw vs throw ex");
            }

            ThrowVsThrowExDemo();

            // Summary:
            // - Use 'throw;' to re-throw and preserve the stack trace.
            // - Avoid 'throw ex;' unless you intentionally want to reset the stack trace (rarely correct).
            // ══════════════════════════════════════════════════════════════════════
            #endregion

            #region Question 17: Stack and Heap Memory
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 17: STACK AND HEAP MEMORY
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Explain the differences between Stack and Heap memory in C#. 
            //    What types of data are stored in each?
            //
            // STACK:
            // • Structure: LIFO (Last-In-First-Out) data structure
            // • Storage: Local variables, method parameters, return addresses
            // • Allocation: Automatic; space allocated when variable declared
            // • Deallocation: Automatic; freed when scope exits (variable lifetime ends)
            // • Speed: Very fast (pointer increment/decrement)
            // • Memory size: Limited; typically smaller (can cause StackOverflowException)
            // • Thread-safe: Each thread has its own stack
            // • Organized: Contiguous, predictable memory layout
            //
            // HEAP:
            // • Structure: Free-form memory pool managed by garbage collector
            // • Storage: Objects (reference types), array elements
            // • Allocation: Dynamic; occurs when 'new' is called
            // • Deallocation: Automatic via GC when no references remain (non-deterministic)
            // • Speed: Slower than stack (requires GC, fragmentation possible)
            // • Memory size: Larger; can grow to available system RAM
            // • Thread-safe: Garbage collector must synchronize access
            // • Organized: Fragmented; GC relocates objects to reduce fragmentation
            //
            // DATA TYPE STORAGE:
            // ════════════════════════════════════════════════════════════════════
            //
            // VALUE TYPES (stored on STACK or as inline fields):
            // • int, double, decimal, bool, char, struct, enum
            // • When a value type is declared, the actual data lives on the stack
            // • When passed as parameter, a COPY is made
            // • When boxed (wrapped in object), it moves to the heap
            //
            // REFERENCE TYPES (object lives on HEAP, reference on STACK):
            // • class, interface, delegate, string, array, object
            // • The object itself is allocated on the heap
            // • The variable on the stack holds only a reference (memory address)
            // • When passed as parameter, the REFERENCE is copied (not the object)
            //
            // ══════════════════════════════════════════════════════════════════════


            #endregion

            #region Question 18: Value Types vs Reference Types
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 18: VALUE TYPES VS REFERENCE TYPES
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Write a code example showing how value types and reference types 
            //    behave differently when assigned to another variable.
            //
            Console.WriteLine("\nQuestion 17: Stack vs Heap Memory demo:\n");

            // Example 1: Value types on the stack
            Console.WriteLine("=== VALUE TYPES (Stack) ===");
            {
                int stackInt1 = 42;
                int stackInt2 = stackInt1; // copies the value
                stackInt2 = 100;

                Console.WriteLine($"stackInt1: {stackInt1}"); // 42 (unchanged)
                Console.WriteLine($"stackInt2: {stackInt2}"); // 100 (independent copy)
                Console.WriteLine("→ Modifying stackInt2 does NOT affect stackInt1\n");
            }

            // Example 2: Reference types on the heap
            Console.WriteLine("=== REFERENCE TYPES (Heap) ===");
            {
                var obj1 = new System.Text.StringBuilder("Hello");
                var obj2 = obj1; // copies the reference, not the object
                obj2.Append(" World");

                Console.WriteLine($"obj1: {obj1}"); // "Hello World" (affected!)
                Console.WriteLine($"obj2: {obj2}"); // "Hello World" (same object)
                Console.WriteLine("→ Both variables reference the SAME object on heap\n");
            }
            // ══════════════════════════════════════════════════════════════════════

            #endregion

            #region Question 19: Object in C#
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 19: OBJECT IN C#
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Why is 'object' considered the base type of all types in C#? 
            //    What methods does every type inherit from System.Object?
            // WHY 'object' IS THE BASE TYPE OF ALL TYPES:
            // ═══════════════════════════════════════════════════════════════════════
            //
            // • Unified Type System: C# uses a unified type system where 'object' 
            //   (System.Object) is the ultimate base class. Every type—whether 
            //   reference (class, interface, delegate) or value (struct, enum, 
            //   primitive types)—implicitly derives from 'object'.
            //
            // • Enables Polymorphism: By having a common base type, you can:
            //   - Store any value in an 'object' variable (via boxing for value types)
            //   - Call methods polymorphically on any object
            //   - Create collections (List<object>, arrays of object) that hold mixed types
            //
            // • Common Contract: 'object' provides a common interface (methods like 
            //   ToString(), Equals(), GetHashCode()) that all types inherit, ensuring
            //   consistent behavior across the type system.
            //
            // • Inheritance Chain: Reference types directly inherit from 'object' 
            //   (or from a class that ultimately inherits from 'object'). Value types 
            //   inherit from System.ValueType, which inherits from 'object'.
            //
            // METHODS INHERITED FROM System.Object:
            // ═══════════════════════════════════════════════════════════════════════
            //
            // 1. GetType()
            //    • Returns: System.Type representing the runtime type of the object
            //    • Use: Runtime type inspection, reflection, type checking
            //    • Cannot be overridden (sealed)
            //
            // 2. ToString()
            //    • Returns: string representation of the object
            //    • Default: fully qualified type name (e.g., "ConsoleApp1.MyClass")
            //    • Override: commonly overridden to provide meaningful string representation
            //    • Virtual: can be overridden by derived types
            //
            // 3. Equals(object obj)
            //    • Returns: bool indicating if current object equals another object
            //    • Default: reference equality (ReferenceEquals) for reference types
            //    •          value equality for value types (compares field values)
            //    • Virtual: should be overridden for custom equality logic
            //    • Best Practice: override both Equals() AND GetHashCode() together
            //
            // 4. GetHashCode()
            //    • Returns: int hash code for the object
            //    • Use: for use in hash-based collections (Dictionary, HashSet)
            //    • Default: based on object's memory address
            //    • Virtual: should be overridden if you override Equals()
            //    • Contract: Equal objects MUST have equal hash codes
            //
            // 5. ReferenceEquals(object a, object b) [static]
            //    • Returns: bool indicating if both references point to same object
            //    • Use: compare object identity (not equality)
            //    • Cannot be overridden
            //    • Always checks reference identity, ignoring custom Equals()
            //
            // 6. MemberwiseClone() [protected]
            //    • Returns: shallow copy of the object (new reference, same field values)
            //    • Use: implement cloning; ICloneable.Clone() often uses this
            //    • Shallow: does not recursively clone referenced objects
            //    • Protected: cannot call directly; only from within the class/derived classes
            //
            // 7. Finalize() [protected, virtual]
            //    • Called by GC finalizer thread before memory is reclaimed
            //    • Use: cleanup unmanaged resources (legacy; use IDisposable instead)
            //    • Syntax: defined as a destructor in C# (e.g., ~MyClass())
            //    • Non-deterministic: GC decides when to call; cannot predict timing
            //    • Gotcha: making an object finalizable delays GC collection
            //
            // ══════════════════════════════════════════════════════════════════════

            #endregion

        }


        //#endregion
    }

    
}