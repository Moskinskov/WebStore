using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers;

public class Home : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public string ConfiguredAction(string id, string arg0, string arg1)
    {
        return $"id - {id}\n" +
               $"v1 - {arg0}\n" +
               $"v2 - {arg1}";
    }
}