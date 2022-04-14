namespace Reactivities.Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options => options.AddPolicy("AllowAnyOrigin", policy => policy.AllowAnyOrigin()
                                                                                                .AllowAnyHeader()
                                                                                                .AllowAnyMethod()));

        builder.Services.AddMediatR(typeof(ActivityList.Handler).Assembly);
        builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

        return builder;
    }
}
