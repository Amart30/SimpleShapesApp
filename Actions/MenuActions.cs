using GeometryTest.Menus;

namespace GeometryTest.Actions;

public static class MenuActions
{
    public static async Task DisplayMainMenuAsync()
    {
        MainMenu menu = new();
        await menu.DisplayAsync();
    }

    public static async Task DisplayAddShapeMenuAsync()
    {
        AddShapeMenu menu = new();
        await menu.DisplayAsync();
    }

    public static async Task DisplayDeleteShapesMenuAsync()
    {
        DeleteShapesMenu menu = new();
        await menu.DisplayAsync();
    }
}