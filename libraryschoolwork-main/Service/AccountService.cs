using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }
        public async Task DeleteAccount(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<AccountDto> GetCurrentAccount(int id)
        {
            return await repository.GetByIdAsync<AccountDto>(id);
        }

        public async Task UpdateAccount(AccountDtoWithId userDto)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            userDto.Password = password;
            await repository.UpdateAsync(userDto);
        }

    }
}
