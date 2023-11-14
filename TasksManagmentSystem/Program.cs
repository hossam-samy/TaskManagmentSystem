
using Microsoft.EntityFrameworkCore;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;
using TasksManagmentSystem.EF;
using TasksManagmentSystem.EF.Repos;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient(typeof(IBaseRepo<>),typeof(BaseRepo<>));
builder.Services.AddTransient<IUnitofWork, UnitofWork>();
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("defstr"),b=>b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
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

app.Run();
