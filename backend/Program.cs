using Microsoft.EntityFrameworkCore;
using StudioRags.API.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudioRagsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors(options =>           
{
    options.AddPolicy("ReactApp", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();                    
app.UseCors("ReactApp");                      
app.MapControllers();     

app.Run();                                   