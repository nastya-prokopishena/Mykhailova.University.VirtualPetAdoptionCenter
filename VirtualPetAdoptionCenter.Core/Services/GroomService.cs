using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public class GroomService : IGroomService
    {
        private readonly VirtualPetAdoptionCenterDbContext _dbContext;
        public GroomService(VirtualPetAdoptionCenterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PetConditionModel CheckPetCondition(int petId)
        {
            var petCondition = new PetConditionModel();
            var record = _dbContext.Groom.FirstOrDefault(g => g.PetId == petId);

            if (record != null && (DateTime.Now - record.WashTime).TotalHours <= 2)
            {
                petCondition.IsWashed = true;
            }
            else
            {
                petCondition.IsWashed = false;
            }

            if (record != null && (DateTime.Now - record.TrimNailsTime).TotalHours <= 2)
            {
                petCondition.IsNailTrimmed = true;
            }
            else
            {
                petCondition.IsNailTrimmed = false;
            }

            if (record != null && (DateTime.Now - record.BrushTime).TotalHours <= 2)
            {
                petCondition.IsBrushed = true;
            }
            else
            {
                petCondition.IsBrushed = false;
            }

            return petCondition;
        }
    }
}
