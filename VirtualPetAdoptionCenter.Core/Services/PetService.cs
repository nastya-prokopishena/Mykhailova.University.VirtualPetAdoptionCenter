using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.Account;  


namespace VirtualPetAdoptionCenter.Core.Services
{
    public class PetService : IPetService
    {
        private readonly VirtualPetAdoptionCenterDbContext _dbContext;
        public PetService(VirtualPetAdoptionCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PetModel> GetAllPets()
        {
            return _dbContext.Pets.ToList();
        }
        public void AdoptPet(int petId, int userId)
        {
            var pet = _dbContext.Pets.FirstOrDefault(x => x.Id == petId);

            if (pet != null)
            {
                pet.UserId = userId;
                _dbContext.SaveChanges();
            }
        }
    }
}
