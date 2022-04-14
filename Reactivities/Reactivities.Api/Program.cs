var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("AllowAnyOrigin", policy => policy.AllowAnyOrigin()
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.MapActivitiesApi();

await app.RunAsync();
