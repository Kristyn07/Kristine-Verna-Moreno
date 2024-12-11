using Microsoft.AspNetCore.Mvc;

namespace KristineVernaMorenoV1._2.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error/NotFound")]
        public IActionResult NotFound()
        {
            return View(); // This will look for Views/Error/NotFound.cshtml
        }
    } 
}
