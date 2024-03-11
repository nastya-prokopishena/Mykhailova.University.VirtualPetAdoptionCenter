﻿using System;
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
            try
            {
                return _dbContext.Pets.ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
