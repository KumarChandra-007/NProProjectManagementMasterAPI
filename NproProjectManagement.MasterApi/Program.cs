using Microsoft.EntityFrameworkCore;
using NproProjectManagement.Common.Entities;
using Repositories.Interface;
using Repositories.Repository;
using Services.Interface;
using Services.Service;

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

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NproContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:NproDBConncetion")));

builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<IMasterRepository, MasterRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Npro Application");
    });
}

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
