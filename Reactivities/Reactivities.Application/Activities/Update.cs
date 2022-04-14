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

            activity.Id = request.Activity.Id;
            activity.Title = request.Activity.Title; // ?? activity.Title;
            activity.Date = request.Activity.Date; // ?? activity.Date;
            activity.Description = request.Activity.Description; // ?? activity.Description;
            activity.Category = request.Activity.Category; // ?? activity.Category;
            activity.City = request.Activity.City; // ?? activity.City;
            activity.Venue = request.Activity.Venue; // ?? activity.Venue;

            await Context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
