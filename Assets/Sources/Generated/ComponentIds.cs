public static class ComponentIds {
    public const int Controlable = 0;
    public const int Destroy = 1;
    public const int EndTurn = 2;
    public const int Input = 3;
    public const int StartTurn = 4;
    public const int TurnOrder = 5;
    public const int Unit = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "Controlable",
        "Destroy",
        "EndTurn",
        "Input",
        "StartTurn",
        "TurnOrder",
        "Unit"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(ControlableComponent),
        typeof(DestroyComponent),
        typeof(EndTurnComponent),
        typeof(InputComponent),
        typeof(StartTurnComponent),
        typeof(TurnOrderComponent),
        typeof(UnitComponent)
    };
}