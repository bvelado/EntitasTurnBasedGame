public static class ComponentIds {
    public const int Control = 0;
    public const int EndTurn = 1;
    public const int Input = 2;
    public const int StartTurn = 3;
    public const int TurnManager = 4;
    public const int TurnOrder = 5;
    public const int Unit = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "Control",
        "EndTurn",
        "Input",
        "StartTurn",
        "TurnManager",
        "TurnOrder",
        "Unit"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(ControlComponent),
        typeof(EndTurnComponent),
        typeof(InputComponent),
        typeof(StartTurnComponent),
        typeof(TurnManagerComponent),
        typeof(TurnOrderComponent),
        typeof(UnitComponent)
    };
}