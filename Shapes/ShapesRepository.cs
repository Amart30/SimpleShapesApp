namespace GeometryTest.Shapes;

public static class ShapesRepository
{
    private static List<Shape> _shapes = new();

    public static IEnumerable<Shape> GetAll()
    {
        IEnumerable<Shape> shapes;

        lock (_shapes)
        {
            shapes = new List<Shape>(_shapes);
        }

        return shapes;
    }

    public static void ReplaceAll(IEnumerable<Shape> collection)
    {
        lock (_shapes)
        {
            _shapes = new List<Shape>(collection);
        }
    }

    public static void Add<T>(T shape) where T : Shape
    {
        lock (_shapes)
        {
            _shapes.Add(shape);
        }
    }

    public static void AddMany(IEnumerable<Shape> collection)
    {
        lock (_shapes)
        {
            _shapes.AddRange(collection);
        }
    }

    public static void DeleteAll<T>() where T : Shape
    {
        var type = typeof(T);

        lock (_shapes)
        {
            _shapes = _shapes.Where(x => x.GetType() != type).ToList();
        }
    }
}