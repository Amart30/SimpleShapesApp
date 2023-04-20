using GeometryTest.Actions;
using GeometryTest.Shapes;

namespace GeometryTest.Menus;

public class DeleteShapesMenu : Menu
{
    protected override MenuItem[] GetMenuItems() => new MenuItem[]
    {
        new ActionMenuItem("Triangle", ShapesActions.DeleteShapesAsync<Triangle>),
        new ActionMenuItem("Rectangle", ShapesActions.DeleteShapesAsync<Rectangle>),
        new ActionMenuItem("Square", ShapesActions.DeleteShapesAsync<Square>),
        new ActionMenuItem("Circle", ShapesActions.DeleteShapesAsync<Circle>),
        new ExitMenuItem("Cancel")
    };
}