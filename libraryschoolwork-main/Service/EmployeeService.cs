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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public async Task CreateAsync(EmployeeDto employee)
        {

            await repository.CreateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await repository.GetAllAsync<EmployeeDto>();
            return employees;

        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await repository.GetByIdAsync<EmployeeDto>(id);
            return employee;
        }

        public async Task UpdateAsync(EmployeeDto emp)
        {
            await repository.UpdateAsync(emp);
        }

    }
}
