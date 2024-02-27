using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VirtualPetAdoptionCenter.Web.Controllers
{
    [ApiController]
    [Route("/api/authorization")]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public ActionResult Get()
        {
            return null;
        }
    }
}