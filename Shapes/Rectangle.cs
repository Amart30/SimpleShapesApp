namespace GeometryTest.Shapes;

public sealed class Rectangle : Shape
{
    private readonly double _sideA;
    private readonly double _sideB;

    public Rectangle(double sideA, double sideB)
    {
        _sideA = sideA > 0 ? sideA
            : throw new ArgumentOutOfRangeException(nameof(sideA), sideA, "Value must be greater than 0");

        _sideB = sideB > 0 ? sideB
            : throw new ArgumentOutOfRangeException(nameof(sideB), sideB, "Value must be greater than 0");
    }

    public double SideA => _sideA;
    public double SideB => _sideB;

    protected override IEnumerable<(string Name, double Value)> GetParameters()
    {
        yield return ("side A", _sideA);
        yield return ("side B", _sideB);
    }
    protected override double GetPerimeter() => (_sideA + _sideB) * 2;
}