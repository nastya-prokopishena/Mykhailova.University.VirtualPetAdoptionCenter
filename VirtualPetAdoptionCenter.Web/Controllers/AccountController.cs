using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoptionCenter.Core.Services;
using VirtualPetAdoptionCenter.Models.RequestModels;

namespace VirtualPetAdoptionCenter.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;   
        
    public AccountController(IAccountService accService)
    {
        _accountService = accService;
    }

    [HttpPost]
    [Route(nameof(SignIn))]
    public async Task<IActionResult> SignIn([FromForm] LoginRequest request)
    {
        // Реализуйте логику проверки логина и пароля, например, через сервис IAccountService
        // Верните результат в виде IActionResult

       var result = await _accountService.CheckUserExistsAsync(request.Login, request.Password);

       return Ok();
    }

    [HttpPost]
    [Route(nameof(SignUp))]
    public IActionResult SignUp([FromForm] LoginRequest request)
    {
        // Реализуйте логику регистрации пользователя, например, через сервис IAccountService
        // Верните результат в виде IActionResult
        return Ok();
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