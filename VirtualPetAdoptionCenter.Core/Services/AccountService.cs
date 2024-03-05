using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.Account;
using VirtualPetAdoptionCenter.Models.NewFolder1;

namespace VirtualPetAdoptionCenter.Core.Services
{
	public class AccountService : IAccountService
    {
		private readonly VirtualPetAdoptionCenterDbContext _dbContext;
        private readonly IEncryption encryptionService;

        public AccountService(VirtualPetAdoptionCenterDbContext dbContext,IEncryption encryptionService)
		{
			_dbContext = dbContext;
			this.encryptionService = encryptionService;
		}

		public async Task<bool> RegisterUserAsync(string login, string password, AuthType authType)
		{
			if (await UserExistsAsync(login))
			{
				return false;
			}

			var newUser = new UserModel
			{
				Login = login,
				Password = encryptionService.Encrypt(password),
                AuthType = authType.ToString()
            };

			_dbContext.Users.Add(newUser);
			await _dbContext.SaveChangesAsync();
            return true;
        }

		public async Task<bool> CheckUserExistsAsync(string login, string password, AuthType authType)
		{
			password = encryptionService.Encrypt(password);
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password && u.AuthType == authType.ToString());

			return user != null;
		}

		private async Task<bool> UserExistsAsync(string login)
		{
			return await _dbContext.Users.AnyAsync(u => u.Login == login);
		}
	}
}

