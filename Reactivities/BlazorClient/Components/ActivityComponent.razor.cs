namespace BlazorClient.Components;

public partial class ActivityComponent
{
    [Parameter, EditorRequired]
    public Activity Activity { get; set; } = default!;
}
