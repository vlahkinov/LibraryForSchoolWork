using AutoMapper;
using Data.Entities;
using Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
