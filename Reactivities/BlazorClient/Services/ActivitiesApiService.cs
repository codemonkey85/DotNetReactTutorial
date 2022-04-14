namespace BlazorClient.Services;

public record ActivitiesApiService(HttpClient HttpClient)
{
    private const string ApiUrl = @"api/activities";

    public async Task<Activity[]?> GetActivitiesAsync() => await HttpClient.GetFromJsonAsync<Activity[]>(ApiUrl);

    public async Task<Activity?> GetActivityAsync(Guid id) => await HttpClient.GetFromJsonAsync<Activity>($"{ApiUrl}/{id}");

    public async Task CreateActivityAsync(Activity activity) => await HttpClient.PostAsJsonAsync(ApiUrl, activity);

    public async Task UpdateActivityAsync(Activity activity) => await HttpClient.PutAsJsonAsync(ApiUrl, activity);

    public async Task DeleteActivityAsync(Guid id) => await HttpClient.DeleteAsync($"{ApiUrl}/{id}");
}
