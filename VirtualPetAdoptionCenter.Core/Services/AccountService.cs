using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.Account;

namespace VirtualPetAdoptionCenter.Core.Services
{
	public class AccountService : IAccountService
	{
		private readonly VirtualPetAdoptionCenterDbContext _dbContext;

		public AccountService(VirtualPetAdoptionCenterDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> RegisterUserAsync(string login, string password)
		{
			if (await UserExistsAsync(login))
			{
				return false;
			}

			var newUser = new UserModel
			{
				Login = login,
				Password = password
			};

			_dbContext.Users.Add(newUser);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> CheckUserExistsAsync(string login, string password)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

			return user != null;
		}

		private async Task<bool> UserExistsAsync(string login)
		{
			return await _dbContext.Users.AnyAsync(u => u.Login == login);
		}
	}
}

