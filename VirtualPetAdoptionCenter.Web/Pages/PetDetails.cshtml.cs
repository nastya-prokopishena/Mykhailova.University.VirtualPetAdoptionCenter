using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
/*using VirtualPetAdoptionCenter.Core.Models;
*/using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.Account;
using System.Collections.Generic;

namespace VirtualPetAdoptionCenter.Web.Pages
{
    public class PetDetailsModel : PageModel
    {
        private readonly IPetService _petService;

        public PetModel Pet { get; set; }

        public PetDetailsModel(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult OnGet(int petId)
        {
            Pet = _petService.GetPetById(petId);

            if (Pet == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
