using EmployeeManagementSystem.Context;
using EmployeeSystem_API.Interfaces;
using EmployeeSystem_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeManagementDbContextb>(opt => opt.UseSqlServer("Data Source=MSI\\SQLEXPRESS13;Initial Catalog=EmployeeManagerDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddScoped<IEmployee, EmployeeService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
