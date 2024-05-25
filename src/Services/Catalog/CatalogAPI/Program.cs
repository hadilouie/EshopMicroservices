



var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
//Add services to the container.

builder.Services.AddMediatR(config =>
{
config.RegisterServicesFromAssemblies(assembly);
config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("CatalogDB")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.UseExceptionHandler(option => { });

app.Run();
