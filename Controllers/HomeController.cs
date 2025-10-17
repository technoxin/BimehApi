using Microsoft.AspNetCore.Mvc;

namespace BimehApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Welcome Bimeh API ASP.NET Core 9, Swagger" });
    }
}