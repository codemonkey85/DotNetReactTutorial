namespace BlazorClient.Components;

public partial class ActivitiesListComponent
{
    private IList<Activity> activities = Array.Empty<Activity>();

    protected override async Task OnInitializedAsync() =>
        activities = (await ActivitiesApiService.GetActivitiesAsync())?.OrderBy(activity => activity.Date).ToArray() ?? Array.Empty<Activity>();
}
