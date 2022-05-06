using BANK.REPOSITORY.Repositories;
using BANK.REPOSITORY.Repositories.Interfaces;
using BANK.WEB.Services;
using BANK.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region [ SET REPOSITORIES ]

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion [ SET REPOSITORIES ]

#region [ SET SERVICES ]

builder.Services.AddScoped<IManagerService, ManagerService>();

#endregion [ SET SERVICES ]

#region [ AUTHENTICATION ]

builder.Services.AddAuthentication("Manager")
    .AddCookie("Manager", options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/management";
        options.LoginPath = "/management";
    });

#endregion [ AUTHENTICATION ]

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
