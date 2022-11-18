using BL;
using DAL;
using DAL.Commands;
using DAL.Queries;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppointmentDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IAppointmentBusinessLogic, AppointmentBusinessLogic>();
builder.Services.AddScoped<IAppointmentCommands, AppointmentCommands>();
builder.Services.AddScoped<IAppointmentQueries, AppointmentQueries>();
builder.Services.AddScoped<IAppointmentQueriesRepository, AppointmentQueriesRepository>();
builder.Services.AddScoped<IAppointmentCommandsRepository, AppointmentCommandsRepository>();

var app = builder.Build();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
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

