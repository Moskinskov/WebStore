var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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