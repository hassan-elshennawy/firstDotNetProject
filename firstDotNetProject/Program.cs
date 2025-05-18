using firstDotNetProject.Config;
using firstDotNetProject.DAL;
using firstDotNetProject.DSL;
using firstDotNetProject.Entities.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

    options.SerializerOptions.PropertyNameCaseInsensitive = true;

    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

//builder.Services.AddEndpointsApiExplorer();
/////////////////builder.Services.AddSwaggerGen();

// JWT Authentication setup
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"]!)
            )
        };
    });

// Authorization
//builder.Services.AddAuthorization();

// Dependency Injection for your services
builder.Services.AddScoped<JwtAuthService>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<UseresDAL>();
builder.Services.AddScoped<UsersDSL>();




var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
  //  app.UseSwagger();
    //app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();    
app.UseAuthorization();     
app.MapControllers();      

app.Run();

