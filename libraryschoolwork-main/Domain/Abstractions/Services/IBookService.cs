using Domain.Dtos;
using Domain.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IBookService
    {
        Task CreateAsync(BookDto dto);
        Task UpdateAsync(BookDto dto);
        Task DeleteAsync(int id);
        Task<BookDto> GetByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllAsync();
        
        
    }
}
