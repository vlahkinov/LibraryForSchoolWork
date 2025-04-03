using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IAccountRepository : IBaseRepository
    {
        Task<IEnumerable<TDto>> GetAsync<TDto>(
            Expression<Func<TDto, bool>> filter);
        Task<TDto> GetByEmailAsync<TDto>(string email);

    }
}
