namespace GeometryTest.Shapes;

public sealed class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        _radius = radius > 0 ? radius
            : throw new ArgumentOutOfRangeException(nameof(radius), radius, "Value must be greater than 0");
    }

    public double Radius => _radius;


    protected override IEnumerable<(string Name, double Value)> GetParameters()
    {
        yield return ("radius", _radius);
    }

    protected override double GetPerimeter() => Math.Round((2 * Math.PI * _radius), 3);

}