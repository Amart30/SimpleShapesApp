namespace GeometryTest.Menus;
public class MenuManager
{
    private readonly MenuItem[] _menuItems;

    public MenuManager(MenuItem[] menuItems)
    {
        _menuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));
    }

    public async Task ManageAsync()
    {
        var exitRequired = false;

        do
        {
            ClearAndShowHeading(GetType().Name == "MainMenu" ? "Main Menu" : "Shape Menu");

            DisplayMenu();

            Console.Write($"\nPlease type the one you would like to perform (1 - {_menuItems.Length}): ");

            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;

            if (!int.TryParse(Console.ReadLine(), out var itemId) || itemId < 0 || itemId > _menuItems.Length)
            {
                Console.SetCursorPosition(origCol - 1, origRow);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(origCol, origRow);
            }
            else
            {
                var menuItem = _menuItems[itemId - 1];

                if (menuItem is ActionMenuItem actionMenuItem)
                {
                    await actionMenuItem.Action();
                }
                else if (menuItem is ExitMenuItem)
                {
                    exitRequired = true;
                }
            }
        }
        while (!exitRequired);
    }

    private void DisplayMenu()
    {
        for (var i = 0; i < _menuItems.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {_menuItems[i].DisplayName}");
        }
    }

    public static void ClearAndShowHeading(string heading)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(heading);
        Console.WriteLine(new string('-', heading?.Length ?? 0));
        Console.ResetColor();
    }
}