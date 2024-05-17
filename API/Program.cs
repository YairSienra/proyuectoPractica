using Data;
using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

var urlForCors = "myPolicy";
builder.Services.AddCors(options => options.AddPolicy(name: urlForCors, builder => 
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition(
        "Bearer", 
             new OpenApiSecurityScheme()
             {
                 Description = "Autorizacion",
                 Name = "Authorizacion",
                 BearerFormat = "JWT",
                 In = ParameterLocation.Header,
                 Type = SecuritySchemeType.Http,
                 Scheme = "bearer"
             });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
             {
                 {
                     new OpenApiSecurityScheme
                     {
                         Reference = new OpenApiReference
                         {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                         }
                     },
                     new string[]{}
                 }
             });
});
builder.Services.AddAuthentication( opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.SaveToken = true;
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Firma"]))
    };
});


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
