namespace Reactivities.Application.Activities;

public class Delete
{
    public record class Command(Guid Id) : IRequest;

    public record class Handler(DataContext Context) : IRequestHandler<Command>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await Context.Activities.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
            if (activity is null)
            {
                return Unit.Value;
            }

            Context.Remove(activity);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
