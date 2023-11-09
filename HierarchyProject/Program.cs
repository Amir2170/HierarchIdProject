using HierarchyProject.Data;
using Microsoft.EntityFrameworkCore;
using HierarchyProject.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Db context configuration
builder.Services.AddDbContext<MyAppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
x => x.UseHierarchyId()));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// calling seed data to seed db
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.initialize(services);
}

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
