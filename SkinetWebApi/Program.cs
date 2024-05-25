using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SkinetDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DevDefaultConnection"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var dbContext = services.GetRequiredService<SkinetDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await dbContext.Database.MigrateAsync();
    await SkinetDbContextSeed.SeedAsync(dbContext);
}
catch(Exception e)
{
    logger.LogError($"An error occurred during the migration: {e}");
}

app.Run();
