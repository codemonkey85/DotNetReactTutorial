namespace Reactivities.Application.Activities;

public class ActivityList
{
    public record class Query : IRequest<List<Activity>>;

    public record class Handler(DataContext Context) : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken) =>
            await Context.Activities.ToListAsync(cancellationToken);
    }
}
