class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number: ");
        string input1 = Console.ReadLine();

        Console.WriteLine("Enter the second number: ");
        string input2 = Console.ReadLine();

        try
        {
            int number1 = Convert.ToInt32(input1);
            int number2 = Convert.ToInt32(input2);

            int result = Divide(number1, number2);
            Console.WriteLine($"The result of {number1} divided by {number2} is {result}");
        }

        catch (FormatException ex)
        {
            ReportError(ex, "Error: One or both of the inputs are not valid integers", input1, input2);
            //Console.WriteLine($"Detailed error message: {ex.Message}");
            //Console.WriteLine($"User Input: input1 = '{input1}', input2 = '{input2}'");
            //Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        catch (DivideByZeroException ex)
        {
            ReportError(ex, "Error: Division by zero is not allowed.");
            //Console.WriteLine($"Detailed error message: {ex.Message}");
            //Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        catch (OverflowException ex)
        {
            ReportError(ex, "Error: Division resulted in a value that is too large to be stored", input1, input2);
            //Console.WriteLine($"Detailed error message: {ex.Message}");
            //Console.WriteLine($"User Input: input1 = '{input1}', input2 = '{input2}'");
            //Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        catch (ArgumentNullException ex)
        {
            ReportError(ex, "Error: One of the Inputs was null.");
            //Console.WriteLine($"Detailed error message: {ex.Message}");
            //Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        catch (Exception ex)
        {
            ReportError(ex, "An unexpected error occurred.");
            //Console.WriteLine($"Detailed error message: {ex.Message}");
            //Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }

    static int Divide(int a, int b)
    {
        //throw new Exception("Custom test exception");
        return a / b;
    }

    static void ReportError(Exception ex, string context, string input1 = null, string input2 = null)
    {

        Console.WriteLine($"[ERROR] {DateTime.Now}: {context}");
        Console.WriteLine($"Type: {ex.GetType()}");
        Console.WriteLine($"Message: {ex.Message}");

        if (ex is FormatException || ex is OverflowException)
        {
            Console.WriteLine($"User Input: input1 = '{input1}', input2 = '{input2}'");
        }

        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
    }
}
