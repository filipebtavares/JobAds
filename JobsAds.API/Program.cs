using JobsAds.API.Application.Service;
using JobsAds.API.Domain.Entity;
using JobsAds.API.Infrastructure.Persistence;
using JobsAds.API.Presentation.Middlewares.ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<JobAdsDbContext>(options =>
    options.UseInMemoryDatabase("JobAdsDb"),
    contextLifetime: ServiceLifetime.Singleton,
    optionsLifetime: ServiceLifetime.Singleton);
builder.Services.AddControllers();
builder.Services.AddScoped<IJobService, JobService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
