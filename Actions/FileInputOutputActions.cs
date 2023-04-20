using System.Text.Json;
using System.Text.Json.Serialization;
using GeometryTest.Shapes;

namespace GeometryTest.Actions;

public static class FileInputOutputActions
{
    public static async Task SaveShapesAsync()
    {
        Console.Clear();

        Console.Write("Enter a filename: ");
        var fileName = Console.ReadLine();

        if (IsFileNameValid(fileName))
        {
            try
            {
                var filePath = GetFilePathTxt(fileName);
                await using var fileStream = File.Create(filePath);

                var jsonItems = ShapesRepository.GetAll().Select(ConvertToJsonItem).ToList();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                };

                await JsonSerializer.SerializeAsync(fileStream, jsonItems, options);
                Console.WriteLine("Saving completed successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not save shapes to file {fileName}: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid filename");
        }

        Console.ReadKey();
    }

    public static async Task UploadShapesAsync()
    {
        Console.Clear();

        Console.Write("Enter a filename: ");
        var fileName = Console.ReadLine();

        if (IsFileNameValid(fileName))
        {
            try
            {
                var filePath = GetFilePathJson(fileName);
                await using var fileStream = File.OpenRead(filePath);

                var jsonItems = await JsonSerializer.DeserializeAsync<IEnumerable<JsonItem>>(fileStream)
                    ?? throw new Exception("Deserialization failure");
                ShapesRepository.AddMany(jsonItems.Select(ConvertToShape));

                Console.WriteLine("All shapes have been uploaded");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not upload shapes from file {fileName}: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid filename");
        }

        Console.ReadKey();
    }

    private static bool IsFileNameValid(string? fileName) =>
        !string.IsNullOrWhiteSpace(fileName) &&
        fileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;

    private static string GetFilePathTxt(string? fileName) => $"./{fileName}.txt";
    private static string GetFilePathJson(string? fileName) => $"./{fileName}.json";

    private static JsonItem ConvertToJsonItem(Shape shape) => shape switch
    {
        Triangle x => new JsonItem("Triangle", null, x.SideA, x.SideB, x.SideC, x.Perimeter),
        Rectangle x => new JsonItem("Rectangle", null, x.SideA, x.SideB, null, x.Perimeter),
        Circle x => new JsonItem("Circle", x.Radius, null, null, null, x.Perimeter),
        Square x => new JsonItem("Square", null, x.Side, null, null, x.Perimeter),
        _ => throw new ArgumentException($"Shape converting of type {shape.GetType().Name} is not supported")
    };

    private static Shape ConvertToShape(JsonItem item) => item switch
    {
        { Radius: not null } => new Circle(item.Radius.Value),
        { SideA: not null, SideB: not null, SideC: not null } =>
            new Triangle(item.SideA.Value, item.SideB.Value, item.SideC.Value),
        { SideA: not null, SideB: not null } => new Rectangle(item.SideA.Value, item.SideB.Value),
        { SideA: not null } => new Square(item.SideA.Value),
        _ => throw new ArgumentException("Input value is not supported")
    };

    private record JsonItem(string TypeShape, double? Radius, double? SideA, double? SideB, double? SideC, double? Perimeter);
}