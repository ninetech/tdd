namespace SolidaryTests;

public class SumTests
{
    private readonly Calculator _calculator = new Calculator();

    [TestCase(1, 2, 3)]
    [TestCase(2, 3, 5)]
    public void Sum_ShouldReturnSumOfNumbersOne(int a, int b, int expected)
    {
        _calculator
            .Sum(a, b)
            .ShouldBe(expected);
    }

    [Test]
    public void Divide()
    {
        _calculator
            .Divide(2, 2)
            .ShouldBe(1);
    }
}