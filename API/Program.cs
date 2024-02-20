using Data;
using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

var urlForCors = "myPolicy";
builder.Services.AddCors(options => options.AddPolicy(name: urlForCors, builder => 
{
    builder.AllowAnyOrigin().AllowAnyMethod();
}));

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

ApplicationDbContext.CoonnectionString = builder.Configuration.GetConnectionString("WebEducacionIT");



app.UseCors(urlForCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
