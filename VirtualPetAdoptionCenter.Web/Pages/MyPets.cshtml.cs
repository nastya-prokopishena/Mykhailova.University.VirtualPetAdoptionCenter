using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.Account;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class MyPetsModel : PageModel
    {
        private readonly IPetService _petService;
        public List<PetModel> Pets { get; set; }
        public MyPetsModel(IPetService petService)
        {        
            _petService = petService;
        }
        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32(Constants.UserCookieKey);
            if (userId.HasValue)
            {
                Pets = _petService.GetPetsByUserId(userId.Value);
            }
        }
    }
}
    
