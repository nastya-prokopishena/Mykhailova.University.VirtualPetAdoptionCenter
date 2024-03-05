using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetAdoptionCenter.Models.NewFolder1;

namespace VirtualPetAdoptionCenter.Core.Services
{
	public interface IAccountService
	{
		Task<bool> RegisterUserAsync(string login, string password, AuthType authType);
		Task<bool> CheckUserExistsAsync(string login, string password, AuthType authType);
	}
}
