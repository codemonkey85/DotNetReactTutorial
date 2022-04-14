namespace Reactivities.Api.Activities;

public static class ActivitiesApi
{
    private const string ApiUrl = @"api/activities";

    public static void MapActivitiesApi(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiUrl, GetActivities).WithName(nameof(GetActivities)).WithDisplayName(nameof(GetActivities));
        app.MapGet($"{ApiUrl}/{{id}}", GetActivity).WithName(nameof(GetActivity)).WithDisplayName(nameof(GetActivity));
        app.MapPost(ApiUrl, CreateActivity).WithName(nameof(CreateActivity)).WithDisplayName(nameof(CreateActivity));
        app.MapPut(ApiUrl, UpdateActivity).WithName(nameof(UpdateActivity)).WithDisplayName(nameof(UpdateActivity));
        app.MapDelete($"{ApiUrl}/{{id}}", DeleteActivity).WithName(nameof(DeleteActivity)).WithDisplayName(nameof(DeleteActivity));
    }

    private static async Task<IResult> GetActivities([FromServices] IMediator mediator) =>
        Results.Ok(await mediator.Send(new ActivityList.Query()));

    private static async Task<IResult> GetActivity([FromServices] IMediator mediator, Guid id) =>
        Results.Ok(await mediator.Send(new Details.Query(id)));

    private static async Task<IResult> CreateActivity([FromServices] IMediator mediator, Activity activity) =>
        Results.Ok(await mediator.Send(new Create.Command(activity)));

    private static async Task<IResult> UpdateActivity([FromServices] IMediator mediator, Activity activity) =>
        Results.Ok(await mediator.Send(new Update.Command(activity)));

    private static async Task<IResult> DeleteActivity([FromServices] IMediator mediator, Guid id) =>
        Results.Ok(await mediator.Send(new Delete.Command(id)));
}
