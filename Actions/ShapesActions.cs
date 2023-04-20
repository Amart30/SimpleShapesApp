using System.Reflection;
using GeometryTest.Shapes;

namespace GeometryTest.Actions;

public class ShapesActions
{
    public static Task ViewAllShapesAsync()
    {
        Console.Clear();

        foreach (var shape in ShapesRepository.GetAll())
        {
            Console.WriteLine(shape);
        }

        Console.ReadKey();

        return Task.CompletedTask;
    }

    public static Task AddShapeAsync<T>() where T : Shape
    {        
        try
        {
            var ConstuctorInfo = typeof(T)
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                .Single();

            var parameters = ConstuctorInfo.GetParameters();

            var arguments = new object?[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
            {
                bool isValid;               

                do
                {
                    Console.Clear();

                    Console.Write($"Set value for {parameters[i].Name}: ");

                    isValid = CommonTryParse(Console.ReadLine(), parameters[i].ParameterType, out arguments[i]);
                }
                while (!isValid);
            }

            var shape = (T)ConstuctorInfo.Invoke(arguments);
            ShapesRepository.Add(shape);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to create a {typeof(T).Name}: {e.InnerException?.Message ?? e.Message}");
            Console.ReadKey();
        }

        return Task.CompletedTask;
    }

    public static Task DeleteShapesAsync<T>() where T : Shape
    {
        Console.Clear();

        ShapesRepository.DeleteAll<T>();

        Console.WriteLine($"All {typeof(T).Name} shapes have been deleted");
        Console.ReadKey();

        return Task.CompletedTask;
    }

    public static Task TransformAllShapesAsync()
    {
        Console.Clear();

        try
        {
            var transformedShapes = ShapesRepository.GetAll().Select(TransformShape).ToList();
            ShapesRepository.ReplaceAll(transformedShapes);

            Console.WriteLine("Transformation completed");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Transformation failed: {e.Message}");
        }

        Console.ReadKey();

        return Task.CompletedTask;
    }

    private static Shape TransformShape(Shape input) => input switch
    {
        Triangle x => new Rectangle(x.SideA, x.SideB),
        Rectangle x => new Triangle(x.SideA, x.SideB, Math.Sqrt(Math.Pow(x.SideA, 2) + Math.Pow(x.SideB, 2))),
        Circle x => new Square(x.Radius),
        Square x => new Circle(x.Side),
        _ => throw new ArgumentException($"Shape transformation of type {input.GetType().Name} is not supported")
    };

    private static bool CommonTryParse(string? input, Type type, out object? value)
    {
        try
        {
            value = Convert.ChangeType(input, type);
            return value != null;
        }
        catch
        {
            value = null;
            return false;
        }
    }
}