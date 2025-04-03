using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository repository;

        public  CartService(ICartRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(CartDto cart)
        {
             await repository.CreateAsync(cart);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            return await repository.GetAllAsync<CartDto>();
        }

        public async Task<CartDto> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync<CartDto>(id);
        }

        public async Task UpdateAsync(CartDto cart)
        {
            await repository.UpdateAsync(cart);
        }
    }
}
