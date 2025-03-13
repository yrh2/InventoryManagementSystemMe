using Microsoft.AspNetCore.Mvc;

public class InfoController : Controller
{
    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult FAQ()
    {
        return View();
    }
}

