public static class ComponentIds {
    public const int Controlable = 0;
    public const int EndTurn = 1;
    public const int Input = 2;
    public const int StartTurn = 3;
    public const int TurnManager = 4;
    public const int TurnOrder = 5;
    public const int Unit = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "Controlable",
        "EndTurn",
        "Input",
        "StartTurn",
        "TurnManager",
        "TurnOrder",
        "Unit"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(ControlableComponent),
        typeof(EndTurnComponent),
        typeof(InputComponent),
        typeof(StartTurnComponent),
        typeof(TurnManagerComponent),
        typeof(TurnOrderComponent),
        typeof(UnitComponent)
    };
}