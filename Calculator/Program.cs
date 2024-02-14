using System.Globalization;

while (true)
{
    Console.Write("Введите первое число: ");
    
    double firstNumber = GetNumberFromConsole();
    MathOperation operation = GetOperatorFromConsole();

    Console.Write("Введите второе число: ");

    double secondNumber = GetNumberFromConsole();
    double result = Calculate(firstNumber, secondNumber, operation, errorMessage: out var errorMessage);
    
    if (errorMessage)
    {
        Console.WriteLine("Ошибка. Нельзя делить на ноль!");
        continue;
    }

    Console.WriteLine($"Результат: {result}");
   
}

static double GetNumberFromConsole()
{
    double number;

    while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out number))
        Console.WriteLine("Ошибка. Введите корректное число.");

    return number;
}

MathOperation GetOperatorFromConsole()
{
    char sign;
    const string validOperators = "+-*/";
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

double Calculate(double firstNumber, double secondNumber, MathOperation operation, out bool errorMessage)
{
    errorMessage = default;
    switch (operation)
    {
        case MathOperation.Addition: return firstNumber + secondNumber;
        case MathOperation.Subtraction: return firstNumber - secondNumber;
        case MathOperation.Multiplication: return firstNumber * secondNumber;
        case MathOperation.Division:
            if (secondNumber != 0) return firstNumber / secondNumber;
            errorMessage = true;
            return 0;
        default: throw new NotSupportedException();
    }
}

enum MathOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}