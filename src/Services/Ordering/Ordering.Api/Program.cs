var builder = WebApplication.CreateBuilder(args);

// Add servies to the container
var app = builder.Build();

// Configure the HTTP request pipeline

app.Run();
