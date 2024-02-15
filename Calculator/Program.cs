using System.Globalization;

while (true)
{
    Console.Write("Введите первое число: ");
    
    double firstNumber = GetNumberFromConsole();
    MathOperation operation = GetOperatorFromConsole();

    Console.Write("Введите второе число: ");

    double secondNumber = GetNumberFromConsole();
    calculateResult result = Calculate(firstNumber, secondNumber, operation);
    
    if (result.isError) 
    {
        Console.WriteLine($"{result.errorMessage}");
        continue;
    }

    Console.WriteLine($"Результат: {result.result}");

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
        _ => throw new NotSupportedException()
    };
}

calculateResult Calculate(double firstNumber, double secondNumber, MathOperation operation)
{
    switch (operation)
    {
        case MathOperation.Addition: return new calculateResult((firstNumber + secondNumber), null, false);
        case MathOperation.Subtraction: return new calculateResult((firstNumber - secondNumber), null, false);
        case MathOperation.Multiplication: return new calculateResult((firstNumber * secondNumber), null, false);
        case MathOperation.Division:
            if (secondNumber != 0) return new calculateResult((firstNumber / secondNumber), null, false);
            return new calculateResult(null, "Ошибка. Нельзя делить на ноль", true);
        default: throw new NotSupportedException();
    }
}

record calculateResult(double? result, string? errorMessage, bool isError);

enum MathOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}