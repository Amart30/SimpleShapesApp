namespace GeometryTest.Shapes;

public sealed class Square : Shape
{
    private readonly double _side;

    public Square(double side)
    {
        _side = side > 0 ? side
            : throw new ArgumentOutOfRangeException(nameof(side), side, "Value must be greater than 0");
    }

    public double Side => _side;

    protected override IEnumerable<(string Name, double Value)> GetParameters()
    {
        yield return ("side", _side);
    }

    protected override double GetPerimeter() => _side * 4;
}