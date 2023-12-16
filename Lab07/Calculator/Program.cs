using Calculator;

class Program
{
	static void Main(string[] args)
	{
		CalculatorOperations calculator = new CalculatorOperations();

		double num1 = 10;
		double num2 = 5;

		double additionResult = calculator.Add(num1, num2);
		double subtractionResult = calculator.Subtract(num1, num2);
		double multiplicationResult = calculator.Multiply(num1, num2);

		try
		{
			double divisionResult = calculator.Divide(num1, num2);
			Console.WriteLine($"Addition: {additionResult}");
			Console.WriteLine($"Subtraction: {subtractionResult}");
			Console.WriteLine($"Multiplication: {multiplicationResult}");
			Console.WriteLine($"Division: {divisionResult}");
		}
		catch (DivideByZeroException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
