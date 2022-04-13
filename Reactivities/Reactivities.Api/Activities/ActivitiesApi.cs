namespace Reactivities.Api.Activities;

public static class ActivitiesApi
{
    private const string ApiUrl = @"/activities";

    public static void MapActivitiesApi(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiUrl, GetActivities).WithName(nameof(GetActivities)).WithDisplayName(nameof(GetActivities));
        app.MapGet($"{ApiUrl}/{{id}}", GetActivity).WithName(nameof(GetActivity)).WithDisplayName(nameof(GetActivity));
        app.MapPost(ApiUrl, CreateActivity).WithName(nameof(CreateActivity)).WithDisplayName(nameof(CreateActivity));
        app.MapPut(ApiUrl, UpdateActivity).WithName(nameof(UpdateActivity)).WithDisplayName(nameof(UpdateActivity));
        app.MapDelete($"{ApiUrl}/{{id}}", DeleteActivity).WithName(nameof(DeleteActivity)).WithDisplayName(nameof(DeleteActivity));
    }

    private static async Task<IResult> GetActivities([FromServices] DataContext context) =>
        Results.Ok(await context.Activities.ToArrayAsync());

    private static async Task<IResult> GetActivity([FromServices] DataContext context, Guid id) =>
        Results.Ok(await context.Activities.FirstOrDefaultAsync(a => a.Id == id));

    private static async Task<IResult> CreateActivity([FromServices] DataContext context, Activity activity) => throw new NotImplementedException();

    private static async Task<IResult> UpdateActivity([FromServices] DataContext context, Activity activity) => throw new NotImplementedException();

    private static async Task DeleteActivity([FromServices] DataContext context, Guid id) => throw new NotImplementedException();
}
