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

		public AccountService(VirtualPetAdoptionCenterDbContext dbContext)
		{
			_dbContext = dbContext;
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
				Password = password,
                AuthType = authType.ToString()
            };

			_dbContext.Users.Add(newUser);
			await _dbContext.SaveChangesAsync();
            return true;
        }

		public async Task<bool> CheckUserExistsAsync(string login, string password, AuthType authType)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password && u.AuthType == authType.ToString());

			return user != null;
		}

		private async Task<bool> UserExistsAsync(string login)
		{
			return await _dbContext.Users.AnyAsync(u => u.Login == login);
		}
	}
}

