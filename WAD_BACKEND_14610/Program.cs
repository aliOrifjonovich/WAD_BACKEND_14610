using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14610.Data;
using WAD_BACKEND_14610.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EventManagementDbContext>(
    e => e.UseSqlServer(builder.Configuration.GetConnectionString("EventManagementConnectionString"))
    );
builder.Services.AddScoped<IEventManagementRepository, EventManagementRepository>();
builder.Services.AddScoped<IEventAttendeesRepository, EventAttendeesRepository>();

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
