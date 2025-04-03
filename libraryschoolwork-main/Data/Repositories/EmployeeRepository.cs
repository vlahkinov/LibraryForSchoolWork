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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(LibraryContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
