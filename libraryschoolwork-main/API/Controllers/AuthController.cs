using Domain.Abstractions.Services;
using Domain.Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var token = await authService.Login(accountDto.Email, accountDto.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            HttpContext.Session.SetString("Token", token);
            return RedirectToAction("Index", "Book");

        }

        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        
        public async Task<IActionResult> Register(AccountDto accountDto)
        {
            await authService.Register(accountDto);
            return RedirectToAction("Index", "Book");
        }
        

    }
}

