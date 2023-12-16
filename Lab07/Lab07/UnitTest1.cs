using Calculator;
using System.Collections;

namespace Lab07
{
	[TestFixture]
	public class Tests
	{
		CalculatorOperations calculator;
		[SetUp]
		public void Setup()
		{
			calculator = new CalculatorOperations();
		}

		[TestCase(5, 3, 8)]
		[TestCase(-5, -3, -8)]
		[TestCase(0, 0, 0)]
		public void Add_PositiveAndNegativeNumbers_ReturnsCorrectResult(double a, double b, double expected)
		{
			double result = calculator.Add(a, b);
			Assert.AreEqual(expected, result);
		}

		[TestCase(10, 3, 7)]
		[TestCase(-5, -2, -3)]
		[TestCase(0, 0, 0)]
		public void Subtract_PositiveAndNegativeNumbers_ReturnsCorrectResult(double a, double b, double expected)
		{
			double result = calculator.Subtract(a, b);
			Assert.AreEqual(expected, result);
		}

		[TestCaseSource(nameof(MultiplicationTestCases))]
		public void Multiply_Numbers_ReturnsCorrectResult(double a, double b, double expected)
		{
			double result = calculator.Multiply(a, b);
			Assert.AreEqual(expected, result);
		}

		private static IEnumerable MultiplicationTestCases()
		{
			yield return new TestCaseData(4, 2, 8);
			yield return new TestCaseData(3, -2, -6);
			yield return new TestCaseData(0, 5, 0);
		}

		[TestCase(10, 2, 5)]
		[TestCase(-8, -4, 2)]
		public void Divide_ValidNumbers_ReturnsCorrectResult(double a, double b, double expected)
		{ 
			double result = calculator.Divide(a, b);
			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Divide_DivideByZero_ThrowsDivideByZeroException()
		{
			Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
		}

		[Test]
		public void Divide_NegativeNumbers_ReturnsCorrectResult()
		{
			double result = calculator.Divide(-10, -2);
			Assert.AreEqual(5, result);
		}

	}
}