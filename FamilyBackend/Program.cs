using FamilyBackend.Context;
using FamilyBackend.DatabaseContexts;
using FamilyBackend.Services.Interfaces;
using FamilyBackend.Services;
using Microsoft.EntityFrameworkCore;
using FamilyBackend.Repositories.Interfaces;
using FamilyBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Connectionstring to db
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFamilyMessageService, FamilyMessageService>();
builder.Services.AddScoped<IFamilyMessageRepository, FamilyMessageRepository>();

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


//Add dummy data to the database on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<DatabaseContext>();
        var dummyDataGenerator = new DummyDataGenerator(dbContext);
        dummyDataGenerator.DeleteItemsInDatabase();
        dummyDataGenerator.GenerateDummyData();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while generating dummy data: " + ex.Message);
    }
}

app.Run();
