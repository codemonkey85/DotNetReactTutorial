namespace BlazorClient.Components;

public partial class ActivitiesListComponent
{
    private Activity[] activities = Array.Empty<Activity>();

    protected override async Task OnInitializedAsync() =>
        activities = await ActivitiesApiService.GetActivitiesAsync() ?? Array.Empty<Activity>();
}
