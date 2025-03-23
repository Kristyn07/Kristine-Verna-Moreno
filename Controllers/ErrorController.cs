using Microsoft.AspNetCore.Mvc;

namespace KristineVernaMorenoV1._2.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error/NotFound")]
        public new IActionResult NotFound()
        {
            return View("NotFound");
        }
    } 
}
