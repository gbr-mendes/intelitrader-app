using Microsoft.EntityFrameworkCore;
using UserRegistration.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
);

var app = builder.Build();

// Apply migrations on StartUp
var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<UserContext>();
dataContext.Database.Migrate();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
