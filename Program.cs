using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

var builder = WebApplication.CreateBuilder(args);

// var connectionString = builder.Configuration.GetConnectionString("AppDbSqlite") ?? "Data Source=sqlite.db";

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext <AppDbContext> (o 
    => o.UseNpgsql(builder.Configuration.GetConnectionString("AppDbConnectionString"))
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
        .EnableSensitiveDataLogging());
// builder.Services.AddSqlite<AppDbContext>(connectionString);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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
