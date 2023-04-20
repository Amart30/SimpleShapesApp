using GeometryTest.Actions;

namespace GeometryTest.Menus;

public class MainMenu : Menu
{
    protected override MenuItem[] GetMenuItems() => new MenuItem[]
    {
        new ActionMenuItem("Add a new shape", MenuActions.DisplayAddShapeMenuAsync),
        new ActionMenuItem("View all shapes", ShapesActions.ViewAllShapesAsync),
        new ActionMenuItem("Delete shapes", MenuActions.DisplayDeleteShapesMenuAsync),
        new ActionMenuItem("Perform the transformation", ShapesActions.TransformAllShapesAsync),
        new ActionMenuItem("Save shapes", FileInputOutputActions.SaveShapesAsync),
        new ActionMenuItem("Upload shapes", FileInputOutputActions.UploadShapesAsync),
        new ExitMenuItem("Exit")
    };
}