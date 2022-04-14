namespace Reactivities.Application.Activities;
public class Update
{
    public record Command(Activity? Activity) : IRequest;

    public record Handler(DataContext Context) : IRequestHandler<Command>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request.Activity is null)
            {
                return Unit.Value;
            }

            var activity = await Context.Activities.FindAsync(new object?[] { request.Activity.Id }, cancellationToken: cancellationToken);
            if (activity is null)
            {
                return Unit.Value;
            }

            (
                activity.Id,
                activity.Title,
                activity.Date,
                activity.Description,
                activity.Category,
                activity.City,
                activity.Venue
            ) =
            (
                request.Activity.Id,
                request.Activity.Title,
                request.Activity.Date,
                request.Activity.Description,
                request.Activity.Category,
                request.Activity.City,
                request.Activity.Venue
            );

            await Context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
