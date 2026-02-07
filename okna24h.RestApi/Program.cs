using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;    
using okna24h.Data.Data.Users;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Okna24hContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Okna24hContext") ?? throw new InvalidOperationException("Connection string 'okna24hIntranetContext' not found.")));
// Add services to the container.

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
