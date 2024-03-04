using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetAdoptionCenter.Core.Services
{
	public interface IAccountService
	{
		Task<bool> RegisterUserAsync(string login, string password);
		Task<bool> CheckUserExistsAsync(string login, string password);
	}
}
