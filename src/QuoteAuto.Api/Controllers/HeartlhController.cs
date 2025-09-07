using Microsoft.AspNetCore.Mvc;

namespace QuoteAuto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeartlhController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("QuoteAuto API is running.");
    
}