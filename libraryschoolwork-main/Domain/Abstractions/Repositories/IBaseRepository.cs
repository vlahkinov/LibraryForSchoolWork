using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IBaseRepository
    {
        Task<TDto> GetByIdAsync<TDto>(int id);
        Task<IEnumerable<TDto>> GetAllAsync<TDto>(
             Expression<Func<TDto, bool>>? filter = null);

        Task<TDto> CreateAsync<TDto>(TDto dto);
        Task UpdateAsync<TDto>(TDto dto);
        Task DeleteAsync(int id);

    }
}
