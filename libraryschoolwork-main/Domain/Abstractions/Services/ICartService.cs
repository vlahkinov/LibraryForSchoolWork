using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface ICartService
    {
        public Task CreateAsync(CartDto cart);
        public Task UpdateAsync(CartDto cart);
        public Task<CartDto> GetByIdAsync(int id);
        public Task<IEnumerable<CartDto>> GetAllAsync();
        public Task DeleteAsync(int id);
    }
}
