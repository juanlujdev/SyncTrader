using Microsoft.EntityFrameworkCore;
using SyncTrader.Application.Interfaces;
using SyncTrader.Application.Services;
using SyncTrader.Domain.Repositories;
using SyncTrader.Infrastructure.Persistence;
using SyncTrader.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SyncTraderDbTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SyncTraderDB")));

// **Registro de servicios y repositorios**
builder.Services.AddScoped<IStatusActionService, StatusActionService>();
builder.Services.AddScoped<IStatusActionRepository, StatusActionRepository>();
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
