using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers;

public class Home : Controller
{
    // GET
    public IActionResult Index()
    {
        return Content("in 'index'-method");
    }
}