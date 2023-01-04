using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Fun;

namespace WebApplication1.Controller;

[Route("api/[controller]")]
[ApiController]
public class XmlApiController : ControllerBase
{
    [HttpPost]
    public IActionResult ProcessXml()
    {
        var request = HttpContext.Request;
        XDocument xdoc = new XDocument();
        
        // Process the XML document here
        // ...

        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Here");
    }
}