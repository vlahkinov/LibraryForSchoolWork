using Domain.Abstractions.Services;
using Domain.Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
        [Authorize]
        
        public class AccountController : Controller
        {
            private readonly IAccountService service;

            public AccountController(IAccountService service)
            {
                this.service = service;
            }

            [HttpDelete]

            public async Task<IActionResult> Delete()
            {
                var newId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "id").Value);
                await service.DeleteAccount(newId);
                return Ok();
            }

            [HttpPut]
            public async Task<IActionResult> Update(AccountDtoWithId userDto)
            {
                int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "id").Value);
                userDto.Id = id;

                await service.UpdateAccount(userDto);

                return NoContent();
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {

                int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "id").Value);

                var user = await service.GetCurrentAccount(id);

                return Ok(user);

            }
        }

    
}
