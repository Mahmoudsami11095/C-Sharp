/*
Part 1: Enums
Q1 : Day of the Week
Create an enum called DayOfWeek with values: Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday.
Then write a program that:
- Asks the user to enter a day number (0-6).
- Converts it to the enum and prints the day name.
- Uses a switch statement to print whether it's a "Workday" or a "Weekend".
*/

Console.WriteLine("Enter a day number (0-6, 0 for Saturday, 1 for Sunday ...): ");
int.TryParse(Console.ReadLine(), out int day);

if (day >= 0 && day <= 6)
{
    DayOfWeek dayOfWeek = (DayOfWeek)day;
    Console.WriteLine("Day of the week: " + dayOfWeek);

    switch (dayOfWeek)
    {
        case DayOfWeek.Saturday:
        case DayOfWeek.Sunday:
            Console.WriteLine("It's a Weekend");
            break;
        default:
            Console.WriteLine("It's a Workday");
            break;
    }
}
else
{
    Console.WriteLine("Invalid day number.");
}

/*Part 2: Arrays
Q1 : Array Statistics
Write a program that:
- Asks the user for the size of an integer array.
- Reads the elements from the user.
- Prints: the sum, the average, the maximum value, the minimum value, and the array in reverse order.
Hint: Do NOT use built-in methods like Array.Max(). Use loops.
*/

Console.WriteLine("\nEnter the size of the array: ");
int.TryParse(Console.ReadLine(), out int arrSize);

if (arrSize > 0)
{
    Console.WriteLine("Enter the elements of the array: ");
    int[] arr = new int[arrSize];
    int sum = 0;
    int max = int.MinValue;
    int min = int.MaxValue;

    for (int i = 0; i < arrSize; i++)
    {
        int.TryParse(Console.ReadLine(), out arr[i]);
        sum += arr[i];
        if (arr[i] > max)
        {
            max = arr[i];
        }
        if (arr[i] < min)
        {
            min = arr[i];
        }
    }

    double avg = (double)sum / arrSize;
    Console.WriteLine("Sum: " + sum);
    Console.WriteLine($"Average: {avg:F2}");
    Console.WriteLine("Max: " + max);
    Console.WriteLine("Min: " + min);

    Console.WriteLine("Reversed Array:");
    for (int i = arrSize - 1; i >= 0; i--)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}
else
{
    Console.WriteLine("Array size must be greater than 0.");
}


/*
Q2 : Student Grades Matrix
You have 3 students, each with 4 subject grades. Store them in a 2D array.
Write a program that:
- Reads grades from the user into a [3, 4] array.
- Prints each student's average grade.
- Prints the overall class average.
*/

Console.WriteLine("\n--- Student Grades Matrix ---");
int[,] studentGrade = new int[3, 4];

for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Student {i + 1}:");
    for (int j = 0; j < 4; j++)
    {
        Console.Write($"Enter grade for subject {j + 1}: ");
        int.TryParse(Console.ReadLine(), out studentGrade[i, j]);
    }
}

for (int i = 0; i < 3; i++)
{
    int studentGradeSum = 0;
    for (int j = 0; j < 4; j++)
    {
        studentGradeSum += studentGrade[i, j];
    }
    double avg = (double)studentGradeSum / 4;
    Console.WriteLine($"Student {i + 1}'s Average Grade: {avg:F2}");
}

double classAvg = 0;
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        classAvg += studentGrade[i, j];
    }
}
classAvg /= (3 * 4);
Console.WriteLine($"Overall Class Average: {classAvg:F2}");


/*Part 3: Functions (Methods)
Q1 : Basic Calculator Functions
Write four static methods: Add, Subtract, Multiply, Divide.
Each takes two double parameters and returns a double result.
In Main, ask the user for two numbers and an operation (+, -, *, /), then call the appropriate method and display the result.
Handle division by zero gracefully.
*/
double Add(double a, double b)
{
    return a + b;
}
double Subtract(double a, double b)
{
    return a - b;
}
double Multiply(double a, double b)
{
    return a * b;
}
double Divide(double a, double b)
{
    if (b == 0)
    {
        Console.WriteLine("Cannot divide by zero.");
        return 0;
    }
    return a / b;
}

Console.WriteLine("\n--- Basic Calculator ---");
Console.WriteLine("Enter first number: ");
double.TryParse(Console.ReadLine(), out double num1);
Console.WriteLine("Enter second number: ");
double.TryParse(Console.ReadLine(), out double num2);
Console.WriteLine("Enter operation (+, -, *, /): ");
string opStr = Console.ReadLine();
char op = string.IsNullOrEmpty(opStr) ? ' ' : opStr[0];

switch (op)
{
    case '+':
        Console.WriteLine("Result: " + Add(num1, num2));
        break;
    case '-':
        Console.WriteLine("Result: " + Subtract(num1, num2));
        break;
    case '*':
        Console.WriteLine("Result: " + Multiply(num1, num2));
        break;
    case '/':
        Console.WriteLine("Result: " + Divide(num1, num2));
        break;
    default:
        Console.WriteLine("Invalid operation.");
        break;
}

/*Q2 : Circle Calculator with out
Write a method CalculateCircle that takes a double radius as input and returns both the area and circumference using out parameters.
Call the method from Main, then print both results.
*/
static void CalculateCircle(double radius, out double area, out double circumference)
{
    area = Math.PI * radius * radius;
    circumference = 2 * Math.PI * radius;
}

Console.WriteLine("\n--- Circle Calculator ---");
Console.WriteLine("Enter radius: ");
double.TryParse(Console.ReadLine(), out double radius);

CalculateCircle(radius, out double area, out double circumference);
Console.WriteLine($"Area: {area:F2}");
Console.WriteLine($"Circumference: {circumference:F2}");


/*Mini Student Grade Manager (Combining all three topics)
Requirements:
- Enum: Create a Grade enum with values: A, B, C, D, F.
- Array: Use an int[] array to store scores for 5 students.
- Functions: Write the following methods:
  a) Method To GetGrade returns the grade enum based on score (A >= 90, B >= 80, C >= 70, D >= 60, F < 60).
  b) Method To CalculateAverage returns the average of all scores.
  c) Method To GetMinMax finds the min and max scores using out.
The program should:
- Read 5 student scores from the user.
- Print each student's score and corresponding letter grade.
- Print the class average, minimum, and maximum scores.
*/

Console.WriteLine("\n--- Mini Student Grade Manager ---");
int[] scores = new int[5];

// 1. Read 5 student scores from the user
for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine($"Enter score for student {i + 1}: ");
    int.TryParse(Console.ReadLine(), out scores[i]);
}

// 2. Print each student's score and corresponding letter grade
for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine($"Student {i + 1} Score: {scores[i]}, Grade: {GetGrade(scores[i])}");
}

// 3. Print the class average, minimum, and maximum scores
double classAverage = CalculateAverage(scores);
GetMinMax(scores, out int minScore, out int maxScore);

Console.WriteLine($"\nClass Average: {classAverage:F2}");
Console.WriteLine($"Minimum Score: {minScore}");
Console.WriteLine($"Maximum Score: {maxScore}");

// --- Methods ---

static Grade GetGrade(int score)
{
    if (score >= 90) return Grade.A;
    if (score >= 80) return Grade.B;
    if (score >= 70) return Grade.C;
    if (score >= 60) return Grade.D;
    return Grade.F;
}

static double CalculateAverage(int[] studentScores)
{
    int total = 0;
    for (int i = 0; i < studentScores.Length; i++)
    {
        total += studentScores[i];
    }
    return (double)total / studentScores.Length;
}

static void GetMinMax(int[] studentScores, out int min, out int max)
{
    min = int.MaxValue;
    max = int.MinValue;

    for (int i = 0; i < studentScores.Length; i++)
    {
        if (studentScores[i] < min)
        {
            min = studentScores[i];
        }
        if (studentScores[i] > max)
        {
            max = studentScores[i];
        }
    }
}

enum Grade
{
    A, B, C, D, F
}

enum DayOfWeek
{
    Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday
}
