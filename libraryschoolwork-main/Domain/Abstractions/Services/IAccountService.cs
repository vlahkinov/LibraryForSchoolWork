using Domain.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IAccountService
    {
        public Task<AccountDto> GetCurrentAccount(int id);

        public Task UpdateAccount(AccountDtoWithId accountDto);

        public Task DeleteAccount(int id);
    }

}
