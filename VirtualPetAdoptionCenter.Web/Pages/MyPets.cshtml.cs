using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class MyPetsModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IAchievementService _achievementService;

        public List<PetModel> Pets { get; set; }
        public AchievementModel Achievement { get; set; }


        public MyPetsModel(IPetService petService, IAchievementService achievementService)
        {        
            _petService = petService;
            _achievementService = achievementService;
        }


        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32(Constants.UserCookieKey);
            if (userId.HasValue)
            {
                Pets = _petService.GetPetsByUserId(userId.Value);
                Achievement =  _achievementService.GetAchivement(userId.Value);
            }
        }
    }
}
    
