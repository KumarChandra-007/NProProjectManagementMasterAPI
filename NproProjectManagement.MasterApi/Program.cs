using AutoMapper;
using Common.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories.Interface;
using Repositories.Repository;
using Services;
using Services.Interface;
using Services.Service;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
//var jwtIssuer = builder.Configuration.GetSection("JWT:Issuer").Get<string>();
//var jwtKey = builder.Configuration.GetSection("JWT:Secret").Get<string>();


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtIssuer,
//        ValidAudience = jwtIssuer,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
//    };
//});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization Header using the bearer scheme. Enter Bearer Token",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Scheme = "Bearer"
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
//    {{
//        new OpenApiSecurityScheme
//        {
//            Reference = new OpenApiReference
//            {
//                Id = "Bearer",
//                Type = ReferenceType.SecurityScheme
//            },
//            Scheme = "oauth2",
//            Name = "Bearer",
//            In =  ParameterLocation.Header
//        },
//        new List<string>()
//        }
//    });
//});
builder.Services.AddDbContext<NproContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:NproDBConncetion")));

builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<IMasterRepository, MasterRepository>();
//builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddScoped<AuthHelpers>();
//builder.Services.AddSwaggerGen(c =>
//  {
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
//  });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Npro Application");
    });
}
//app.UseSwagger();
//app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
