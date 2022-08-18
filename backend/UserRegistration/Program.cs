using Microsoft.EntityFrameworkCore;
using UserRegistration.Data;
using UserRegistration.Services.UserServices;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUserServices, UserServices>();

// Serilog setup
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/logs.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateBootstrapLogger();
builder.Host.UseSerilog();

var app = builder.Build();

// Apply migrations on StartUp
var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
dataContext.Database.Migrate();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
