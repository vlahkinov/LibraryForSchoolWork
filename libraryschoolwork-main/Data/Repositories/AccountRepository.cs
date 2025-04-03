using AutoMapper;
using Data.Entities;
using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(LibraryContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<TDto>> GetAsync<TDto>(Expression<Func<TDto, bool>> filter)
        {
            var query = Items.AsQueryable();

            if (filter != null)
                query = query.Where(Mapper.Map<Expression<Func<Account, bool>>>(filter));
            return await Mapper.ProjectTo<TDto>(query).ToListAsync();
        }
        public async Task<TDto> GetByEmailAsync<TDto>(string email)
            => Mapper.Map<TDto>(await Items.FirstOrDefaultAsync(x => x.Email == email));

        public override async Task DeleteAsync(int id)
        {
            var user = await Items.FirstOrDefaultAsync(x => x.Id == id);

            user.IsDeleted = true;

            Items.Update(user);

            await DbContext.SaveChangesAsync();
        }

    }
}
