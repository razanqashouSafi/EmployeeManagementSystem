using EmployeeManagementSystem.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<EmployeeManagementDbContextb>(opt =>
//    opt.UseSqlServer("Data Source=LENOVO5014G\\SQLEXPRESS;Initial Catalog=PasswordManagerDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

builder.Services.AddDbContext<EmployeeManagementDbContextb>(opt => opt.UseSqlServer("Data Source=MSI\\SQLEXPRESS13;Initial Catalog=EmployeeManagerDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
