namespace BlazorWasm.Client.Shared.Ui.Components;

public enum ButtonType
{
    Default = 1,
    Circled,
    CircledInverted
}

public static class ButtonClasses
{
    public const string Default = "button-default";
    public const string Circled = "button-circled";
    public const string CircledInverted = "button-circled-inverted";

    public static string FromType(ButtonType type) => type switch
    {
        ButtonType.Default => Default,
        ButtonType.Circled => Circled,
        ButtonType.CircledInverted => CircledInverted,
        _ => string.Empty
    };
}