using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.DomainModels;
using VirtualPetAdoptionCenter.Models.Enums;

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
        public List<PetModel> GetPetsByUserId(int userId)
        {
            return _dbContext.Pets.Where(p => p.UserId == userId).ToList();
        }

        public PetModel GetPetById(int petId)
        {
            return _dbContext.Pets.FirstOrDefault(p => p.Id == petId);
        }

        public void FeedPet(int petId)
        {
            var pet = _dbContext.Pets.FirstOrDefault(x => x.Id == petId);

            if (pet != null)
            {
                pet.FeedCount = pet.FeedCount == null ? 1 : ++pet.FeedCount;
                _dbContext.SaveChanges();
            }
        }
        
        public void UpdateGroomingTime(int petId, GroomType groomType)
        {
            var record = _dbContext.Groom.FirstOrDefault(x => x.PetId == petId);
            record ??= new GroomingModel();
            record.PetId = petId;
/*
            var brushtime = DateTbrushtime.TotalHours;
            var trim = DateTbrushtime.TotalHours
                 var brushtime = DateTbrushtime.TotalHours

                new PetConditionModel()
                {
                    IsBrusehd = brushtim.TotalHours > 2
                }*/


            switch (groomType)
            {
                case GroomType.TrimNailsTime:
                    record.TrimNailsTime = DateTime.Now;
                    break;
                case GroomType.WashTime:
                    record.WashTime = DateTime.Now;
                    break;
                case GroomType.BrushTime:
                    record.BrushTime = DateTime.Now;
                    break;
                default:
                    // 
                    break;
            }
            if (record.Id == 0)
            {
                _dbContext.Groom.Add(record);
            }
            _dbContext.SaveChanges();
        }

        /*public PetConditionModel CheckPetCondition(int petId)
        {        
            var record = _dbContext.Groom.FirstOrDefault(x => x.PetId == petId);
            var petCondition = new PetConditionModel();

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
        }*/
    }
}
