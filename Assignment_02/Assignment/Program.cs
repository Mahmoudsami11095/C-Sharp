using System;

#region Q1: Explicit Casting
// Question: What is the output of casting a double (9.99) to an int?
// Prediction: It will be 9 because casting a double to an int truncates the decimal part.
double d = 9.99;
int i = (int)d;
Console.WriteLine($"Q1: double {d} cast to int is {i}");
#endregion

#region Q2: Numeric Precision
// Question: Fix a code snippet where 5 / 2 results in 2 instead of 2.5.
// Solution: Cast one of the operands to a double or use a double literal.
double result = 5 / 2.0;
Console.WriteLine($"Q2: 5 / 2.0 = {result}");
#endregion

#region Q3: User Input
// Question: Read an age from the console and store it as an int.
Console.Write("Q3: Enter your age: ");
string inputAge = Console.ReadLine();
if (int.TryParse(inputAge, out int age))
{
    Console.WriteLine($"Your age is: {age}");
}
else
{
    Console.WriteLine("Invalid age input.");
}
#endregion

#region Q4: Parsing Exceptions
// Question: What happens when int.Parse() is called on a non-numeric string like "12a"?
// Answer: It throws a System.FormatException.
try
{
    Console.WriteLine("Q4: Attempting to parse '12a'...");
    int.Parse("12a");
}
catch (FormatException ex)
{
    Console.WriteLine($"Caught expected exception: {ex.Message}");
}
#endregion

#region Q5: Safe Conversion
// Question: Modify Q4 to print "Invalid" instead of throwing an exception.
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
// Question: Explain the process and output of unboxing an object containing an int back to an int.
// Explanation: Unboxing is the explicit conversion from object to a value type. 
// It requires the object to actually contain the value type being unboxed.
object obj = 10; // Boxing
int unboxedInt = (int)obj; // Unboxing
Console.WriteLine($"Q6: Unboxed int: {unboxedInt}");
#endregion

#region Q7: Unboxing (Long)
// Question: Predict behavior when trying to unbox an int stored in an object directly into a long.
// Prediction: It throws an InvalidCastException because unboxing must be to the exact type.
object objInt = 10;
try
{
    Console.WriteLine("Q7: Attempting to unbox int object to long...");
    long unboxedLong = (long)objInt;
}
catch (InvalidCastException ex)
{
    Console.WriteLine($"Caught expected exception: {ex.Message}");
}
#endregion

#region Q8: Exception Handling
// Question: Fix the unboxing error from Q7 to avoid exceptions and return -1 if impossible.
object objInt2 = 10;
long safeLong = objInt2 is int ? (int)objInt2 : -1;
// Alternatively, if it could be anything:
// long safeLong = objInt2 is long l ? l : (objInt2 is int i2 ? i2 : -1);
Console.WriteLine($"Q8: Safe unboxed value: {safeLong}");
#endregion

#region Q9: Null-Conditional Operator
// Question: What is the output of name?.Length when name is null?
// Answer: It returns null (of type int?).
string name = null;
int? length = name?.Length;
Console.WriteLine($"Q9: name?.Length when name is null is: {(length == null ? "null" : length.ToString())}");
#endregion

#region Q10: Null-Coalescing Operator
// Question: Explain result of name?.Length ?? 0 when name is null.
// Answer: It returns 0 because ?? provides a default value if the left side is null.
int finalLength = name?.Length ?? 0;
Console.WriteLine($"Q10: name?.Length ?? 0 when name is null is: {finalLength}");
#endregion

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
