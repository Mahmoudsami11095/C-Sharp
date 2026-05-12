using System;
using System.Diagnostics;
using System.Text;

#region Question 01: StringBuilder vs String Concat
/*
A junior developer wrote the following code to build a comma-separated list of 5,000 product IDs:
*/
string productList = "";
for (int i = 1; i <= 5000; i++)
{
    productList += "PRD" + i + ",";
}
Console.WriteLine(productList.ToString());

/*
Tasks:
- (a) Explain why this code is inefficient, referencing memory behavior.
  In C#, strings are immutable, meaning they cannot be changed after they are created.
  When using the '+=' operator inside a loop, a completely new string object is allocated
  in memory for every iteration, and the contents of the previous strings are copied over.
  This results in O(N^2) time complexity, wastes a significant amount of memory,
  and puts heavy pressure on the Garbage Collector to clean up the discarded intermediate strings.
*/

/*
- (b) Rewrite this code using StringBuilder.
*/
StringBuilder sb = new StringBuilder();
for (int i = 1; i <= 5000; i++)
{
    sb.Append("PRD" + i + ",");
}
Console.WriteLine(sb.ToString());
/*
- (c) Add timing code (using Stopwatch) to both versions and report the time difference.
*/
Stopwatch sw1 = new Stopwatch();
Stopwatch sw2 = new Stopwatch();

sw1.Start();

for (int i = 1; i <= 5000; i++)
{
    productList += "PRD" + i + ",";
}
sw1.Stop();
sw2.Start();
for (int i = 1; i <= 5000; i++)
{
    sb.Append("PRD" + i + ",");
}
sw2.Stop();
Console.WriteLine("String Concat: " + sw1.ElapsedMilliseconds + " ms");
Console.WriteLine("StringBuilder: " + sw2.ElapsedMilliseconds + " ms");


#endregion

#region Question 02: Ticket Pricing System
/*
Write a program for a cinema ticket pricing system with these rules:

| Condition      | Price  |
| :------------- | :----- |
| Age < 5        | Free   |
| Age 5 - 12     | 30 LE  |
| Age 13 - 59    | 50 LE  |
| Age 60+        | 25 LE  |
| Weekend (Fri/Sat) | +10 LE (applied after base price) |
| Student Discount  | 20% off base price |

Tasks:
- (a) Implement using if-else/else-if statements.
- (b) Ask for: age, day of week (1-7, where 6=Fri, 7=Sat), and student ID (yes/no).
- (c) Display the final price with a breakdown of the calculation.
*/

// Your solution for Q2:

int age = 0;
int day = 0;
double price = 0;
bool student = false;

Console.Write("Enter your age: ");
age = int.Parse(Console.ReadLine());
Console.Write("Enter the day of week (1-7): ");
day = int.Parse(Console.ReadLine());
Console.Write("Do you have a student ID? (yes/no): ");
string? studentInput = Console.ReadLine()?.Trim().ToLower();
student = (studentInput == "yes" || studentInput == "y");

if (age < 5)
{
    price = 0;
}
else if (age >= 5 && age <= 12)
{
    price = 30;
}
else if (age >= 13 && age <= 59)
{
    price = 50;
}
else if (age >= 60)
{
    price = 25;
}

double basePrice = price;
Console.WriteLine("\n--- Price Breakdown ---");

if (basePrice == 0)
{
    Console.WriteLine("Ticket is Free for Age < 5.");
}
else
{
    Console.WriteLine($"Base Price (based on age): {basePrice} LE");

    if (day == 6 || day == 7)
    {
        price += 10;
        Console.WriteLine($"Weekend Surcharge: +10 LE (Subtotal: {price} LE)");
    }

    if (student)
    {
        double discount = price * 0.20;
        price -= discount;
        Console.WriteLine($"Student Discount (20%): -{discount} LE");
    }
}

Console.WriteLine($"-----------------------\nFinal Price: {price} LE");

#endregion

#region Question 03: Control Flow (Switch)
/*
Convert the following if-else chain to both a traditional switch statement and a switch expression:
*/
string fileExtension = ".pdf";
string fileType;
if (fileExtension == ".pdf")
    fileType = "PDF Document";
else if (fileExtension == ".docx" || fileExtension == ".doc")
    fileType = "Word Document";
else if (fileExtension == ".xlsx" || fileExtension == ".xls")
    fileType = "Excel Spreadsheet";
else if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".gif")
    fileType = "Image File";
else
    fileType = "Unknown File Type";


// Your solution for Q3:
// (a) Traditional switch statement
switch(fileExtension)
{
    case ".pdf":
        fileType = "PDF Document";
        break;
    case ".docx":
    case ".doc":
        fileType = "Word Document";
        break;
    case ".xlsx":
    case ".xls":
        fileType = "Excel Spreadsheet";
        break;
    case ".jpg":
    case ".png":
    case ".gif":
        fileType = "Image File";
        break;
    default:
        fileType = "Unknown File Type";
        break;
}

// (b) Switch expression
fileType = fileExtension switch
{
    ".pdf" => "PDF Document",
    ".docx" or ".doc" => "Word Document",
    ".xlsx" or ".xls" => "Excel Spreadsheet",
    ".jpg" or ".png" or ".gif" => "Image File",
    _ => "Unknown File Type"
};

#endregion



#region Question 04: Ternary Operators
/*
Rewrite the following using only ternary operators (no if statements):

int temperature = 35;
string weatherAdvice;

if (temperature < 0)
    weatherAdvice = "Freezing! Stay indoors.";
else if (temperature < 15)
    weatherAdvice = "Cold. Wear a jacket.";
else if (temperature < 25)
    weatherAdvice = "Pleasant weather.";
else if (temperature < 35)
    weatherAdvice = "Warm. Stay hydrated.";
else
    weatherAdvice = "Hot! Avoid sun exposure.";

Bonus: Discuss if the ternary version is more readable and when you would choose one over the other.
*/

// Your solution for Q4:

//write code by myself (with my style) for this Question 04:

int temperature = 35;
string weatherAdvice = temperature < 0 ? "Freezing! Stay indoors." :
                       temperature < 15 ? "Cold. Wear a jacket." :
                       temperature < 25 ? "Pleasant weather." :
                       temperature < 35 ? "Warm. Stay hydrated." :
                       "Hot! Avoid sun exposure.";

Console.WriteLine($"Temperature: {temperature}, Advice: {weatherAdvice}");

/* Bonus Discussion:
While the ternary version is more concise and reduces the lines of code, chaining multiple ternary operators
can often reduce readability, especially for developers who are not used to this syntax.
A standard `if-else if-else` chain or a `switch` expression (in newer C# versions) is generally preferred
for multiple conditions as it's clearer and easier to maintain.
I would choose a ternary operator for simple, single-condition assignments (e.g., max = a > b ? a : b).
For complex or multiple conditions like this one, an if-else chain or a switch expression is better for readability.
*/
#endregion



#region Question 05: Input Validation with Loops
/*
Create a password validation program with these requirements:

Password Rules:
- Minimum 8 characters.
- At least one uppercase letter.
- At least one digit.
- No spaces allowed.

Program Behavior:
- Use a do-while loop to keep asking until a valid password is entered.
- After each invalid attempt, list the specific rules violated.
- Limit attempts to 5. After 5 failed attempts, display "Account locked" and exit.
- On success, display "Password accepted!".
- Hint: Use foreach to iterate through characters.
*/

// Your solution for Q5:
int attempts = 0;
bool isValid = false;

do
{
    Console.Write("Enter a password: ");
    string? password = Console.ReadLine() ?? "";

    attempts++;

    bool hasMinLength = password.Length >= 8;
    bool hasUpper = false;
    bool hasDigit = false;
    bool hasSpace = false;

    foreach (char c in password)
    {
        if (char.IsUpper(c)) hasUpper = true;
        if (char.IsDigit(c)) hasDigit = true;
        if (c == ' ') hasSpace = true;
    }

    if (hasMinLength && hasUpper && hasDigit && !hasSpace)
    {
        isValid = true;
        Console.WriteLine("Password accepted!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid password. Violations:");
        if (!hasMinLength) Console.WriteLine("- Must be at least 8 characters long.");
        if (!hasUpper) Console.WriteLine("- Must contain at least one uppercase letter.");
        if (!hasDigit) Console.WriteLine("- Must contain at least one digit.");
        if (hasSpace) Console.WriteLine("- Must not contain spaces.");
        
        if (attempts < 5)
        {
            Console.WriteLine($"Attempts remaining: {5 - attempts}\n");
        }
    }

} while (attempts < 5);

if (!isValid)
{
    Console.WriteLine("Account locked");
}

#endregion

#region Question 06: Array Processing
/*
Given an array of exam scores:
int[] scores = { 85, 42, 91, 67, 55, 78, 39, 88, 72, 95, 60, 48 };

Using loops (your choice of for, foreach, while), write code to:
(a) Find and display all failing scores (below 50)
(b) Find the first score above 90 and stop searching immediately
(c) Calculate the class average, excluding any scores below 40 (considered absent)
(d) Count how many students scored in each grade range:
    - A: 90-100
    - B: 80-89
    - C: 70-79
    - D: 60-69
    - F: Below 60
*/

// Your solution for Q6:
int[] scores = { 85, 42, 91, 67, 55, 78, 39, 88, 72, 95, 60, 48 };

Console.WriteLine("--- (a) Failing Scores ---");
foreach (int score in scores)
{
    if (score < 50)
    {
        Console.WriteLine(score);
    }
}

Console.WriteLine("\n--- (b) First Score Above 90 ---");
foreach (int score in scores)
{
    if (score > 90)
    {
        Console.WriteLine(score);
        break;
    }
}

Console.WriteLine("\n--- (c) Class Average (excluding < 40) ---");
int sum = 0;
int count = 0;
foreach (int score in scores)
{
    if (score >= 40)
    {
        sum += score;
        count++;
    }
}
double average = count > 0 ? (double)sum / count : 0;
Console.WriteLine($"Average: {average:F2}");

Console.WriteLine("\n--- (d) Grade Distribution ---");
int countA = 0, countB = 0, countC = 0, countD = 0, countF = 0;
foreach (int score in scores)
{
    if (score >= 90) countA++;
    else if (score >= 80) countB++;
    else if (score >= 70) countC++;
    else if (score >= 60) countD++;
    else countF++;
}
Console.WriteLine($"A: {countA}");
Console.WriteLine($"B: {countB}");
Console.WriteLine($"C: {countC}");
Console.WriteLine($"D: {countD}");
Console.WriteLine($"F: {countF}");

#endregion
