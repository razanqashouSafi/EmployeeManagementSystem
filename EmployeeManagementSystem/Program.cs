
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Context;
using MyApp.Core.Interfaces;
using MyApp.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<EmployeeManagementDbContextb>(opt =>
//    opt.UseSqlServer("Data Source=LENOVO5014G\\SQLEXPRESS;Initial Catalog=PasswordManagerDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

builder.Services.AddDbContext<EmployeeManagementDbContextb>(opt => opt.UseSqlServer("Data Source=MSI\\SQLEXPRESS13;Initial Catalog=EmployeeManagerDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddHttpClient();
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IAdminAuth, AdminAuthService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async (context, next) =>
//{
//    var watch = System.Diagnostics.Stopwatch.StartNew();

//    await next(); // كمل الطلب

//    watch.Stop();
//    var time = watch.ElapsedMilliseconds;

//    context.Response.WriteAsync($"⌛ الوقت المستغرق: {time} مللي ثانية");
//});


app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Server error occurred, please try again later.");
    }
});






app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapRazorPages();

app.Run();
