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

    private static async Task<IResult> GetActivities([FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        Results.Ok(await mediator.Send(new ActivityList.Query(), cancellationToken));

    private static async Task<IResult> GetActivity([FromServices] IMediator mediator, Guid id, CancellationToken cancellationToken) =>
        Results.Ok(await mediator.Send(new Details.Query(id), cancellationToken));

    private static async Task<IResult> CreateActivity([FromServices] IMediator mediator, Activity activity, CancellationToken cancellationToken) =>
        Results.Ok(await mediator.Send(new Create.Command(activity), cancellationToken));

    private static async Task<IResult> UpdateActivity([FromServices] IMediator mediator, Activity activity, CancellationToken cancellationToken) =>
        Results.Ok(await mediator.Send(new Update.Command(activity), cancellationToken));

    private static async Task<IResult> DeleteActivity([FromServices] IMediator mediator, Guid id, CancellationToken cancellationToken) =>
        Results.Ok(await mediator.Send(new Delete.Command(id), cancellationToken));
}
