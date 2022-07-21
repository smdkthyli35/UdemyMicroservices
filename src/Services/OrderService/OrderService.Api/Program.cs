using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Features.Commands.CreateOrder;
using OrderService.Infrastructure.Context;
using System.Reflection;
using UdemyMicroservices.Common.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
    {
        configure.MigrationsAssembly("OrderService.Infrastructure");
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICommonIdentityService, CommonIdentityService>();

builder.Services.AddMediatR(typeof(CreateOrderCommandHandler).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
