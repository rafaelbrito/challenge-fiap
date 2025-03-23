using Microsoft.AspNetCore.Mvc;

namespace Contatos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocsController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetRedocHtml()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documentacao", "redoc.html");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("O arquivo redoc.html não foi encontrado.");
            }

            return PhysicalFile(filePath, "text/html");
        }
    }
}
