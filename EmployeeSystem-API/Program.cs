using MyApp.Core.Context;
using MyApp.Core.Interfaces;
using MyApp.Core.Services;
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

builder.Services.AddHttpClient();

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
        ValidateLifetime = true,
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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
