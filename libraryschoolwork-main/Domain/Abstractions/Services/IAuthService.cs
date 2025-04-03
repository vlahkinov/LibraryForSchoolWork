using Domain.Dtos;
using Domain.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IAuthService
    {
        public Task Register(AccountDto accountDto);
        public Task<string> Login(string email, string password);

    }
}
