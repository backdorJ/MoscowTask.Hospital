using MoscowTask.API.Configurations;
using MoscowTask.Core;
using MoscowTask.DAL.MS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.ConfigureCustomDbContext(builder.Configuration);
builder.Services.AddDal();
builder.Services.AddCore();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetRequiredService<Migrator>();
await migrator.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();