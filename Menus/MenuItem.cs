namespace GeometryTest.Menus;

public abstract class MenuItem
{
    protected MenuItem(string displayName)
    {
        DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
    }

    public string DisplayName { get; }
}