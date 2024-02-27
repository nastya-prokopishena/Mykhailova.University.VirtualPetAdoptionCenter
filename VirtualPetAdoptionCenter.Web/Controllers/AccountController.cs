using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoptionCenter.Core;

namespace VirtualPetAdoptionCenter.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly VirtualPetAdoptionCenterDbContext dbContext;
        
    public AccountController(VirtualPetAdoptionCenterDbContext context)
    {
        dbContext = context;
        var asd = dbContext.Users.FirstOrDefault();
    }

    [HttpGet]
    [Route(nameof(Login))]
    public IActionResult Login()
    {
       if (User.Identity?.IsAuthenticated != null)
       {
           var preferredUsernameClaim = User.Claims.FirstOrDefault(c => c.Type.Equals("preferred_username"));
           var name = User.Claims.FirstOrDefault(c => c.Type.Equals("name"));
           var email = User.Claims.FirstOrDefault(c => c.Type.Equals("preferred_username")).Value;
       }

       return Ok();
    }
}