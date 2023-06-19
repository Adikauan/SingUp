using MassTransit;
using MassTransit.SingUp.Application.Commands.Create;
using MassTransit.SingUp.Application.IntegrationEvents;
using MassTransit.SingUp.Application.IntegrationEvents.Events;
using MassTransit.SingUp.Application.IntegrationEvents.Interfaces;
using MassTransit.SingUp.Application.IntegrationEvents.Models;
using MassTransit.SingUp.Domain.Interfaces;
using MassTransit.SingUp.Infrastructure.EntityFramework.Context;
using MassTransit.SingUp.Infrastructure.EntityFramework.Repositories;
using MassTransit.Transports.Fabric;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(bus =>
{
    bus.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
    

});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => cfg.AllowNullCollections = true);
string? SqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SingUpDbContext>(options => options.UseSqlServer(SqlConnection)
                                            , ServiceLifetime.Scoped);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(CreateCommand).Assembly);
});
builder.Services.AddAutoMapper(typeof(CreateCommand).Assembly);

builder.Services.AddScoped<IBus>(provider =>
{
    var busControl = provider.GetRequiredService<IBusControl>();
    return busControl;
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserCreatedEventHandling, UserCreatedEventHandling>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
