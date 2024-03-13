using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Reflection.Metadata;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;

namespace VirtualPetAdoptionCenter.Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }   

        [HttpPost]
        [Route(nameof(Adopt))]
        public IActionResult Adopt([FromForm]int petId)
        {
            var userId = HttpContext.Session.GetInt32(Core.Constants.UserCookieKey);
            _petService.AdoptPet(petId, userId.Value);
            return RedirectToPage("/AllPets");
        }
     
    }
}

