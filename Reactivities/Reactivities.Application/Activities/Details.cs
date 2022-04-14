namespace Reactivities.Application.Activities;

public class Details
{
    public record class Query(Guid Id) : IRequest<Activity>;

    public record class Handler(DataContext Context) : IRequestHandler<Query, Activity?>
    {
        public async Task<Activity?> Handle(Query request, CancellationToken cancellationToken) =>
            await Context.Activities.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
    }
}
