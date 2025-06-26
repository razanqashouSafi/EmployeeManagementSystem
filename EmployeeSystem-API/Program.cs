using EmployeeManagementSystem.Context;
using EmployeeSystem_API.Interfaces;
using EmployeeSystem_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeManagementDbContextb>(opt =>
    opt.UseSqlServer(
        "Data Source=MSI\\SQLEXPRESS13;Initial Catalog=EmployeeManagerDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True",
        b => b.MigrationsAssembly("MyApp.Core"))
);

builder.Services.AddScoped<IEmployee, EmployeeService>();

builder.Services.AddScoped<IAdminAuth, AdminAuthService>();


var secretKey = "LongPrimarySecrectForEmployeeManagerSystemASPCoreModuleForDevelopementPurppose";
var key = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
