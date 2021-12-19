using WebStore.Infrastructure.Convensions;
using WebStore.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
services.AddControllersWithViews(options => { options.Conventions.Add(new TestConvension()); });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseWelcomePage("/welcome");

app.UseMiddleware<TestMiddleware>();

// app.MapDefaultControllerRoute();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


app.Run();