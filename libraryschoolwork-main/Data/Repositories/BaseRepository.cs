using AutoMapper;
using Data.Entities;
using Data.Extensions;
using Domain.Abstractions.Repositories;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository
        where TEntity : BaseEntity
    {
        protected IMapper Mapper { get; }
        protected LibraryContext DbContext { get; }
        protected DbSet<TEntity> Items { get; }

        public BaseRepository(LibraryContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Items = DbContext.Set<TEntity>();
            Mapper = mapper;
        }

        public async Task<TDto> GetByIdAsync<TDto>(int id)
            => Mapper.Map<TDto>(await Items.FirstOrDefaultAsync(x => x.Id == id));

        public async Task<IEnumerable<TDto>> GetAllAsync<TDto>(Expression<Func<TDto, bool>>? filter = null)
        {
            var query = Items.AsQueryable();

            if (filter != null)
                query = query.Where(Mapper.Map<Expression<Func<TEntity, bool>>>(filter));

            return await Mapper.ProjectTo<TDto>(query).ToListAsync();
        }

        public async Task<TDto> CreateAsync<TDto>(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            await Items.AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return Mapper.Map<TDto>(entity);
        }

        public async Task UpdateAsync<TDto>(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            DbContext.Set<TEntity>().Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Items
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                DbContext.Set<TEntity>().Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }

    }
}
