using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Models.Account;

namespace VirtualPetAdoptionCenter.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        public UserAzureAD GetUserOnAzureAd(ClaimsPrincipal user)
        {
            RedirectToRoute("/api/account/login");
            // var preferredUsernameClaim = user.Claims.FirstOrDefault(c => c.Type.Equals("preferred_username"));
            // if (preferredUsernameClaim != null)
            // {
            //   //   RedirectToAction("Action2", nameof(AccountController));
            //     User.Claims.FirstOrDefault(c => c.Type.Equals("preferred_username"));
            //     return new UserAzureAD
            //     {
            //         user_name = user.Claims.FirstOrDefault(p => p.Type.Equals("name")).Value,
            //         user_email = preferredUsernameClaim.Value,
            //         user_domain = string.Format(@"lnu.edu.ua\{0}", preferredUsernameClaim.Value.Split('@')[0])
            //     };
            // }
            return null;
        }
    }
}