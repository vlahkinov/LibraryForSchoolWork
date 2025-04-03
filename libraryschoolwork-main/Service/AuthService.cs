using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Dtos;
using Domain.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository accountRepository;
        private readonly JWTService jWTService;

        public AuthService(IAccountRepository accountRepository, JWTService jWTService)
        {
            this.accountRepository = accountRepository;
            this.jWTService = jWTService;
        }

        public async Task<string> Login(string email, string password)
        {
            var account = await accountRepository.GetByEmailAsync<AccountDtoWithId>(email);
            var isVerified = BCrypt.Net.BCrypt.Verify(password, account.Password);

            if (!isVerified)
            {
                throw new ArgumentException("Account not vified");
            }
            else if (account == null || account.IsDeleted)
            {
                throw new KeyNotFoundException();
            }

            return await jWTService.GenerateToken(account);
        }



        public async Task Register(AccountDto accountDto)
        {
            accountDto.Password = BCrypt.Net.BCrypt.HashPassword(accountDto.Password);
            await accountRepository.CreateAsync(accountDto);
        }



    }
}
