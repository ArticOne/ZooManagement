using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZooManagement.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var useSqlServer = builder.Configuration.GetValue<bool>("UseSqlServer", false);

if (useSqlServer)
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServer");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb"));
}




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
