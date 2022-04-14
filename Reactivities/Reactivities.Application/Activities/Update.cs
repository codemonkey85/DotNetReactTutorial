namespace Reactivities.Application.Activities;
public class Update
{
    public record Command(Activity? Activity) : IRequest;

    public record Handler(DataContext Context/*, IMapper Mapper*/) : IRequestHandler<Command>
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

            //Mapper.Map(request.Activity, activity.Id);
            //Mapper.Map(request.Activity, activity.Title);
            //Mapper.Map(request.Activity, activity.Date);
            //Mapper.Map(request.Activity, activity.Description);
            //Mapper.Map(request.Activity, activity.Category);
            //Mapper.Map(request.Activity, activity.City);
            //Mapper.Map(request.Activity, activity.Venue);

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
