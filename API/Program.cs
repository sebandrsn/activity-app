using ActivityApp;
using ActivityApp.Application;
using ActivityApp.Persistance;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(config);
builder.Services.AddServices(builder.Environment);

Console.WriteLine($"Current environment: {builder.Environment.EnvironmentName}");    

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

if (app.Environment.IsDevelopment())
    app.UseCors("localhost");

app.Run();
