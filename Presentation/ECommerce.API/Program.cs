using ECommerce.Application;
using ECommerce.Insfrastructure;
using ECommerce.Persistence;

var builder = WebApplication.CreateBuilder(args);


//Add to DI container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices()
    .AddInfrastructureServices()
    .AddPersistenceServices();

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
