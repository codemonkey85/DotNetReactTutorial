namespace Reactivities.Application.Activities;

public class Create
{
    public record class Command(Activity? Activity) : IRequest;

    public record class Handler(DataContext Context) : IRequestHandler<Command>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            Context.Activities.Add(request.Activity!);
            await Context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
