
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TasksManagmentSystem.core;
using TasksManagmentSystem.core.interfaces;
using TasksManagmentSystem.core.Models;
using TasksManagmentSystem.EF;
using TasksManagmentSystem.EF.Repos;
using TasksManagmentSystem.core.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthService, AuthService>();

//builder.Services.AddTransient(typeof(IBaseRepo<>),typeof(BaseRepo<>));
builder.Services.AddScoped<IUnitofWork, UnitofWork>();

// Add services to the container.

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("constr")));

builder.Services.AddIdentity<User,IdentityRole>()
   .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentityCore<Manager>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentityCore<Member>().AddEntityFrameworkStores<AppDbContext>();

//builder.Services.AddIdentity<Member, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
//builder.Services.AddIdentity<Manager, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
//builder.Services.AddDbContext<AppDbContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("cons")));



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidIssuer = builder.Configuration["JWT:Issuer"],
                       ValidAudience = builder.Configuration["JWT:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                   };
               });
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
