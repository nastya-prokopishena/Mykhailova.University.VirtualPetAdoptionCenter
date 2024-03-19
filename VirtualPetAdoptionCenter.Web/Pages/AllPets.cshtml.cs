using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class AllPetsModel : PageModel
    {
        public List<PetModel> Pets { get; set; }
        public AllPetsModel(IPetService petService)
        {
            Pets = petService.GetAllPets();
        }
        public void OnGet()
        { 
        }
    }
}
