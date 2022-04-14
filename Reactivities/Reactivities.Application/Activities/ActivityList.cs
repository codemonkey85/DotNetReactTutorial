namespace Reactivities.Application.Activities;

public class ActivityList
{
    public record Query : IRequest<List<Activity>>;

    public record Handler(DataContext Context) : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken) =>
            await Context.Activities.ToListAsync(cancellationToken);
    }
}
