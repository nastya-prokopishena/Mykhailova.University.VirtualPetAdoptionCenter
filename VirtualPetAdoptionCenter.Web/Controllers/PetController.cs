using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route(nameof(AllPets))]
        public IActionResult AllPets()
        {
            var allPets = _petService.GetAllPets();
            return View(allPets);
        }
    }
}
