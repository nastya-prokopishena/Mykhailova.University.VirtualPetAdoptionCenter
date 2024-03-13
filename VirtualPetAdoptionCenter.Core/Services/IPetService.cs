using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using VirtualPetAdoptionCenter.Models.Account;  

namespace VirtualPetAdoptionCenter.Core.Services
{
    public interface IPetService
    {
        List<PetModel> GetAllPets();
        void AdoptPet(int petId, int userId);
        List<PetModel> GetPetsByUserId(int userId);
        void FeedPet(int petId);
    }
}
