using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyTaskDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TaskConnection")));
builder.Services.AddTransient<IMyTaskRepository, MyTaskRespository>();
builder.Services.AddTransient<IMyTaskService, MyTaskService>();
builder.Services.AddControllers();
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
