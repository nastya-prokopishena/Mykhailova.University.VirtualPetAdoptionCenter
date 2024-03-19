using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.Account;
using VirtualPetAdoptionCenter.Models.Enums;

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
        
        [HttpPost]
        [Route(nameof(FeedPet))]
        public IActionResult FeedPet([FromForm]int petId)
        {
            _petService.FeedPet(petId);
            return RedirectToPage("/MyPets");
        }

        [HttpGet]
        [Route(nameof(GroomPet))]
        public IActionResult GroomPet(int petId)
        {
            return RedirectToPage("/PetDetails", new { petId = petId });
        }

        [HttpPost]
        [Route(nameof(UpdateGroomingTime))]
        public IActionResult UpdateGroomingTime([FromForm]int petId,[FromForm] GroomType groomType)
        {    
            _petService.UpdateGroomingTime(petId, groomType);
            
            return RedirectToAction(nameof(GroomPet), new { petId = petId });
           
        }
    }
}

