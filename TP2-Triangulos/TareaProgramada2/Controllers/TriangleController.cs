using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TareaProgramada2.Models;
namespace TareaProgramada2.Controllers;
public class TriangleController : Controller
{
    private readonly ILogger<TriangleController> _logger;
    public TriangleController(ILogger<TriangleController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    public IActionResult Calculate(double a, double b, double c)
    {
        var triangle = new TriangleModel { A = a, B = b, C = c };
        if (!triangle.IsValid())
        {
            ViewBag.Error = "Los valores ingresados no forman un triángulo válido.";
            return View("Index");
        }
        ViewBag.Perimeter = triangle.Perimeter();
        ViewBag.SemiPerimeter = triangle.SemiPerimeter();
        ViewBag.Area = triangle.Area();
        ViewBag.Type = triangle.TriangleType();
        
        var (angleA, angleB, angleC) = triangle.CalculateAngles();
        ViewBag.Angles = (angleA, angleB, angleC);
        
        return View("Index");
    }
}
