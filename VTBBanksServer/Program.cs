using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using VTBBanksServer.Controllers;
using VTBBanksServer.Data;
using VTBBanksServer.Models;
using VTBBanksServer.Repository;
using VTBBanksServer.Util;

var builder = WebApplication.CreateBuilder(args);

var defaultConnection = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

var connectionString = defaultConnection is null ? builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.") : defaultConnection;

var services = builder.Services;

services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
services.AddAuthorization();

services.AddControllers();

services.AddDbContext<ApplicationDbContext>(options =>
    options.EnableDetailedErrors()
    .EnableSensitiveDataLogging()
    
    .UseNpgsql(connectionString, o =>
    {
        o.EnableRetryOnFailure(2);
    })
    );

services.AddIdentityCore<User>(o => o.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<BankOfficeRepository>();
services.AddScoped<CashMachineRepository>();

var app = builder.Build();

app.MapIdentityApi<User>();

//app.MapGet("/special", () =>
//{
//    return Results.Ok();
//}).RequireAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();