using System;

#region Q1: Explicit Casting
// Q1: What will this print and explain what happens?
// Solution: It will be 9 because casting a double to an int truncates the decimal part.
double d = 9.99;
int x = (int)d;
Console.WriteLine(x);
#endregion

#region Q2: Numeric Precision
// Q2: This code doesn’t compile. Fix it with the smallest change? 
/*
int n = 5;
double d2 = n / 2; 
Console.WriteLine(d2); 
*/
// Solution: It was compiled but the result is incorrect
// because we divide an int by an int, which results in an int.
// To fix this, we need to Cast one of the operands to a double
// or use a double literal.
int n = 5;
double d2 = (double)n / 2;
Console.WriteLine(d2);
#endregion

#region Q3: User Input
// Question: You read a number from user input .. Write the correct line to get age as int.
Console.WriteLine("Q3: Enter your age");
string ageAsString = Console.ReadLine();
if (int.TryParse(ageAsString, out int age))
{
    Console.WriteLine($"Your age is: {age}");
}
else
{
    Console.WriteLine("Invalid age input.");
}
#endregion

#region Q4: Parsing Exceptions
// Question: Q4: What happens here and why?   
/*
string s = "12a"; 
int x = int.Parse(s); 
Console.WriteLine(x); 
*/
// Answer: It will throw a FormatException because the string "12a" 
// cannot be parsed as an integer. and application will be terminated
Console.WriteLine("Q4: Attempting to parse '12a'...");
try
{
    int.Parse("12a");
}
catch (FormatException ex)
{
    Console.WriteLine($"Caught expected exception: {ex.Message}");
}
#endregion

#region Q5: Safe Conversion
// Complete the code from the previous question so it prints 
// Invalid if conversion into int  fails, otherwise prints the number
Console.Write("Q5: Enter a number: ");
string inputNum = Console.ReadLine();
if (int.TryParse(inputNum, out int num))
{
    Console.WriteLine($"Parsed number: {num}");
}
else
{
    Console.WriteLine("Invalid");
}
#endregion

#region Q6: Unboxing (Int)
// What will this print and explain why ? 
/*
object o = 10; 
int a = (int)o; 
Console.WriteLine(a + 1); 
*/
// Answer: It will print 11 because it first unboxes the integer 10 
// and then adds 1 to it.
Console.WriteLine("Q6: Unboxing an int object to an int...");
object o = 10; 
int a = (int)o; 
Console.WriteLine($"a + 1 = {a + 1}"); 
#endregion

#region Q7: Unboxing (Long)
// What will this print and explain why and if there is a problem handle it ? 
Console.WriteLine("Q7: Unboxing an int object to a long...");

/*object o2 = 10; 
long x2 = (long)o2; 
Console.WriteLine(x2); */
// Answer: It will throw an InvalidCastException because unboxing must be to the exact type.
object objInt = 10;
try
{
    long unboxedLong = (long)objInt;
    Console.WriteLine(unboxedLong);
}
catch (InvalidCastException ex)
{
    Console.WriteLine($"Caught expected exception: {ex.Message}");
}
#endregion

#region Q8: Exception Handling
// Question: Fix this to avoid exceptions and print -1 if conversion isn’t possible? 
Console.WriteLine("Q8: Unboxing an int object to a long...");

/*object o3 = 10; 
long x3 = o3; // compile Error"  Cannot implicitly convert type 'object' to 'long'. An explicit conversion exists (are you missing a cast?)
Console.WriteLine(x3);*/

//first Solution 
object o4 = 10;
long x4;

try
{
    x4 = (long)o4;
}
catch
{
    x4 = -1;
}

Console.WriteLine("Try Catch Solution: " + x4);

//another Solution
object o5 = 10;
long x5;

try
{
    x5 = Convert.ToInt64(o5);
}
catch
{
    x5 = -1;
}

Console.WriteLine("Try Catch Solution: " + x5);

// Another Solution
object o2 = 10;
long x2 = o2 is IConvertible ? Convert.ToInt64(o2) : -1;
Console.WriteLine("Check If IConvertible Solution: " + x2);

#endregion

#region Q9: Null-Conditional Operator
// Question: What will this print and explain why ? 
/*string? name = null; 
Console.WriteLine(name?.Length); */

// Answer: It returns null (of type int?).
string? name = null; 
Console.WriteLine("Q9: " + name?.Length); 
Console.WriteLine("This is value if name is null");

#endregion

#region Q10: Null-Coalescing Operator
// Question: Explain result of name?.Length ?? 0 when name is null.
// Answer: It returns 0 because ?? provides a default value if the left side is null.
int finalLength = name?.Length ?? 0;
Console.WriteLine($"Q10: name?.Length ?? 0 when name is null is: {finalLength}");
#endregion
//////////////////////////////////////////////
#region Q11: Null Safety
// Question: Identify flaw in int.Parse(s ?? "0") for a null string.
// Flaw: If s is null, it parses "0" correctly. But if s is an empty string or non-numeric, it still fails.
// Better approach: int.TryParse.
string s = null;
int val = int.Parse(s ?? "0");
Console.WriteLine($"Q11: Result for null string using ?? '0': {val}");
#endregion

#region Q12: String Handling
// Question: General practice on handling potential null values in string variables.
// Best practice: Use IsNullOrEmpty or IsNullOrWhiteSpace.
string str = null;
if (string.IsNullOrEmpty(str))
{
    Console.WriteLine("Q12: String is null or empty.");
}
#endregion

#region Q13: Conversion Methods
// Question: Explain output of Convert.ToInt32(null).
// Answer: It returns 0. int.Parse(null) would throw ArgumentNullException.
int convertedNull = Convert.ToInt32(null);
Console.WriteLine($"Q13: Convert.ToInt32(null) is: {convertedNull}");
#endregion

#region Q14: Parsing vs. Converting
// Question: Compare int.Parse(s) and Convert.ToInt32(s).
// int.Parse(s): Throws if s is null. Throws if s is invalid format.
// Convert.ToInt32(s): Returns 0 if s is null. Throws if s is invalid format.
Console.WriteLine("Q14: int.Parse throws on null, Convert.ToInt32 returns 0 on null.");
#endregion

#region Q15: Practical Logic
// Question: Print "Guest" if user is null, or name in uppercase.
string user = null;
Console.WriteLine($"Q15: User is null -> {user?.ToUpper() ?? "Guest"}");
user = "mahmoud";
Console.WriteLine($"Q15: User is '{user}' -> {user?.ToUpper() ?? "Guest"}");
#endregion
