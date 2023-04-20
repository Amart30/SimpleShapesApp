namespace GeometryTest.Shapes;

public sealed class Triangle : Shape
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        _sideA = sideA > 0 && sideA < sideB + sideC ? sideA
            : throw new ArgumentOutOfRangeException(nameof(sideA), sideA, "Value is not a valid triangle side");

        _sideB = sideB > 0 && sideB < sideA + sideC ? sideB
            : throw new ArgumentOutOfRangeException(nameof(sideB), sideB, "Value is not a valid triangle side");

        _sideC = sideC > 0 && sideC < sideA + sideB ? sideC
            : throw new ArgumentOutOfRangeException(nameof(sideC), sideC, "Value is not a valid triangle side");
    }

    public double SideA => _sideA;
    public double SideB => _sideB;
    public double SideC => _sideC;

    protected override IEnumerable<(string Name, double Value)> GetParameters()
    {
        yield return ("side A", _sideA);
        yield return ("side B", _sideB);
        yield return ("side C", _sideC);
    }
    protected override double GetPerimeter() => _sideA + _sideB + _sideC;
}