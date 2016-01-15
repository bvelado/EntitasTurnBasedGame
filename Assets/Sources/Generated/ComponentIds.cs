public static class ComponentIds {
    public const int Controlable = 0;
    public const int Destroy = 1;
    public const int EndTurn = 2;
    public const int Input = 3;
    public const int Position = 4;
    public const int Resource = 5;
    public const int StartTurn = 6;
    public const int TurnOrder = 7;
    public const int Unit = 8;
    public const int View = 9;

    public const int TotalComponents = 10;

    public static readonly string[] componentNames = {
        "Controlable",
        "Destroy",
        "EndTurn",
        "Input",
        "Position",
        "Resource",
        "StartTurn",
        "TurnOrder",
        "Unit",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(ControlableComponent),
        typeof(DestroyComponent),
        typeof(EndTurnComponent),
        typeof(InputComponent),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(StartTurnComponent),
        typeof(TurnOrderComponent),
        typeof(UnitComponent),
        typeof(ViewComponent)
    };
}