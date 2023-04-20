namespace GeometryTest.Menus;

public abstract class Menu
{
    protected abstract MenuItem[] GetMenuItems();
    public async Task DisplayAsync()
    {
        var menuItems = GetMenuItems();
        MenuManager manager = new(menuItems);
        await manager.ManageAsync();
    }
}