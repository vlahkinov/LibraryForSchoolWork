using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IEmployeeService
    {
        public Task CreateAsync(EmployeeDto employee);
        public Task<EmployeeDto> GetByIdAsync(int id);
        public Task<IEnumerable<EmployeeDto>> GetAllAsync();

        public Task UpdateAsync(EmployeeDto employee);

        public Task DeleteAsync(int id);


    }
}
