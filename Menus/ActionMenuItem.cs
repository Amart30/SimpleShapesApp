namespace GeometryTest.Menus;

public sealed class ActionMenuItem : MenuItem
{
    public ActionMenuItem(string displayName, Func<Task> action) : base(displayName)
    {
        Action = action ?? throw new ArgumentNullException(nameof(action));
    }

    public Func<Task> Action { get; }
}