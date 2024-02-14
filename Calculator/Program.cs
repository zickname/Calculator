using System.Globalization;

while (true)

{
    Console.Write("Введите первое число: ");

    double firstNumber = GetNumberFromConsole();
    MathOperation operation = GetOperatorFromConsole();

    Console.Write("Введите второе число: ");

    double secondNumber = GetNumberFromConsole();
    
    if (operation == MathOperation.Division && secondNumber == 0)
    {
        Console.WriteLine("\nОшибка, нельзя делить на ноль," + "\n" +
                          "Попробуйте ещё раз!\n");
        continue;
    }
    double result = Calculate(firstNumber, secondNumber, operation);

    Console.WriteLine($"Результат: {result}");
}

static double GetNumberFromConsole()
{
    double number;

    while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out number))
    {
        Console.WriteLine("Ошибка. Введите корректное число.");
    }

    return number;
}

MathOperation GetOperatorFromConsole()
{
    char sign;
    string validOperators = "+-*/";
    do
    {
        Console.Write("Введите знак действия ( +, -, *, / ): ");
        sign = Console.ReadKey().KeyChar;
        Console.WriteLine("");
    } while (validOperators.IndexOf(sign) == -1);

    return sign switch
    {
        '+' => MathOperation.Addition,
        '-' => MathOperation.Subtraction,
        '*' => MathOperation.Multiplication,
        '/' => MathOperation.Division,
        _ => throw new ArgumentException("Неверный знак действия")
    };
}

double Calculate(double firstNumber, double secondNumber, MathOperation operation)
{
    return operation switch
    {
        MathOperation.Addition => firstNumber + secondNumber,
        MathOperation.Subtraction => firstNumber - secondNumber,
        MathOperation.Multiplication => firstNumber * secondNumber,
        MathOperation.Division => firstNumber / secondNumber,
        _ => throw new ArgumentException("Неверный знак действия")
    };
}

enum MathOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}