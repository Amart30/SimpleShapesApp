namespace GeometryTest.Shapes;

public abstract class Shape
{
    protected abstract IEnumerable<(string Name, double Value)> GetParameters();

    protected abstract double GetPerimeter();
    public double Perimeter => GetPerimeter();

    public override string ToString()
    {
        var parameters = GetParameters().Select(x => $"{x.Name}: {x.Value}");
        return $"{GetType().Name} - {string.Join(' ', parameters)} - Perimeter: {Perimeter}";
    }
}