using GeometryTest.Actions;
using GeometryTest.Shapes;

namespace GeometryTest.Menus;

public class AddShapeMenu : Menu
{
    protected override MenuItem[] GetMenuItems() => new MenuItem[]
    {
        new ActionMenuItem("Triangle", ShapesActions.AddShapeAsync<Triangle>),
        new ActionMenuItem("Rectangle", ShapesActions.AddShapeAsync<Rectangle>),
        new ActionMenuItem("Square", ShapesActions.AddShapeAsync<Square>),
        new ActionMenuItem("Circle", ShapesActions.AddShapeAsync<Circle>),
        new ExitMenuItem("Cancel")
    };
}