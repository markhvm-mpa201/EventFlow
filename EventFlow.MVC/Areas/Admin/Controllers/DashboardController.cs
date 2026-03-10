using Microsoft.AspNetCore.Mvc;

namespace EventFlow.MVC.Properties.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
