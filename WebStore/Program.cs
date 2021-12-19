using WebStore.Infrastructure.Convensions;

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

// app.MapDefaultControllerRoute();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


app.Run();