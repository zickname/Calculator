using System.Globalization;

while (true)

{
    Console.Write("Введите число: ");

    double firstNumber = GetNumberFromConsole();
    MathOperation operation = GetOperatorFromConsole();

    Console.Write("Введите число: ");

    double secondNumber = GetNumberFromConsole();
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
    switch (operation)
    {
        case MathOperation.Addition:
            return firstNumber + secondNumber;
        case MathOperation.Subtraction:
            return firstNumber - secondNumber;
        case MathOperation.Multiplication:
            return firstNumber * secondNumber;
        case MathOperation.Division:
            if (secondNumber == 0)
            {
                throw new DivideByZeroException("Ошибка. Делитель не может быть равным нулю.");
            }

            return firstNumber / secondNumber;
        default:
            throw new ArgumentException("Неверный знак действия");
    }
}

enum MathOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}