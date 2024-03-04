using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;

namespace VirtualPetAdoptionCenter.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly VirtualPetAdoptionCenterDbContext dbContext;
    private readonly IAccountService accountService;   
        
    public AccountController(VirtualPetAdoptionCenterDbContext context, IAccountService accService)
    {
        dbContext = context;
        accountService = accService;
        var asd = dbContext.Users.FirstOrDefault();
    }

    [HttpPost]
    [Route(nameof(SignIn))]
    public async Task<IActionResult> SignIn([FromForm] LoginRequest request)
    {
        // Реализуйте логику проверки логина и пароля, например, через сервис IAccountService
        // Верните результат в виде IActionResult

       var result = await accountService.CheckUserExistsAsync(request.Login, request.Password);



        return Ok(result);
    }

    [HttpPost]
    [Route(nameof(SignUp))]
    public IActionResult SignUp([FromBody] LoginRequest request)
    {
        // Реализуйте логику регистрации пользователя, например, через сервис IAccountService
        // Верните результат в виде IActionResult
        return Ok();
    }

    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
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